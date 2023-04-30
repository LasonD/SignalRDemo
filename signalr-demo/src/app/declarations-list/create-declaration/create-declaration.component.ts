import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DeclarationsService } from "../../services/declarations.service";
import { JurisdictionsService } from "../../services/jurisdictions.service";
import { Subject, takeUntil } from "rxjs";

@Component({
  selector: 'app-create-declaration',
  templateUrl: './create-declaration.component.html',
  styleUrls: ['./create-declaration.component.scss']
})
export class CreateDeclarationComponent implements OnInit, OnDestroy {
  destroyed$: Subject<boolean> = new Subject<boolean>();

  @Input() jurisdictions: string[] = [];

  declarationForm: FormGroup;

  constructor(private fb: FormBuilder,
              private declarationsService: DeclarationsService,
              private jurisdictionService: JurisdictionsService) {
    this.declarationForm = this.fb.group({
      description: ['', Validators.required],
      jurisdiction: [this.jurisdictions[0]],
      netMass: ['', [Validators.required, Validators.min(0)]]
    });
  }

  ngOnInit(): void {
    this.jurisdictionService
      .getJurisdictions()
      .subscribe();

    this.jurisdictionService.jurisdictions$
      .pipe(takeUntil(this.destroyed$))
      .subscribe((jurisdictions) => {
        this.jurisdictions = jurisdictions?.map((j) => j.code) ?? [];
      })
  }

  onSubmit(): void {
    if (!this.declarationForm.valid) {
      return;
    }

    this.declarationsService.createDeclaration(this.declarationForm.value)
      .subscribe();

    this.declarationForm.reset({ jurisdiction: this.jurisdictions[0] });
  }

  ngOnDestroy(): void {
    this.destroyed$.next(true);
  }
}
