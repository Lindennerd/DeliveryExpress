import { IsEmail, IsNotEmpty, IsPhoneNumber } from 'class-validator';
import { AddressRequest } from 'src/@core/address/address.request';

export class CreateClientRequest {
  @IsNotEmpty()
  name: string;
  @IsNotEmpty()
  @IsEmail()
  email: string;
  @IsNotEmpty()
  @IsPhoneNumber('BR')
  phone: string;
  @IsNotEmpty()
  address: AddressRequest;
}
