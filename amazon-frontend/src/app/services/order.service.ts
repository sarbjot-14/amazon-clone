import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../models/product';
import { Observable, debounce } from 'rxjs';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root',
})
export class ordersService {
  private ordersUrl = 'http://acme.com/api/orders';
  private ordersUrlDev = 'http://localhost:5244';
  constructor(private http: HttpClient) {}

  createOrders(item: any): Observable<any> {
    return this.http.post<any>(environment.ordersUrl, item);
  }

  getOrders() {
    console.log('getting all the orders');
    return this.http.get(environment.ordersUrl);
  }
}
