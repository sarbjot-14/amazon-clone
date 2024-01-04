
import {createAction, props} from '@ngrx/store';
import { Product } from '../models/product';

const key = 'PRODUCT';

export const add = createAction(`[${key}] Add`,
  props<{product: Product}>());


