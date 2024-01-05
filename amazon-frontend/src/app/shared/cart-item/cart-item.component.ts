import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Product } from 'src/app/models/product';
import { deleteItem, update } from 'src/app/store/items.actions';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrl: './cart-item.component.scss',
})
export class CartItemComponent {
  constructor(private store: Store<{ items: Product[] }>) {}
  @Input()
  item?: Product;

  quantitySelected?: number;

  quantities?: number[];

  ngOnInit() {
    this.quantities = Array.from(Array((this.item?.quantity || 0) + 1).keys()).slice(1);
    this.quantitySelected = this.item?.number;
  }

  onChange() {
    this.store.dispatch(
      update({ id: this.item?.id!, number: this.quantitySelected! })
    );
  }

  onDelete(){
    this.store.dispatch(
      deleteItem({ id: this.item?.id!})
    );
  }
}
