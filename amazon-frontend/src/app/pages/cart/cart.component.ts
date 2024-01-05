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
  //quantitySelected

  itemss: Product[] = [
    {
      category: 'mens-shirts',
      company: 'Vintage Apparel',
      description:
        'Many store is creating new designs and trend every month and every year. Daraz.pk have a beautiful range of men fashion Companys',
      discount: 12.76,

      id: 859,
      name: 'half sleeves T shirts',
      price: 23,
      quantity: 1,
      rating: 4,
      thumbnail:
        'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSFLB01pUbTIDvXIq7Bu3TMKTA28St4TGbAV1eAxFueCwo6U9KcnstB7O4H1CEFYIX_214&usqp=CAU',
    },
    {
      category: 'mens-shirts',
      company: 'Vintage Apparel',
      description:
        'Many store is creating new designs and trend every month and every year. Daraz.pk have a beautiful range of men fashion Companys',
      discount: 12.76,

      id: 859,
      name: 'half sleeves T shirts',
      price: 23,
      quantity: 4,
      rating: 4,
      thumbnail:
        'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSFLB01pUbTIDvXIq7Bu3TMKTA28St4TGbAV1eAxFueCwo6U9KcnstB7O4H1CEFYIX_214&usqp=CAU',
    },
  ];

  constructor(private store: Store<{ items: Product[] }>) {
    this.items$ = store.select('items');
    this.subtotal$ = this.items$?.pipe(map(arr=> arr.reduce((acc,item)=>acc+item.price,0)),tap((n) => console.log('woo', n)))
    // store.select('items').subscribe((parr) => {
    //   console.log('here it is ', parr);
    // });
  }
  ngOnit() {
    //this.items$?.pipe(tap((n) => console.log('woo', n))).subscribe();
  }
}
