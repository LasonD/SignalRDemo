import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { environment } from "../../environments/environment";
import { Declaration } from "../models/declaration.model";
import { Subject } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class DeclarationsSignalService {
  private hubConnection: signalR.HubConnection;

  declarationEditToggled$ = new Subject<string>();
  declarationEditCancelled$ = new Subject<string>();
  declarationUpdated$ = new Subject<Declaration>();
  declarationDeleted$ = new Subject<string>();
  declarationAdded$ = new Subject<Declaration>();

  constructor() {
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

    this.hubConnection.on('declarationAdded', (declaration: Declaration) => {
      this.declarationAdded$.next(declaration);
    });

    this.hubConnection.on('declarationUpdated', (declaration: Declaration) => {
      this.declarationUpdated$.next(declaration);
    });
  }
}
