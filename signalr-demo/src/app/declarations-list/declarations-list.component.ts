import { Component } from '@angular/core';
import { Declaration } from "../models/declaration.model";
import { DeclarationsService } from "../services/declarations.service";
import { JurisdictionsService } from "../services/jurisdictions.service";
import { Observable } from "rxjs";
import { filter, map } from "rxjs/operators";
import { DeclarationsSignalService } from "../services/declarationsSignal.service";

@Component({
  selector: 'app-declarations-list',
  templateUrl: './declarations-list.component.html',
  styleUrls: ['./declarations-list.component.scss']
})
export class DeclarationsListComponent {
  declarations: Declaration[] = [];

  jurisdictionCodes$!: Observable<string[]>;

  constructor(private declarationsService: DeclarationsService,
              private jurisdictionService: JurisdictionsService,
              private declarationSignalService: DeclarationsSignalService) {}

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

  onDeclarationSave(declaration: Declaration) {
    this.declarationsService.updateDeclaration(declaration.id, declaration)
      .subscribe();
  }

  onDeclarationDelete(declaration: Declaration) {
    this.declarationsService.deleteDeclaration(declaration.id)
      .subscribe();
  }

  onToggleEdit(declaration: Declaration) {
    this.declarationSignalService.declarationEditToggled(declaration.id);
  }

  onCancelEdit(declaration: Declaration) {
    this.declarationSignalService.declarationEditCancelled(declaration.id);
  }
}
