import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { SharedModule } from './shared/shared.module.ts/shared.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './pages/home/home.component';
import { SearchPageComponent } from './pages/search-page/search-page.component';
import { ProductDisplayComponent } from './shared/product-display/product-display.component';
import { FooterComponent } from './shared/footer/footer.component';
import { ProductCarouselComponent } from './shared/product-carousel/product-carousel.component';
import { ProductDetailsComponent } from './pages/product-details/product-details.component';
import { CartComponent } from './pages/cart/cart.component';

import { StoreModule } from '@ngrx/store';
import { itemsReducer } from './store/items.reducer';
import { FormsModule } from '@angular/forms';
import { CartItemComponent } from './shared/cart-item/cart-item.component';
import { CheckoutComponent } from './pages/checkout/checkout.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SearchPageComponent,
    ProductDisplayComponent,
    FooterComponent,
    ProductCarouselComponent,
    ProductDetailsComponent,
    CartComponent,
    CartItemComponent,
    CheckoutComponent,
  ],
  imports: [
    FormsModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    BrowserAnimationsModule,
    StoreModule.forRoot({ items: itemsReducer })

  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
