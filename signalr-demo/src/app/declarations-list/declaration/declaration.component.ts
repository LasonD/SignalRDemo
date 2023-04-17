import { Component, Input } from '@angular/core';
import { Declaration } from "../../models/declaration.model";

@Component({
  selector: 'app-declaration',
  templateUrl: './declaration.component.html',
  styleUrls: ['./declaration.component.scss']
})
export class DeclarationComponent {
  @Input() declaration!: Declaration;
  editMode: boolean = false;

  toggleEditMode(): void {
    this.editMode = !this.editMode;
  }

  saveDeclaration(): void {
    // Implement your save functionality here
    this.toggleEditMode();
  }

  getTransparentBackgroundColor(): string {
    const color = this.declaration.displayColor;
    const opacity = 0.2; // Adjust the value between 0 and 1 to change the opacity.
    const rgbaColor = color.replace('rgb', 'rgba').replace(')', `, ${opacity})`);
    return rgbaColor;
  }
}
