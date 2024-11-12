import {Country} from './country-model';


export interface City {
  iD: number;
  name: string;
  countryId: number;
  country: Country | null;
}

export interface AllCity {
  cities: City[];
}
