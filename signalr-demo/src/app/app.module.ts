import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DeclarationsListComponent } from './declarations-list/declarations-list.component';
import { DeclarationComponent } from './declarations-list/declaration/declaration.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AuthComponent } from './auth/auth.component';
import { AuthInterceptorService } from "./auth/services/auth-interceptor.service";
import { CreateDeclarationComponent } from './declarations-list/create-declaration/create-declaration.component';
import { HeaderComponent } from './header/header.component';
import { ToastrModule } from "ngx-toastr";
import { StatisticsComponent } from './statistics/statistics.component';
import { NgxChartsModule } from "@swimlane/ngx-charts";
import { JurisdictionsComponent } from './jurisdictions/jurisdictions.component';
import { DemoComponent } from './demo/demo/demo.component';

@NgModule({
  declarations: [
    AppComponent,
    DeclarationsListComponent,
    DeclarationComponent,
    AuthComponent,
    CreateDeclarationComponent,
    HeaderComponent,
    StatisticsComponent,
    JurisdictionsComponent,
    DemoComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ToastrModule.forRoot(),
    ReactiveFormsModule,
    NgxChartsModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
