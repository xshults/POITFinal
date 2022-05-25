import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";

import 'rxjs/Rx';
@Injectable()
export class  MainService {

  url: string = "https://localhost:7113/api/Main/";
  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }
  constructor(private client: HttpClient) { }

  onOpen(){
    return this.client.get<any>(this.url + "onopen").subscribe((data)=> console.log(data))
  }

  getValues(){
    let item: {hum:number,temp:number};
    return this.client.get<any>(this.url + "getvalue")
  }

  saveToDb(){
    this.client.get<any>(this.url + "savedb")
  }

  updateMultiplier(multiplier:number){
    console.log(multiplier)
    this.client.post<any>(this.url + 'multiplier',{data:multiplier.toString()},this.httpOptions).subscribe();
  }

  getAll(){
    return this.client.get<any>(this.url + "getall")
  }
}
