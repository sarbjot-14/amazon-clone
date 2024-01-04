import { Product } from './product';

export interface CartStateInterface {
  isLoading: boolean;
  products: Product[];
  error: string | null;
}
