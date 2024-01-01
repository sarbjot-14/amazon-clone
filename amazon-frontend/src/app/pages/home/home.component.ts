import { Component, ComponentFactoryResolver } from '@angular/core';
import { HostListener } from '@angular/core';
import { EMPTY, Observable, filter, map, tap } from 'rxjs';
import { Product } from 'src/app/models/product';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  /*
  1. womens-jewellery
  3. mens-shirts
  4. tops
  5. furniture

  todays deals: heavily discounted

  6. skincare
  7. fragrances
  8. laptops
  9. smartphones


  deals under $25
  */
  public productDisplay1: string[] = [
    'womens-jewellery',
    'mens-shirts',
    'tops',
    'furniture',
  ];
  public productDisplay2: string[] = [
    'skincare',
    'fragrances',
    'laptops',
    'smartphones',
  ];
  public catsDisplay1: string[] = [];
  public smartphones: string[] = ['samsung', 'apple', 'oneplus', 'google'];
  public getScreenWidth: any;
  public getScreenHeight: any;
  public products$?: Observable<Product[]>;
  // public products2$: Observable<Product[]> | undefined;

  constructor(private productService: ProductsService) {}
  ngOnInit() {
    this.getScreenWidth = window.innerWidth;
    this.getScreenHeight = window.innerHeight;

    this.adjustDisplay();

    this.products$ = this.productService.getProducts();
  }

  @HostListener('window:resize', ['$event'])
  onWindowResize() {
    this.getScreenWidth = window.innerWidth;
    this.getScreenHeight = window.innerHeight;

    this.adjustDisplay();
  }

  adjustDisplay = () => {
    if (this.getScreenWidth > 1450) {
      this.catsDisplay1 = this.productDisplay1.slice(0, 4);
    } else {
      console.log('making it smaller !!!!');
      this.catsDisplay1 = this.productDisplay1.slice(0, 3);
    }
  };
}
