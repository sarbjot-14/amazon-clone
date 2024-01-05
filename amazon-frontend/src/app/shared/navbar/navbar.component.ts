import { Component } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Observable, map } from 'rxjs';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {
  cartItemCount$?: Observable<number>;
  constructor(private store: Store<{ items: Product[] }>) {
    this.cartItemCount$ = this.store.select('items').pipe(
      map((itemArr) => {
        return itemArr.reduce(
          (accum: number, item) => accum + (item?.number||0),
          0
        );
      })
    );
  }
}
