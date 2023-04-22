import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from "./auth/services/auth.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  constructor(private router: Router,
              private authService: AuthService) {

  }

  ngOnInit(): void {
    this.authService.autoLogin();
  }

  public onDeclarationsSelected() {
    this.router.navigate(['declarations']);
  }

  public onStatisticsSelected() {
    this.router.navigate(['statistics']);
  }
}
