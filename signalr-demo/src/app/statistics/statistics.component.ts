import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from "rxjs";
import { DeclarationsService } from "../services/declarations.service";
import { filter } from "rxjs/operators";
import { DeclarationsColorService } from "../services/declarations-color.service";

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.scss']
})
export class StatisticsComponent implements OnInit, OnDestroy {
  destroyed$: Subject<boolean> = new Subject<boolean>();
  view: [number, number] = [1000, 600];

  declarationColors: { [jurisdiction: string]: string } = {};
  declarationStats!: DeclarationStats;

  customColorFn!: (key: string) => string;
  chartData!: any;

  constructor(private declarationsService: DeclarationsService,
              private colorService: DeclarationsColorService) {
  }

  public ngOnInit() {
    const declarations$ = this.declarationsService.getDeclarations()
      .pipe(
        takeUntil(this.destroyed$),
        filter((d) => !!d),
      );

    declarations$
      .pipe(takeUntil(this.destroyed$))
      .subscribe((declarations) => {
        this.declarationStats = declarations.reduce((result: DeclarationStats, d) => {
          const category = d.jurisdiction;
          if (!result[category]) {
            result[category] = { color: this.colorService.getBackgroundColor(d.displayColor, 0.7), count: 0 };
          }
          result[category].count++;
          return result;
        }, {});

        this.chartData = Object.keys(this.declarationStats).map((key) => {
          const stat = this.declarationStats[key];
          this.declarationColors[key] = stat?.color;
          return {
            name: key,
            value: stat?.count
          };
        })
      });

    this.customColorFn = ((key: string) => this.declarationColors[key] ?? 'white').bind(this);
  }

  public ngOnDestroy() {
    this.destroyed$.next(true);
  }
}

export interface DeclarationStats {
  [jurisdiction: string]: { color: string, count: number },
}
