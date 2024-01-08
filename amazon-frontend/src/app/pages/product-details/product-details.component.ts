import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';
import { Product } from 'src/app/models/product';
import { ProductsService } from 'src/app/services/products.service';

import { AppStateInterface } from 'src/app/models/appState.interface';
import { Store } from '@ngrx/store';
import { add } from 'src/app/store/items.actions';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent {
  quantitySelected: any = 1;
  constructor(
    private route: ActivatedRoute,
    private productService: ProductsService,
    private store: Store<{ items: Product[] }>
  ) {}

  product$?: Observable<any>;
  quantityArr?: number[];

  selectedId?: string | null;
  stockStatus?: Observable<string> ;

  ngOnInit() {
    this.selectedId = this.route.snapshot.paramMap.get('id');
    if (this.selectedId) {
      this.product$ = this.productService
        .getProductById(parseInt(this.selectedId))
        .pipe(
          map((p) => {
            return {
              ...p,
              rating: Math.round(p.rating),
              empty: 5 - Math.round(p.rating),
            };
          })
        );
    }

    this.product$
      ?.pipe(map((p) => Array.from(Array(p.quantity + 1).keys())))
      .subscribe((arr) => {
        this.quantityArr = arr.slice(1);
      });

      this.stockStatus = this.product$?.pipe(map(prod=>{
        console.log("should have worked")
          if (prod.quantity == 0) {
            return 'Temporarily Out Of Stock';
          } else if (prod.quantity < 11) {
            return `Only ${prod.quantity} left in stock.`;
          } else {
            return 'In Stock';
          }
        }))
  }
  addToCart() {
    this.product$?.subscribe((p) => {
      p.number = parseInt(this.quantitySelected);

      this.store.dispatch(add({ item: p }));
    });
  }


}
