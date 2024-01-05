import { createReducer, on } from '@ngrx/store';
import { add, deleteItem, update } from './items.actions';
import { Product } from '../models/product';

export const initialState: Product[] = [];

export const itemsReducer = createReducer(
  initialState,
  on(add, (state, payload) => {
    //console.log('in reducer ', state, payload);

    let selectedItem = state.find((item) => item.id == payload.item.id);
    //console.log('item is ', selectedItem);

    if (!selectedItem) {
      return [...state, payload.item];
    } else {
      let newState = state.filter((i) => i.id != selectedItem?.id);

      return [
        ...newState,
        {
          ...selectedItem,
          number: selectedItem.number! + payload.item.number!,
        },
      ];
    }
  }),
  on(update, (state, payload) => {
    let selectedItem = state.find((item) => item.id == payload.id);
    let newState = state.filter((i) => i.id != payload.id);

    return [...newState, { ...selectedItem!, number: payload.number }];
  }),
  on(deleteItem, (state, payload) => {
    let newState = state.filter((i) => i.id != payload.id);

    return [...newState];
  })
);
