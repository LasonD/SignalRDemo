import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DemoService } from "../../services/demo.service";

@Component({
  selector: 'app-demo',
  templateUrl: './demo.component.html',
})
export class DemoComponent implements OnInit {
  form!: FormGroup;

  constructor(private fb: FormBuilder,
              private demoService: DemoService) {}

  ngOnInit() {
    this.form = this.fb.group({
      count: [null, [Validators.required, Validators.min(1)]],
      interval: [null, [Validators.required, Validators.min(1)]],
    });
  }

  createDemoDeclarations() {
    const count = this.form.get('count')?.value;
    const intervalMs = this.form.get('interval')?.value;
    this.demoService.createDemoDeclarations(count, intervalMs)
      .subscribe();
  }
}
