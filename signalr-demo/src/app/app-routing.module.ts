import { inject, NgModule } from '@angular/core';
import { ActivatedRouteSnapshot, PreloadAllModules, RouterModule, RouterStateSnapshot, Routes } from '@angular/router';
import { DeclarationsListComponent } from "./declarations-list/declarations-list.component";
import { AuthComponent } from "./auth/auth.component";
import { AuthGuard } from "./auth/services/auth.guard";

const appRoutes: Routes = [
  { path: '', redirectTo: '/declarations', pathMatch: 'full' },
  { path: 'auth', component: AuthComponent },
  { path: 'declarations', component: DeclarationsListComponent, canActivate: [(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => inject(AuthGuard).canActivate(route, state)] },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(appRoutes, { preloadingStrategy: PreloadAllModules, initialNavigation: 'enabledBlocking' }),
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
