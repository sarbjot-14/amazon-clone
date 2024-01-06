import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, map } from 'rxjs';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.scss'
})
export class CheckoutComponent {
  items$?: Observable<Product[]>;
  subtotal$?: Observable<number>;


  constructor(private store: Store<{ items: Product[] }>) {
    this.items$ = store.select('items');
    this.subtotal$ = this.items$?.pipe(
      map((arr) =>
        arr.reduce((acc, item) => acc + item.price * item.number!, 0)
      )
    );

  }
}
