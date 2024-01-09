import { createAction, props } from '@ngrx/store';
import { Product } from '../models/product';

export const add = createAction(
  '[Details Component] Add',
  props<{ item: Product }>()
);

export const update = createAction(
  '[Cart Component] Update',
  props<{ id: number, number: number }>()
);

export const deleteItem = createAction(
  '[Cart Component] Delete',
  props<{ id: number }>()
);

export const clearCart = createAction(
  '[Cart Component] Clear Cart'
);


