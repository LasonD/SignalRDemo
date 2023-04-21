import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { DeclarationsListComponent } from "./declarations-list/declarations-list.component";
import { AuthComponent } from "./auth/auth.component";

const appRoutes: Routes = [
  { path: '', redirectTo: '/declarations', pathMatch: 'full' },
  { path: 'auth', component: AuthComponent },
  { path: 'declarations', component: DeclarationsListComponent },
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
