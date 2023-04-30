import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, Subject, throwError } from "rxjs";
import { AuthResult, LoginRequest, RegisterRequest, User, UserModel } from "../../models/user.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../../environments/environment";
import { map } from "rxjs/operators";
import { NotificationService } from "../../services/notifications.service";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private userKey = 'userData';
  public user$: Subject<{ user: User, shouldRedirect: boolean }> = new BehaviorSubject<{ user: User, shouldRedirect: boolean }>(null!);

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
    const userData: UserModel = JSON.parse(localStorage.getItem(this.userKey)!);

    if (!userData) {
      this.user$.next(null!);
      return;
    }

    const user = new User(
      userData.userId,
      userData.username,
      userData.email,
      userData._token!,
      null,
      userData.expirationDate);

    if (!user || !user.token) {
      localStorage.removeItem(this.userKey);
      return;
    }

    this.user$.next({ user, shouldRedirect: true });
  }

  private handleAuthResponse(authResponse: AuthResult) {
    const user = new User(
      authResponse.userId,
      authResponse.username,
      authResponse.email,
      authResponse.accessToken,
      authResponse.expiresIn);

    localStorage.setItem(this.userKey, JSON.stringify(user));

    this.user$.next({ user, shouldRedirect: true });
  }

  public logOut() {
    localStorage.removeItem(this.userKey);
    this.user$.next(null!);
  }
}
