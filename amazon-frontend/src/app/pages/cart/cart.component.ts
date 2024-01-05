import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, map, tap } from 'rxjs';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
})
export class CartComponent {
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
