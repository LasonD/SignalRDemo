import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable, Subscription } from "rxjs";
import { Injectable, OnDestroy } from "@angular/core";;
import { AuthService } from "./auth.service";
import { User } from "../../models/user.model";
import { environment } from "../../../environments/environment";

@Injectable({providedIn: 'root'})
export class AuthInterceptorService implements HttpInterceptor, OnDestroy {
  baseUrlPlaceholder = '{baseUrl}';
  userSub: Subscription;
  user!: User;

  constructor(private authService: AuthService) {
    this.userSub = this.authService.user$
      .subscribe(user => {
        console.log('Got a user: ', user);
        this.user = user;
      });
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this?.user?.token;

    const newReq = req.clone({
      url: req.url.replace(this.baseUrlPlaceholder, environment.apiBaseUrl),
      headers: !!token ? req.headers.set('Authorization', `Bearer ${token}`) : null!,
    });

    return next.handle(newReq);
  }

  ngOnDestroy(): void {
    this.userSub.unsubscribe();
  }
}
