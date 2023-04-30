import { Component, OnDestroy } from '@angular/core';
import { Declaration } from "../models/declaration.model";
import { DeclarationsService } from "../services/declarations.service";
import { JurisdictionsService } from "../services/jurisdictions.service";
import { Observable, Subject, takeUntil } from "rxjs";
import { filter, map } from "rxjs/operators";
import { DeclarationsSignalService } from "../services/declarationsSignal.service";
import { NotificationService } from "../services/notifications.service";

@Component({
  selector: 'app-declarations-list',
  templateUrl: './declarations-list.component.html',
  styleUrls: ['./declarations-list.component.scss']
})
export class DeclarationsListComponent implements OnDestroy {
  destroyed$: Subject<boolean> = new Subject<boolean>();

  declarations: Declaration[] = [];
  lockedDeclarations: string[] = [];

  jurisdictionCodes$!: Observable<string[]>;

  constructor(private declarationsService: DeclarationsService,
              private jurisdictionService: JurisdictionsService,
              private declarationSignalService: DeclarationsSignalService,
              private notificationsService: NotificationService) {}

  ngOnInit(): void {
    this.declarationsService
      .getDeclarations()
      .subscribe((declarations) => (this.declarations = declarations));

    this.jurisdictionCodes$ = this.jurisdictionService.jurisdictions$
      .pipe(
        takeUntil(this.destroyed$),
        filter(x => !!x),
        map(x => x!.map(j => j.code))
      );

    this.declarationsService.error$
      .pipe(takeUntil(this.destroyed$))
      .subscribe((err) => {
        this.notificationsService.showError(err);
      });

    this.jurisdictionService.error$
      .pipe(takeUntil(this.destroyed$))
      .subscribe((err) => {
        this.notificationsService.showError(err);
      });

    this.subscribeToRealTimeEvents();
  }

  subscribeToRealTimeEvents() {
    this.declarationSignalService.declarationCreated$
      .pipe(takeUntil(this.destroyed$))
      .subscribe((createdDeclaration: Declaration) => {
        this.declarations = [createdDeclaration, ...this.declarations];
        this.notificationsService.showInfo(`A new declaration for ${createdDeclaration.jurisdiction} was declared by ${createdDeclaration.declarantEmail}`, 'Declaration created');
      });

    this.declarationSignalService.declarationUpdated$
      .pipe(takeUntil(this.destroyed$))
      .subscribe((updatedDeclaration: Declaration) => {
        this.declarations = this.declarations.map(d => d.id === updatedDeclaration.id ? updatedDeclaration : d);
      });

    this.declarationSignalService.declarationDeleted$
      .pipe(takeUntil(this.destroyed$))
      .subscribe((deletedDeclarationId: string) => {
        this.declarations = this.declarations.filter(d => d.id !== deletedDeclarationId);
      });

    this.declarationSignalService.declarationEditToggled$
      .pipe(takeUntil(this.destroyed$))
      .subscribe((declarationId: string) => {
        this.lockedDeclarations = [...this.lockedDeclarations, declarationId];
      });

    this.declarationSignalService.declarationEditCancelled$
      .pipe(takeUntil(this.destroyed$))
      .subscribe((declarationId: string) => {
        this.lockedDeclarations = this.lockedDeclarations.filter(id => id !== declarationId);
      });

    this.declarationSignalService.userConnected$
      .pipe(takeUntil(this.destroyed$))
      .subscribe((email) => {
        console.log('Showing info');
        this.notificationsService.showInfo(`User ${email} connected.`);
      });

    this.declarationSignalService.userDisconnected$
      .pipe(takeUntil(this.destroyed$))
      .subscribe((email) => {
        this.notificationsService.showInfo(`User ${email} disconnected.`);
      });
  }

  getRandomWidth(minWidth: number, maxWidth: number): string {
    const width = Math.floor(Math.random() * (maxWidth - minWidth + 1) + minWidth);
    return `${width}%`;
  }

  calculateWidthFromNetMass(minWidth: number, maxWidth: number, netMass: number, maxNetMass: number): string {
    const normalizedWidth = ((netMass / maxNetMass) * (maxWidth - minWidth)) + minWidth;
    return `${normalizedWidth}%`;
  }

  onDeclarationSave(declaration: Declaration) {
    this.declarationsService.updateDeclaration(declaration.id, declaration)
      .subscribe();
  }

  onDeclarationDelete(declaration: Declaration) {
    this.declarationsService.deleteDeclaration(declaration.id)
      .subscribe();
  }

  onToggleEdit(declaration: Declaration) {
    this.declarationSignalService.declarationEditToggled(declaration.id);
  }

  onCancelEdit(declaration: Declaration) {
    this.declarationSignalService.declarationEditCancelled(declaration.id);
  }

  ngOnDestroy(): void {
    this.destroyed$.next(true);
  }

  isLocked(declarationId: string) {
    return this.lockedDeclarations.some(id => id === declarationId);
  }
}
