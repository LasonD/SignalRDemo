import { Component, Input } from '@angular/core';
import { Declaration } from "../../models/declaration.model";

@Component({
  selector: 'app-declaration',
  templateUrl: './declaration.component.html',
  styleUrls: ['./declaration.component.scss'],
})
export class DeclarationComponent {
  @Input() declaration!: Declaration;
  @Input() jurisdictions: string[] = ['GB', 'BE', 'NL'];
  editMode: boolean = false;

  toggleEditMode(): void {
    this.editMode = !this.editMode;
  }

  cancelEdit(): void {
    this.editMode = false;
  }

  saveChanges(): void {
    // Implement your save functionality here
    this.toggleEditMode();
  }

  getBackgroundColor(): string {
    const color = this.declaration.displayColor;
    const rgba = this.colorToRGBA(color, 0.2);
    return rgba;
  }

  colorToRGBA(color: string, opacity: number): string {
    const tempElement = document.createElement('div');
    tempElement.style.backgroundColor = color;
    document.body.appendChild(tempElement);
    const style = getComputedStyle(tempElement);
    const rgb = style.backgroundColor;
    document.body.removeChild(tempElement);

    const regex = /^rgb\((\d+),\s*(\d+),\s*(\d+)\)$/.exec(rgb);
    if (regex) {
      const r = parseInt(regex[1]);
      const g = parseInt(regex[2]);
      const b = parseInt(regex[3]);
      return `rgba(${r}, ${g}, ${b}, ${opacity})`;
    }
    return color;
  }
}
