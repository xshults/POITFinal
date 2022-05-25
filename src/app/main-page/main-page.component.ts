import { Component, OnInit } from '@angular/core';
import { MatSliderChange } from '@angular/material/slider';
import { Router } from '@angular/router';
import { MainService } from '../app.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {

  public multiplier:number = 1;
  public isPrinting:boolean = false;
  public isAllGraph:boolean = false;
  constructor(private router: Router,
    private mainService: MainService) { }

  ngOnInit(): void {

  }

  onStart(){
    this.isPrinting = true;
  }

  onStop(){
    this.isPrinting = false;
  }

  onClose(){
    this.isPrinting = false;
    this.router.navigateByUrl('');
  }


  onInputChange(event: MatSliderChange) {
    console.log("This is emitted as the thumb slides");
    console.log(event.value);
    if(event.value)
      this.multiplier = event.value;
    this.mainService.updateMultiplier(this.multiplier)
  }

  onShowAll(){
    this.isAllGraph = !this.isAllGraph;
  }


}
