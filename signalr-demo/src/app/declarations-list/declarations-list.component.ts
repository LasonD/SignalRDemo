import { Component } from '@angular/core';
import { Declaration } from "../models/declaration.model";
import { DeclarationsService } from "../services/declarations.service";

@Component({
  selector: 'app-declarations-list',
  templateUrl: './declarations-list.component.html',
  styleUrls: ['./declarations-list.component.scss']
})
export class DeclarationsListComponent {
  declarations: Declaration[] = [];

  constructor(private declarationsService: DeclarationsService) {}

  ngOnInit(): void {
    this.declarationsService
      .getDeclarations()
      .subscribe((declarations) => (this.declarations = declarations));
  }

  getRandomWidth(minWidth: number, maxWidth: number): string {
    const width = Math.floor(Math.random() * (maxWidth - minWidth + 1) + minWidth);
    return `${width}%`;
  }
}
