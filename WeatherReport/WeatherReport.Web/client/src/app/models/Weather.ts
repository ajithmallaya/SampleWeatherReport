import { City } from './City';

export class Weather {
    constructor(
      public Country: string,
      public City: City,
      public subBannnerImageUrl: string,
      public Time : string,
      public Wind : string,
      public Visibility : string,
      public SkyConditions : string,
      public Temperature : string,
      public DewPoint : string,
      public RelativeHumidity : string,
      public Pressure : string,
    ) {

    }
}  