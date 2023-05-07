import { Component, OnDestroy } from '@angular/core';
import { Declaration, DeclarationChange } from "../models/declaration.model";
import { DeclarationsService } from "../services/declarations.service";
import { JurisdictionsService } from "../services/jurisdictions.service";
import { Observable, Subject, takeUntil } from "rxjs";
import { filter, map } from "rxjs/operators";
import { RealTimeUpdatesService } from "../services/real-time-updates.service";
import { NotificationService } from "../services/notifications.service";
import { RealTimeStateManagementService } from "../services/real-time-state-management.service";

@Component({
  selector: 'app-declarations-list',
  templateUrl: './declarations-list.component.html',
  styleUrls: ['./declarations-list.component.scss']
})
export class DeclarationsListComponent implements OnDestroy {
  destroyed$: Subject<boolean> = new Subject<boolean>();

  declarations: Declaration[] = [];

  jurisdictionCodes$!: Observable<string[]>;
  declarationEditChanges$!: Observable<DeclarationChange>;

  constructor(private declarationsService: DeclarationsService,
              private jurisdictionService: JurisdictionsService,
              private realTimeUpdatesService: RealTimeUpdatesService,
              private notificationsService: NotificationService,
              private realTimeStateManager: RealTimeStateManagementService) {}

  ngOnInit(): void {
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
    this.realTimeStateManager.fetchInitialState();
  }

  subscribeToRealTimeEvents() {
    this.realTimeStateManager.declarations$
      .pipe(takeUntil(this.destroyed$))
      .subscribe((declarations) => {
        this.declarations = declarations;
      })

    this.realTimeUpdatesService.declarationCreated$
      .pipe(takeUntil(this.destroyed$))
      .subscribe((createdDeclaration: Declaration) => {
        this.notificationsService.showInfo(`A new declaration for ${createdDeclaration.jurisdiction} was declared by ${createdDeclaration.declarantEmail}`, 'Declaration created');
      });

    this.declarationEditChanges$ = this.realTimeUpdatesService.declarationEditChange$
      .pipe(takeUntil(this.destroyed$));

    this.realTimeUpdatesService.userConnected$
      .pipe(takeUntil(this.destroyed$))
      .subscribe((email) => {
        this.notificationsService.showInfo(`User ${email} connected.`);
      });

    this.realTimeUpdatesService.userDisconnected$
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
    if (!prompt('Are you sure?')) {
      return;
    }

    this.declarationsService.deleteDeclaration(declaration.id)
      .subscribe();
  }

  onToggleEdit(declaration: Declaration) {
    this.realTimeUpdatesService.declarationEditToggled(declaration.id);
  }

  onCancelEdit(declaration: Declaration) {
    this.realTimeUpdatesService.declarationEditCancelled(declaration.id);
  }

  onDeclarationChanges(change: DeclarationChange) {
    this.realTimeUpdatesService.declarationChanged(change);
  }

  ngOnDestroy(): void {
    this.destroyed$.next(true);
  }
}
