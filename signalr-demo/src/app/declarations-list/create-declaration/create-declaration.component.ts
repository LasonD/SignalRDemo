import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-declaration',
  templateUrl: './create-declaration.component.html',
  styleUrls: ['./create-declaration.component.scss']
})
export class CreateDeclarationComponent implements OnInit {
  jurisdictions: string[] = ['Jurisdiction A', 'Jurisdiction B', 'Jurisdiction C'];
  declarationForm: FormGroup;

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
    if (this.declarationForm.valid) {
      console.log('Form submitted:', this.declarationForm.value);
      this.declarationForm.reset({ jurisdiction: this.jurisdictions[0] });
    }
  }
}
