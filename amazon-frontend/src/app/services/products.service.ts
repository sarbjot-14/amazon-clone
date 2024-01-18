import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../models/product';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  private productsUrl = 'http://acme.com/api/products';
  private productsUrlDev = 'http://localhost:5244';
  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(environment.productsUrl);
  }

  getProductById(id: number): Observable<Product> {
    console.log('making the call');
    return this.http.get<Product>(environment.productsUrl + '/' + id);
  }
}
