import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { Declaration } from "../models/declaration.model";
import { BehaviorSubject, catchError, Subject, tap, throwError } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class DeclarationsService {
  declarations$: BehaviorSubject<Declaration[] | null> = new BehaviorSubject<Declaration[] | null>(null);
  declarationUpdated$: Subject<Declaration> = new Subject<Declaration>();
  declarationCreated$: Subject<Declaration> = new Subject<Declaration>();
  declarationDeleted$: Subject<Declaration> = new Subject<Declaration>();

  error$: Subject<any> = new Subject();

  constructor(private http: HttpClient) {
  }

  public getDeclarations() {
    return this.http.get<Declaration[]>(`${environment.apiBaseUrl}/api/declarations`)
      .pipe(
        tap(declarations => {
          this.declarations$.next(declarations);
        }),
        catchError((err) => {
          this.error$.next(err);
          return throwError(err);
        })
      );
  }

  public createDeclaration(newDeclaration: Declaration) {
    return this.http.post<Declaration>(`${environment.apiBaseUrl}/api/declarations`, newDeclaration)
      .pipe(
        tap(declaration => {
          this.declarationCreated$.next(declaration);
        }),
        catchError((err) => {
          this.error$.next(err);
          return throwError(err);
        })
      );
  }

  public updateDeclaration(id: string, updatedDeclaration: Declaration) {
    return this.http.put<Declaration>(`${environment.apiBaseUrl}/api/declarations/${id}`, updatedDeclaration)
      .pipe(
        tap(declaration => {
          this.declarationUpdated$.next(declaration);
        }),
        catchError((err) => {
          this.error$.next(err);
          return throwError(err);
        })
      );
  }

  public deleteDeclaration(id: string) {
    return this.http.delete<Declaration>(`${environment.apiBaseUrl}/api/declarations/${id}`)
      .pipe(
        tap(declaration => {
          this.declarationDeleted$.next(declaration);
        }),
        catchError((err) => {
          this.error$.next(err);
          return throwError(err);
        })
      );
  }
}
