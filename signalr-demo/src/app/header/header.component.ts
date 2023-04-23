import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from "../auth/services/auth.service";
import { Subject, takeUntil } from "rxjs";
import { Router } from "@angular/router";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnDestroy {
  destroyed$: Subject<boolean> = new Subject<boolean>();

  isLoggedIn = false;

  constructor(private authService: AuthService,
              private router: Router) {

  }

  ngOnInit(): void {
    this.authService.user$
      .pipe(takeUntil(this.destroyed$))
      .subscribe(result => {
        this.isLoggedIn = !!result?.user?.token;
      });
  }

  ngOnDestroy(): void {
    this.destroyed$.next(true);
  }

  logOut() {
    this.authService.logOut();
    this.router.navigate(['/auth']);
  }
}
