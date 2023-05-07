import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { BehaviorSubject, catchError, Subject, tap, throwError } from "rxjs";
import { Jurisdiction } from "../models/jurisdiction.model";

@Injectable({
  providedIn: 'root'
})
export class JurisdictionsService {
  jurisdictions$: Subject<Jurisdiction[] | null> = new BehaviorSubject<Jurisdiction[] | null>(null);
  jurisdictionUpdated$: Subject<Jurisdiction> = new Subject<Jurisdiction>();
  error$: Subject<any> = new Subject();

  constructor(private http: HttpClient) {
  }

  public getJurisdictions() {
    return this.http.get<Jurisdiction[]>(`${environment.apiBaseUrl}/api/jurisdictions`)
      .pipe(
        tap(result => this.jurisdictions$.next(result)),
        catchError((err) => {
          this.error$.next(err);
          return throwError(err);
        })
      );
  }

  public updateJurisdiction(jurisdictionCode: string, updatedJurisdiction: Jurisdiction) {
    return this.http.put<Jurisdiction>(`${environment.apiBaseUrl}/api/jurisdictions/${jurisdictionCode}`, updatedJurisdiction)
      .pipe(
        tap((jurisdiction) => {
          this.jurisdictionUpdated$.next(jurisdiction);
        }),
        catchError((err) => {
          this.error$.next(err);
          return throwError(err);
        })
      );
  }
}
