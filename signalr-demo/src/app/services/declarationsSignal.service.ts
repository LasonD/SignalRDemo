import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { environment } from "../../environments/environment";
import { Declaration } from "../models/declaration.model";
import { Subject } from "rxjs";
import { NotificationService } from "./notifications.service";

@Injectable({
  providedIn: 'root'
})
export class DeclarationsSignalService {
  private hubConnection: signalR.HubConnection;

  declarationEditToggled$ = new Subject<string>();
  declarationEditCancelled$ = new Subject<string>();
  declarationUpdated$ = new Subject<Declaration>();
  declarationDeleted$ = new Subject<string>();
  declarationCreated$ = new Subject<Declaration>();

  userConnected$ = new Subject<string>();
  userDisconnected$ = new Subject<string>();

  constructor(private notificationsService: NotificationService) {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${environment.apiBaseUrl}/hubs/declarations`)
      .build();

    this.hubConnection.start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))

    this.hubConnection.on('declarationEditToggled', (declarationId: string) => {
      this.declarationEditToggled$.next(declarationId);
    });

    this.hubConnection.on('declarationEditCancelled', (declarationId: string) => {
      this.declarationEditCancelled$.next(declarationId);
    });

    this.hubConnection.on('declarationDeleted', (declarationId: string) => {
      this.declarationDeleted$.next(declarationId);
    });

    this.hubConnection.on('declarationCreated', (declaration: Declaration) => {
      this.declarationCreated$.next(declaration);
    });

    this.hubConnection.on('declarationUpdated', (declaration: Declaration) => {
      this.declarationUpdated$.next(declaration);
    });

    this.hubConnection.on('userConnected', (email: string) => {
      this.userConnected$.next(email);
    });

    this.hubConnection.on('userDisconnected', (email: string) => {
      this.userDisconnected$.next(email);
    });
  }

  declarationEditToggled(id: string) {
    this.hubConnection.invoke('declarationEditToggled', id)
      .catch((err) => this.notificationsService.showError(err));
  }

  declarationEditCancelled(id: string) {
    this.hubConnection.invoke('declarationEditCancelled', id)
      .catch((err) => this.notificationsService.showError(err));
  }
}
