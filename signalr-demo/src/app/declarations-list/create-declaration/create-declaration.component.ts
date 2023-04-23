import { Component, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subject } from "rxjs";
import { Declaration } from "../../models/declaration.model";

@Component({
  selector: 'app-create-declaration',
  templateUrl: './create-declaration.component.html',
  styleUrls: ['./create-declaration.component.scss']
})
export class CreateDeclarationComponent implements OnInit {
  jurisdictions: string[] = ['Jurisdiction A', 'Jurisdiction B', 'Jurisdiction C'];
  declarationForm: FormGroup;

  @Output() submitted: Subject<Declaration> = new Subject<Declaration>();

  constructor(private fb: FormBuilder) {
    this.declarationForm = this.fb.group({
      description: ['', Validators.required],
      jurisdiction: [this.jurisdictions[0]],
      netMass: ['', [Validators.required, Validators.min(0)]]
    });
  }

  ngOnInit(): void {
  }

  onSubmit(): void {
    if (!this.declarationForm.valid) {
      return;
    }

    this.declarationForm.reset({ jurisdiction: this.jurisdictions[0] });

    this.submitted.subscribe(this.declarationForm.value);
  }
}
