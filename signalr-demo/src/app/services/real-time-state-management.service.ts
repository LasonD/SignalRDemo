import { Injectable } from '@angular/core';
import { Declaration } from "../models/declaration.model";
import { DeclarationsService } from "./declarations.service";
import { RealTimeUpdatesService } from "./real-time-updates.service";
import { Subject } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class RealTimeStateManagementService {
  private declarations!: Declaration[];

  public declarations$: Subject<Declaration[]> = new Subject<Declaration[]>();

  constructor(private declarationsService: DeclarationsService,
              private updatesService: RealTimeUpdatesService) {

    this.declarationsService.getDeclarations()
      .subscribe((declarations) => {
        this.declarations = declarations;
      });

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
}
