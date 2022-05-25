import { Component, OnInit } from '@angular/core';
import { ScaleType } from '@swimlane/ngx-charts';
import { tap } from 'rxjs/operators';
import { MainService } from '../app.service';

@Component({
  selector: 'app-show-all',
  templateUrl: './show-all.component.html',
  styleUrls: ['./show-all.component.scss']
})
export class ShowAllComponent implements OnInit {

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

  constructor(private mainService: MainService) { }

  ngOnInit(): void {
    setInterval(async () =>
    {
      this.mainService.getAll().pipe(
        tap((item) => {
          console.log( item)
          item.forEach(
            (element:any) => {
              console.log(element)
              this.multi[0].series.push({name: this.multi[0].series.length, value:element.hum});
              this.multi[1].series.push({name: this.multi[1].series.length, value:element.temp});
            }
          )
          this.multi = [...this.multi]
        })
      ).subscribe()
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
