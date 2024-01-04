import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';
import { Product } from 'src/app/models/product';
import { ProductsService } from 'src/app/services/products.service';

import { AppStateInterface } from 'src/app/models/appState.interface';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent {
  constructor(
    private route: ActivatedRoute,
    private productService: ProductsService,
  ) {
   
  }
  cartProduct$?: Observable<any>;
  product$?: Observable<any>;
  quantityArr?: number[];

  selectedId?: string | null;
  //heroes = HEROES;

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

    this.product$?.subscribe((p) => {
      console.log('dispathcing ', p);
      
    });

    this.cartProduct$?.subscribe((ps) => {
      console.log('it is the p', ps[0]);
    });


  }
  addToCart(){
    this.product$?.subscribe(p=>{
    

    })

  }
}
