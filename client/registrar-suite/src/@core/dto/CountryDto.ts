export class CountryDto {
  shortCode?: string;
  shortName?: string;
  nativeName?: string;
  flag?: string;
  currencyCode?: string;
  callingCode?: string;
  latitude?: string;
  longitude?: string;
  population: number | undefined;
}

export class CountryDrpDto {
  shortCode?: string;
  nativeName?: string;
  flag?: string;
}

