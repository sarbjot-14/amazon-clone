import { createReducer, on } from '@ngrx/store';

import * as ProductActions from './product.actions';

import { Product } from '../models/product';

export const initialState: ReadonlyArray<Product> = [];

export const reducer = createReducer(
  initialState,
  on(ProductActions.add, (state, data) => {
    return [...state, data.product];
  })
);
