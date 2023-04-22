import { Component } from '@angular/core';
import { Declaration } from "../models/declaration.model";
import { DeclarationsService } from "../services/declarations.service";
import { JurisdictionsService } from "../services/jurisdictions.service";
import { Jurisdiction } from "../models/jurisdiction.model";
import { Observable } from "rxjs";
import { filter, map } from "rxjs/operators";

@Component({
  selector: 'app-declarations-list',
  templateUrl: './declarations-list.component.html',
  styleUrls: ['./declarations-list.component.scss']
})
export class DeclarationsListComponent {
  declarations: Declaration[] = [];

  jurisdictionCodes$!: Observable<string[]>;

  constructor(private declarationsService: DeclarationsService,
              private jurisdictionService: JurisdictionsService) {}

  ngOnInit(): void {
    this.declarationsService
      .getDeclarations()
      .subscribe((declarations) => (this.declarations = declarations));

    this.jurisdictionCodes$ = this.jurisdictionService.jurisdictions$
      .pipe(
        filter(x => !!x),
        map(x => x!.map(j => j.code))
      );
  }

  getRandomWidth(minWidth: number, maxWidth: number): string {
    const width = Math.floor(Math.random() * (maxWidth - minWidth + 1) + minWidth);
    return `${width}%`;
  }

  calculateWidthFromNetMass(minWidth: number, maxWidth: number, netMass: number, maxNetMass: number): string {
    const normalizedWidth = ((netMass / maxNetMass) * (maxWidth - minWidth)) + minWidth;
    return `${normalizedWidth}%`;
  }
}
