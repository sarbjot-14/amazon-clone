import { createFeatureSelector, createSelector } from '@ngrx/store';
import { Product } from '../models/product';

export const selectProductsFeature =
  createFeatureSelector<ReadonlyArray<Product>>('products');

export const selectProducts = createSelector(
  selectProductsFeature,

  (products) => {
    return products;
  }
);
