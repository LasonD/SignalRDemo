import { Injectable } from '@angular/core';
import { catchError, of, Subject } from "rxjs";
import { AuthResult, LoginRequest, RegisterRequest, User } from "../../models/user.model";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { environment } from "../../../environments/environment";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private userKey = 'userData';
  public user: Subject<User> = new Subject<User>();

  constructor(private http: HttpClient) {
  }

  public login(loginData: LoginRequest) {
    return this.http.post<AuthResult>(`${environment.apiBaseUrl}/api/auth/login`, loginData)
      .pipe(
        map(this.handleAuthResponse.bind(this)),
        catchError(this.handleError.bind(this))
      );
  }

  public register(registerData: RegisterRequest) {
    return this.http.post<AuthResult>(`${environment.apiBaseUrl}/api/Auth/register`, registerData)
      .pipe(
        map(this.handleAuthResponse.bind(this)),
        catchError(this.handleError.bind(this))
      );
  }

  public autoLogin() {
    const authResult: AuthResult = JSON.parse(localStorage.getItem(this.userKey)!);

    if (!authResult) {
      this.user.next(null!);
      return;
    }

    const user = new User(
      authResult.userId,
      authResult.username,
      authResult.email,
      authResult.accessToken,
      authResult.expiresIn);

    if (!user || !user.token) {
      localStorage.removeItem(this.userKey);
    }

    this.user.next(user);
  }

  private handleAuthResponse(authResponse: AuthResult) {
    const user = new User(
      authResponse.userId,
      authResponse.username,
      authResponse.email,
      authResponse.accessToken,
      authResponse.expiresIn);

    localStorage.setItem(this.userKey, JSON.stringify(user));

    this.user.next(user);
  }

  private handleError(err: HttpErrorResponse) {
    prompt('Something went wrong...' + JSON.stringify(err));
    return of(null);
  }
}
