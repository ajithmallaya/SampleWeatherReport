import { City } from './City';

export class GeoLocation {
    constructor(
      public Country: string,
      public Cities: City[],
    ) {

    }
} 