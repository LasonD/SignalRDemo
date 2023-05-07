import { inject, NgModule } from '@angular/core';
import { ActivatedRouteSnapshot, PreloadAllModules, RouterModule, RouterStateSnapshot, Routes } from '@angular/router';
import { DeclarationsListComponent } from "./declarations-list/declarations-list.component";
import { AuthComponent } from "./auth/auth.component";
import { AuthGuard } from "./auth/services/auth.guard";
import { CreateDeclarationComponent } from "./declarations-list/create-declaration/create-declaration.component";
import { StatisticsComponent } from "./statistics/statistics.component";

const appRoutes: Routes = [
  { path: '', redirectTo: '/declarations', pathMatch: 'full' },
  { path: 'auth', component: AuthComponent },
  { path: 'declarations', component: DeclarationsListComponent, canActivate: [(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => inject(AuthGuard).canActivate(route, state)] },
  { path: 'statistics', component: StatisticsComponent, canActivate: [(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => inject(AuthGuard).canActivate(route, state)] },
  { path: 'create-declaration', component: CreateDeclarationComponent, canActivate: [(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => inject(AuthGuard).canActivate(route, state)] },
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
