import { Component, OnDestroy, OnInit } from '@angular/core';
import { JurisdictionsService } from "../services/jurisdictions.service";
import { Observable, Subject, takeUntil } from "rxjs";
import { Jurisdiction } from "../models/jurisdiction.model";
import { NotificationService } from "../services/notifications.service";

@Component({
  selector: 'app-jurisdictions',
  templateUrl: './jurisdictions.component.html',
  styleUrls: ['./jurisdictions.component.scss']
})
export class JurisdictionsComponent implements OnInit, OnDestroy {
  destroyed$: Subject<boolean> = new Subject<boolean>();

  selectedJurisdiction: Jurisdiction | null = null;
  newDisplayColor: string = '';

  jurisdictions$!: Observable<Jurisdiction[]>;

  constructor(private jurisdictionsService: JurisdictionsService,
              private notificationsService: NotificationService) {
  }

  ngOnInit() {
    this.jurisdictions$ = this.jurisdictionsService.getJurisdictions()
      .pipe(takeUntil(this.destroyed$));
  }

  onSelect(jurisdiction: Jurisdiction): void {
    this.selectedJurisdiction = jurisdiction;
    this.newDisplayColor = jurisdiction.displayColor;
  }

  onUpdateColor(): void {
    if (!this.selectedJurisdiction) {
     return;
    }

    this.selectedJurisdiction.displayColor = this.newDisplayColor;
    this.jurisdictionsService.updateJurisdiction(this.selectedJurisdiction.code, this.selectedJurisdiction)
      .pipe(takeUntil(this.destroyed$))
      .subscribe(() => {
        this.notificationsService.showSuccess('A jurisdiction was successfully updated!', 'Success');
      });
  }

  ngOnDestroy() {
    this.destroyed$.next(true);
  }
}
