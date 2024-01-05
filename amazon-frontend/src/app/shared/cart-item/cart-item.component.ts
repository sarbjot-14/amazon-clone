import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrl: './cart-item.component.scss',
})
export class CartItemComponent {
  constructor(   private store: Store<{ items: Product[] }>){}
  @Input()
  item?: Product;

  quantitySelected?: number ;

  quantities?: number[];



  ngOnInit() {
    this.quantities = Array.from(Array((this.item?.quantity || 0) + 1).keys());
    this.quantitySelected =  this.item?.number ;
  }

  onChange(){
    // event = {}
    // console.log(event)
    //this.store.dispatch(add({ item: p }));


  }
}
