import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subscriber } from '../Models/Subscriber';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  private baseUrl=""
  constructor(private http:HttpClient) { }

  //Add user
  //need to put in url
  AddSubscriber(newSubscriber:Subscriber):Observable<any>{
    return this.http.post(`${this.baseUrl}/subscriber`,newSubscriber)
  }
}
