import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MainService } from '../app.service';

@Component({
  selector: 'app-starting-page',
  templateUrl: './starting-page.component.html',
  styleUrls: ['./starting-page.component.scss']
})
export class StartingPageComponent implements OnInit {

  constructor(private router: Router,
    private mainService: MainService) { }

  ngOnInit(): void {
  }

  onOpen(){
    console.log("onOpen")
    this.mainService.onOpen();
    this.router.navigateByUrl('main-page');
  }

}
