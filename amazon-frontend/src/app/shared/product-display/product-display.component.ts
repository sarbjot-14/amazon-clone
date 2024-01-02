import { Component, Input } from '@angular/core';
import { Observable, map, take, tap } from 'rxjs';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-product-display',
  templateUrl: './product-display.component.html',
  styleUrls: ['./product-display.component.scss'],
})
export class ProductDisplayComponent {
  @Input()
  productsDisplay$?: Observable<Product[]>;

  @Input()
  productCategory: string | undefined;

  @Input()
  displayTitle: string | undefined;

  localDisplay$?: Observable<Product[]>;

  ngOnInit() {
    this.localDisplay$ = this.productsDisplay$?.pipe(
      map((p) => p.filter((prod) => prod.category == this.productCategory)),
      map((pArray) => pArray.slice(0, 4))
    );
  }
}
