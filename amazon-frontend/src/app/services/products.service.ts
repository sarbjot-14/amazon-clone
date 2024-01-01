import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  private productsUrl = 'http://acme.com/api/products';
  private productsUrlDev = 'http://localhost:5244';
  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.productsUrl);
  }
}
