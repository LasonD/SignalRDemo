import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, of, Subject, throwError } from "rxjs";
import { AuthResult, LoginRequest, RegisterRequest, User } from "../../models/user.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../../environments/environment";
import { map } from "rxjs/operators";
import { NotificationService } from "../../services/notifications.service";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private userKey = 'userData';
  public user$: Subject<{ user: User, shouldRedirect: boolean }> = new Subject<{ user: User, shouldRedirect: boolean }>();

  constructor(private http: HttpClient,
              private notificationsService: NotificationService) {
  }

  public login(loginData: LoginRequest) {
    return this.http.post<AuthResult>(`${environment.apiBaseUrl}/api/Auth/login`, loginData)
      .pipe(
        map(this.handleAuthResponse.bind(this)),
        catchError((err) => {
          this.notificationsService.showError(err);
          return throwError(err);
        })
      );
  }

  public register(registerData: RegisterRequest) {
    return this.http.post<AuthResult>(`${environment.apiBaseUrl}/api/Auth/register`, registerData)
      .pipe(
        map(this.handleAuthResponse.bind(this)),
        catchError((err) => {
          this.notificationsService.showError(err);
          return throwError(err);
        })
      );
  }

  public autoLogin() {
    console.log('Auto login start');
    const authResult: AuthResult = JSON.parse(localStorage.getItem(this.userKey)!);

    if (!authResult) {
      this.user$.next(null!);
      return;
    }

    const user = new User(
      authResult.userId,
      authResult.username,
      authResult.email,
      authResult.accessToken,
      authResult.expiresIn);

    console.log('Auto login token: ', user.token);

    if (!user || !user.token) {
      localStorage.removeItem(this.userKey);
    }

    this.user$.next({ user, shouldRedirect: false });
  }

  private handleAuthResponse(authResponse: AuthResult) {
    const user = new User(
      authResponse.userId,
      authResponse.username,
      authResponse.email,
      authResponse.accessToken,
      authResponse.expiresIn);

    localStorage.setItem(this.userKey, JSON.stringify(authResponse));

    this.user$.next({ user, shouldRedirect: true });
  }

  public logOut() {
    localStorage.removeItem(this.userKey);
    this.user$.next(null!);
  }
}
