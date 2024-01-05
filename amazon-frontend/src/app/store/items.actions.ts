import { createAction, props } from '@ngrx/store';
import { Product } from '../models/product';

export const add = createAction(
  '[Details Component] Add',
  props<{ item: Product }>()
);
// export const decrement = createAction('[Counter Component] Decrement');
// export const reset = createAction('[Counter Component] Reset');
