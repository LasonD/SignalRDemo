import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DemoService } from "../../services/demo.service";

@Component({
  selector: 'app-demo',
  templateUrl: './demo.component.html',
})
export class DemoComponent implements OnInit {
  createDemoDeclarationsForm!: FormGroup;
  deleteDemoDeclarationsForm!: FormGroup;

  constructor(private fb: FormBuilder,
              private demoService: DemoService) {}

  ngOnInit() {
    this.createDemoDeclarationsForm = this.fb.group({
      createCount: [10, [Validators.required, Validators.min(1)]],
      createInterval: [1000, [Validators.required, Validators.min(1)]],
    });
    this.deleteDemoDeclarationsForm = this.fb.group({
      deleteCount: [5, [Validators.required, Validators.min(1)]],
      deleteInterval: [1000, [Validators.required, Validators.min(1)]],
    });
  }

  createDemoDeclarations() {
    const count = this.createDemoDeclarationsForm.get('createCount')?.value;
    const intervalMs = this.createDemoDeclarationsForm.get('createInterval')?.value;
    this.demoService.createDemoDeclarations(count, intervalMs)
      .subscribe();
  }

  deleteDemoDeclarations() {
    const count = this.deleteDemoDeclarationsForm.get('deleteCount')?.value;
    const intervalMs = this.deleteDemoDeclarationsForm.get('deleteInterval')?.value;
    this.demoService.deleteDemoDeclarations(count, intervalMs)
      .subscribe();
  }
}
