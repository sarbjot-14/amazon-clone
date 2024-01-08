import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, combineLatest, map, switchMap, tap } from 'rxjs';
import { Product } from 'src/app/models/product';
import { ordersService } from 'src/app/services/order.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.scss',
})
export class CheckoutComponent {
  items$?: Observable<Product[]>;
  subtotal$?: Observable<number>;
  shipping: number = 9;
  regulatoryFees: number = 4.3;
  gst: number = 0.05;
  pst: number = 0.07;
  estimatedGst$?: Observable<number>;
  estimatedPst$?: Observable<number>;
  total$?: Observable<number>;

  constructor(
    private store: Store<{ items: Product[] }>,
    private ordersService: ordersService
  ) {
    this.items$ = store.select('items');
    this.subtotal$ = this.items$?.pipe(
      map((arr) =>
        arr.reduce((acc, item) => acc + item.price * item.number!, 0)
      )
    );

    this.estimatedGst$ = this.subtotal$?.pipe(
      map(
        (sub: number) => (sub + this.shipping + this.regulatoryFees) * this.gst
      )
    );
    this.estimatedPst$ = this.subtotal$?.pipe(
      map(
        (sub: number) => (sub + this.shipping + this.regulatoryFees) * this.pst
      )
    );

    this.total$ = combineLatest(
      this.subtotal$!,
      this.estimatedGst$!,
      this.estimatedPst$!
    ).pipe(
      map((expenseArr) => {
        return expenseArr[0] + expenseArr[1] + expenseArr[2];
      })
    );
  }

  placeOrder() {
    this.items$
      ?.pipe(
        map((items) => {
          let newItems = items.map((anItem) => {
            return {
              ...anItem,
              ProductId: anItem.id,
              Total: anItem.price,
              Quantity: anItem.number,
              ShippingCost: 12.5,
              Taxes: 30,
            };
          });
          return newItems;
        })
      )
      .subscribe((items) => {
        items.forEach((item) => {
          this.ordersService.createOrders(item).subscribe();
        });
      });
  }
}
