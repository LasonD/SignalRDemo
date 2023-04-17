import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { Declaration } from "../models/declaration.model";
import { of } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class DeclarationsService {
  private testDeclarations: Declaration[] = [
    {
      id: "declarationId1",
      declarantId: "declarantId1",
      declarantEmail: "test1@gmail.com",
      description: "Test declaration 1",
      displayColor: "blue",
      jurisdiction: "GB",
      netMass: 80,
    },
    {
      id: "declarationId2",
      declarantId: "declarantId2",
      declarantEmail: "test2@gmail.com",
      description: "Test declaration 2",
      displayColor: "yellow",
      jurisdiction: "BE",
      netMass: 80,
    },
    {
      id: "declarationId3",
      declarantId: "declarantId3",
      declarantEmail: "test4@gmail.com",
      description: "Test declaration 3",
      displayColor: "blue",
      jurisdiction: "GB",
      netMass: 50,
    },
    {
      id: "declarationId3",
      declarantId: "declarantId3",
      declarantEmail: "test4@gmail.com",
      description: "Test declaration 3",
      displayColor: "blue",
      jurisdiction: "GB",
      netMass: 100,
    },
    {
      id: "declarationId3",
      declarantId: "declarantId3",
      declarantEmail: "test4@gmail.com",
      description: "Test declaration 3",
      displayColor: "orange",
      jurisdiction: "GB",
      netMass: 50,
    },
    {
      id: "declarationId3",
      declarantId: "declarantId3",
      declarantEmail: "test4@gmail.com",
      description: "Test declaration 3",
      displayColor: "blue",
      jurisdiction: "GB",
      netMass: 120,
    },
    {
      id: "declarationId3",
      declarantId: "declarantId3",
      declarantEmail: "test4@gmail.com",
      description: "Test declaration 3",
      displayColor: "green",
      jurisdiction: "GB",
      netMass: 30,
    },
    {
      id: "declarationId3",
      declarantId: "declarantId3",
      declarantEmail: "test4@gmail.com",
      description: "Test declaration 3",
      displayColor: "red",
      jurisdiction: "GB",
      netMass: 80,
    }
  ];

  constructor(private http: HttpClient) {

  }

  public getDeclarations() {
    return of(this.testDeclarations);

    return this.http.get<Declaration[]>(`${environment.apiBaseUrl}/declarations`);
  }
}
