import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Clock} from './clock.model';


@Injectable({
  providedIn: 'root'
})
export class DataService {
 apiUrl = 'https://localhost:44385/clock';
  constructor(private Http: HttpClient) { }

  getClock()
  {
    console.log('test' + this.Http.get<Clock>(this.apiUrl));
    return this.Http.get<Clock>(this.apiUrl);
  }
}
