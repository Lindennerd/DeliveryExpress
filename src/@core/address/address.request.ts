import {
  IsNotEmpty,
  IsNumberString,
  IsOptional,
  MaxLength,
  MinLength,
} from 'class-validator';

export class AddressRequest {
  @IsOptional()
  id?: number;
  @IsNotEmpty()
  street: string;
  @IsNotEmpty()
  neighborhood: string;
  @IsNotEmpty()
  @IsNumberString()
  number: string;
  @IsOptional()
  complement?: string;
  @IsNotEmpty()
  district: string;
  @IsNotEmpty()
  city: string;
  @IsNotEmpty()
  state: string;
  @IsNotEmpty()
  country: string;
  @IsNotEmpty()
  @MinLength(8)
  @MaxLength(8)
  zipCode: string;
}
