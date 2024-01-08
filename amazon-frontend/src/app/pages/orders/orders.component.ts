import { Component } from '@angular/core';
import { Observable, forkJoin, switchMap, tap } from 'rxjs';
import { Product } from 'src/app/models/product';
import { ordersService } from 'src/app/services/order.service';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.scss',
})
export class OrdersComponent {
  orders$?: Observable<any>;
  today?: string;
  products?: Product[];
  arriving?:string; 

  constructor(
    private ordersService: ordersService,
    private productService: ProductsService
  ) {}

  ngOnInit() {
    this.today = new Date().toLocaleDateString('en-us', {
      weekday: 'long',
      month: 'short',
      day: 'numeric',
    });
    this.arriving = new Date((new Date()).getDate() +5).toLocaleDateString('en-us', {
      weekday: 'long',
      month: 'short',
      day: 'numeric',
    });
    this.orders$ = this.ordersService.getOrders();

    this.orders$.subscribe((orders) => {
      forkJoin(
        orders.map((order: any) =>{
     
          return this.productService.getProductById(order.productId)
        }
          
        )
      ).subscribe((p:any)=>{
        this.products = p
      })
    });
  }
}
