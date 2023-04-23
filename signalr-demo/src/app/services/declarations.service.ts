import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { Declaration } from "../models/declaration.model";
import { BehaviorSubject, tap } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class DeclarationsService {
  declarations$: BehaviorSubject<Declaration[] | null> = new BehaviorSubject<Declaration[] | null>(null);

  constructor(private http: HttpClient) {

  }

  public getDeclarations() {
    return this.http.get<Declaration[]>(`${environment.apiBaseUrl}/api/declarations`)
      .pipe(tap(declarations => {
        this.declarations$.next(declarations);
      }));
  }
}
