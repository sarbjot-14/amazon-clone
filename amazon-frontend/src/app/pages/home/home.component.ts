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
  public productDisplay1: any[] = [
    { cat: 'womens-jewellery', title: 'Browse Jewellery for Her' },
    { cat: 'mens-shirts', title: 'Great Deals on Mens Shirts' },
    { cat: 'tops', title: 'Trendy Tops' },
    { cat: 'furniture', title: 'Complete your Dream Space' },
  ];
  public productDisplay2: any[] = [
    { cat: 'skincare', title: 'Get the Ultimate Glow Up' },
    { cat: 'fragrances', title: 'Scents for Everyone' },
    { cat: 'laptops', title: 'Power your Workday with Powerful Laptops' },
    { cat: 'smartphones', title: 'Upgrade your Smartphone' },
  ];
  public catsDisplay1: any[] = [];
  public catsDisplay2: any[] = [];

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
      this.catsDisplay2 = this.productDisplay2.slice(0, 4);
    } else {
      this.catsDisplay1 = this.productDisplay1.slice(0, 3);
      this.catsDisplay2 = this.productDisplay2.slice(0, 3);
    }
  };
}
