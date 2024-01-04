import { Component, Input } from '@angular/core';
import { Observable, map, tap } from 'rxjs';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-product-carousel',
  templateUrl: './product-carousel.component.html',
  styleUrls: ['./product-carousel.component.scss'],
})
export class ProductCarouselComponent {
  @Input()
  productsDisplay$?: Observable<Product[]>;

  @Input()
  title: string = '';

  productDeals$?: Observable<Product[]>;

  ngOnInit() {
    this.productDeals$ = this.productsDisplay$?.pipe(
      map((productArray) =>
        productArray.sort((a, b) => b.discount - a.discount)
      )
    );

    this.productDeals$?.pipe(tap((p) => console.log('wth', p))).subscribe();
  }
}
