import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../models/product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ordersService {
  private ordersUrl = 'http://acme.com/api/orders';
  private ordersUrlDev = 'http://localhost:5244';
  constructor(private http: HttpClient) {}

  createOrders(item: any): void {
    console.log('creating orders');
    let result = this.http.post<any>(this.ordersUrl, item);
    result.subscribe((okay) => {
      console.log('result is ', okay);
    });
  }
}
