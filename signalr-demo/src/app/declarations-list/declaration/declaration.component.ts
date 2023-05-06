import { Component, Input, OnDestroy, Output } from '@angular/core';
import { Declaration, DeclarationChange } from "../../models/declaration.model";
import { distinctUntilChanged, Observable, Subject, takeUntil } from "rxjs";
import { FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'app-declaration',
  templateUrl: './declaration.component.html',
  styleUrls: ['./declaration.component.scss'],
})
export class DeclarationComponent implements OnDestroy {
  destroyed$: Subject<boolean> = new Subject<boolean>();

  @Input() declaration!: Declaration;
  @Input() jurisdictions!: string[];
  @Input() isLocked: boolean = false;
  @Input() editMode: boolean = false;
  @Input() declarationChangesInput$!: Observable<DeclarationChange>;

  @Output() delete: Subject<Declaration> = new Subject<Declaration>();
  @Output() save: Subject<Declaration> = new Subject<Declaration>();
  @Output() toggleEdit: Subject<Declaration> = new Subject<Declaration>();
  @Output() cancelEdit: Subject<Declaration> = new Subject<Declaration>();

  @Output() declarationChangesOutput: Subject<DeclarationChange> = new Subject<DeclarationChange>();

  declarationForm: FormGroup = null!;

  ngOnInit() {
    this.declarationForm = new FormGroup({
      jurisdiction: new FormControl(this.declaration.jurisdiction, Validators.required),
      description: new FormControl(this.declaration.description),
      netMass: new FormControl(this.declaration.netMass, Validators.min(0)),
      declarantEmail: new FormControl(this.declaration.declarantEmail, [Validators.required, Validators.email])
    });

    const keys = ['jurisdiction', 'description', 'netMass'];

    for (const key of keys) {
      this.declarationForm.get(key)!.valueChanges
        .pipe(
          takeUntil(this.destroyed$),
          distinctUntilChanged(),
        )
        .subscribe((value) => {
          const change = {
            id: this.declaration.id, changes: {
              [key]: value
            }
          };
          this.declarationChangesOutput.next(change);
        });

      this.declarationChangesInput$
        .pipe(takeUntil(this.destroyed$))
        .subscribe((change) => {
          if (!this.isLocked || !change || !change.id || change.id !== this.declaration.id || !change.changes) return;

          const changes = change.changes;

          for (const key of Object.keys(changes)) {
            const control = this.declarationForm.get(key);
            if (!control) return;
            const newValue = changes[key];
            control.setValue(newValue);
          }
        });
    }
  }

  toggleEditMode(): void {
    this.editMode = !this.editMode;
    this.toggleEdit.next(this.declaration);
    if (this.editMode) {
      this.declarationForm.patchValue({...this.declaration});
    }
  }

  onCancelEdit(): void {
    this.editMode = false;
    this.cancelEdit.next(this.declaration);
  }

  saveChanges(): void {
    this.toggleEditMode();

    if (!this.declarationForm.valid) {
      return;
    }

    const editedDeclaration: Declaration = {...this.declaration, ...this.declarationForm.value};
    this.save.next(editedDeclaration);
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

  public ngOnDestroy() {
    this.destroyed$.next(true);
  }
}
