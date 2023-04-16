import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private router: Router) {

  }

  public onDeclarationsSelected() {
    this.router.navigate(['declarations']);
  }

  public onStatisticsSelected() {
    this.router.navigate(['statistics']);
  }
}
