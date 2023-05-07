import { Injectable } from '@angular/core';
import { Declaration } from "../models/declaration.model";
import { DeclarationsService } from "./declarations.service";
import { RealTimeUpdatesService } from "./real-time-updates.service";
import { BehaviorSubject, Subject, tap } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class RealTimeStateManagementService {
  private isFetched: boolean = false;
  private declarations!: Declaration[];

  public declarations$: Subject<Declaration[]> = new BehaviorSubject<Declaration[]>([]);

  constructor(private declarationsService: DeclarationsService,
              private updatesService: RealTimeUpdatesService) {
    this.declarations$.pipe(tap(d => console.log('Declarations: ', d))).subscribe();

    this.updatesService.declarationCreated$
      .subscribe((createdDeclaration: Declaration) => {
        this.declarations = [createdDeclaration, ...this.declarations];
        this.declarations$.next(this.declarations);
      });

    this.updatesService.declarationUpdated$
      .subscribe((updatedDeclaration: Declaration) => {
        this.declarations = this.declarations.map(d => d.id === updatedDeclaration.id ? updatedDeclaration : d);
        this.declarations$.next(this.declarations);
      });

    this.updatesService.declarationDeleted$
      .subscribe((deletedDeclarationId: string) => {
        this.declarations = this.declarations.filter(d => d.id !== deletedDeclarationId);
        this.declarations$.next(this.declarations);
      });

    this.updatesService.declarationEditToggled$
      .subscribe((declarationId: string) => {
        this.declarations = this.declarations.map((d) => {
          if (d.id === declarationId) {
            d.isLocked = true;
          }
          return d;
        });
        this.declarations$.next(this.declarations);
      });

    this.updatesService.declarationEditCancelled$
      .subscribe((declarationId: string) => {
        this.declarations = this.declarations.map((d) => {
          if (d.id === declarationId) {
            d.isLocked = false;
          }
          return d;
        });
        this.declarations$.next(this.declarations);
      });
  }

  fetchInitialState(): void {
    if (this.isFetched) {
      this.declarations$.next(this.declarations);
      return;
    }

    this.isFetched = true;
    this.declarationsService.getDeclarations()
      .subscribe((declarations) => {
        this.declarations = declarations;
        this.declarations$.next(this.declarations);
      });
  }
}
