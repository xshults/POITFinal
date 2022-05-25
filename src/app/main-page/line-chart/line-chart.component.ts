import { formatDate } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatSliderChange } from '@angular/material/slider';
import { BrowserModule } from '@angular/platform-browser';
import { NgxChartsModule, ScaleType } from '@swimlane/ngx-charts';
import { tap } from 'rxjs/operators';
import { MainService } from 'src/app/app.service';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.scss']
})
export class LineChartComponent implements OnInit {

  items: any[] = [];
  multi: any[] = [
    {
      name: "Humidity",
      series: [
      ],
    },
    {
      name: "Temperature",
      series: []
    }
  ];
  view: [number, number] = [1000, 500];

  // options
  legend: boolean = true;
  showLabels: boolean = true;
  animations: boolean = true;
  xAxis: boolean = true;
  yAxis: boolean = true;
  showYAxisLabel: boolean = true;
  showXAxisLabel: boolean = true;
  xAxisLabel: string = 'Value';
  yAxisLabel: string = 'Time';
  timeline: boolean = true;

  colorScheme = {
    name: 'myScheme',
    selectable: true,
    group: ScaleType.Ordinal,
    domain: ['#5AA454', '#E44D25', '#CFC0BB', '#7aa3e5', '#a8385d', '#aae3f5']
  };
  public tempForDisplay: number = 0;

  @Input() isPrinting!: boolean;

  constructor(private mainService: MainService) { }

  ngOnInit() {
    setInterval(async () =>
    {
      if(this.isPrinting)
      {
        this.mainService.getValues().pipe(
          tap((item) => {
            let currentDate = new Date();
            const cValue = formatDate(currentDate, 'h:mm:ss a', 'en-US');

            this.multi[0].series.push({name:cValue, value:item.hum});
            this.multi[1].series.push({name: cValue, value:item.temp});
            this.items.push(item)
            this.tempForDisplay = item.temp
            console.log(this.tempForDisplay)
            this.multi = [...this.multi]
          })
        ).subscribe()
      }
    },2000)
  }

  onSelect(data: any): void {
    console.log('Item clicked', JSON.parse(JSON.stringify(data)));
  }

  onActivate(data: any): void {
    console.log('Activate', JSON.parse(JSON.stringify(data)));
  }

  onDeactivate(data: any): void {
    console.log('Deactivate', JSON.parse(JSON.stringify(data)));
  }


}
