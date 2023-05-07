import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Declaration } from "../models/declaration.model";
import { environment } from "../../environments/environment";
import { catchError, throwError } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class DemoService {

  constructor(private http: HttpClient) { }

  public createDemoDeclarations(count: number, intervalMs: number) {
    return this.http.post<Declaration>(`${environment.apiBaseUrl}/api/demo/declarations?count=${count}&intervalMs=${intervalMs}`, null)
      .pipe(
        catchError((err) => {
          return throwError(err);
        })
      );
  }

  public deleteDemoDeclarations(count: number, intervalMs: number) {
    return this.http.delete<Declaration>(`${environment.apiBaseUrl}/api/demo/declarations?count=${count}&intervalMs=${intervalMs}`)
      .pipe(
        catchError((err) => {
          return throwError(err);
        })
      );
  }
}
