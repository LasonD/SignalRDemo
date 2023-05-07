import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DeclarationsColorService {

  constructor() { }

  public getBackgroundColor(originalDisplayColor: string, opacity = 0.2): string {
    const color = originalDisplayColor;
    const rgba = this.colorToRGBA(color, opacity);
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
