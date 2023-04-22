import { Component, Input, Output } from '@angular/core';
import { Declaration } from "../../models/declaration.model";
import { Subject } from "rxjs";

@Component({
  selector: 'app-declaration',
  templateUrl: './declaration.component.html',
  styleUrls: ['./declaration.component.scss'],
})
export class DeclarationComponent {
  @Input() declaration!: Declaration;
  @Input() jurisdictions!: string[];

  @Output() delete: Subject<Declaration> = new Subject<Declaration>();
  @Output() save: Subject<Declaration> = new Subject<Declaration>();
  @Output() toggleEdit: Subject<Declaration> = new Subject<Declaration>();
  @Output() cancelEdit: Subject<Declaration> = new Subject<Declaration>();

  editMode: boolean = false;

  toggleEditMode(): void {
    this.editMode = !this.editMode;
    this.toggleEdit.next(this.declaration);
  }

  onCancelEdit(): void {
    this.editMode = false;
    this.cancelEdit.next(this.declaration);
  }

  saveChanges(): void {
    this.toggleEditMode();
    this.save.next(this.declaration);
  }

  onDelete(): void {
    this.delete.next(this.declaration);
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
