import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { BehaviorSubject, Subject, tap } from "rxjs";
import { Jurisdiction } from "../models/jurisdiction.model";

@Injectable({
  providedIn: 'root'
})
export class JurisdictionsService {
  jurisdictions$: Subject<Jurisdiction[]> = new BehaviorSubject(null! as Jurisdiction[]);

  constructor(private http: HttpClient) {
  }

  public getJurisdictions() {
    return this.http.get<Jurisdiction[]>(`${environment.apiBaseUrl}/api/jurisdictions`)
      .pipe(tap(result => this.jurisdictions$.next(result)));
  }
}
