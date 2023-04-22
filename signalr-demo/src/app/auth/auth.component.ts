import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from "./services/auth.service";
import { filter, take } from "rxjs/operators";
import { JurisdictionsService } from "../services/jurisdictions.service";
import { Observable } from "rxjs";
import { Jurisdiction } from "../models/jurisdiction.model";
import { Router } from "@angular/router";

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {
  mode: 'signin' | 'signup' = 'signin';
  registrationForm!: FormGroup;

  jurisdictions$!: Observable<Jurisdiction[]>;

  constructor(private fb: FormBuilder,
              private authService: AuthService,
              private jurisdictionsService: JurisdictionsService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.jurisdictions$ = this.jurisdictionsService.jurisdictions$
      .pipe(filter(x => !!x));

    this.jurisdictionsService.getJurisdictions()
      .subscribe();

    this.authService.user$
      .pipe(filter(x => !!x?.token))
      .subscribe(u => this.router.navigate(['/declarations']))

    this.buildForm();
  }

  buildForm(): void {
    if (this.mode === 'signin') {
      this.registrationForm = this.fb.group({
        email: ['', Validators.required],
        password: ['', Validators.required]
      });
    } else {
      this.registrationForm = this.fb.group({
        username: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        password: ['', Validators.required],
        jurisdictions: [[], Validators.required]
      });
    }
  }

  toggleMode(): void {
    this.mode = this.mode === 'signin' ? 'signup' : 'signin';
    this.buildForm();
  }

  onSubmit(): void {
    if (this.mode === 'signin') {
      this.authService.login(this.registrationForm.value)
        .pipe(take(1))
        .subscribe();
    } else {
      this.authService.register(this.registrationForm.value)
        .pipe(take(1))
        .subscribe();
    }
  }
}
