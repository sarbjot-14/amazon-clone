import { Component } from '@angular/core';
import { Observable, forkJoin, map, switchMap, tap } from 'rxjs';
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
  products?: Observable<any>;
  arriving?: string;
  service?: ordersService;

  constructor(
    private ordersService: ordersService,
    private productService: ProductsService
  ) {
    this.service =  ordersService;

  }

  ngOnInit() {
    console.log('on init is running !!!!');
    this.today = new Date().toLocaleDateString('en-us', {
      weekday: 'long',
      month: 'short',
      day: 'numeric',
    });
    this.arriving = new Date(new Date().getDate() + 5).toLocaleDateString(
      'en-us',
      {
        weekday: 'long',
        month: 'short',
        day: 'numeric',
      }
    );
    this.products = this.service?.getOrders().pipe(
      switchMap((orders: any, i) => {
        console.log('updating products list ', orders);

        return forkJoin(
          orders.map((order: any) => {
            return this.productService.getProductById(order.productId);
          })
        );
      })
    );

  }

}
