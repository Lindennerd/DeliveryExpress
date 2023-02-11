import { AddressRequest } from 'src/@core/address/address.request';

export class CreateStablishmentRequest {
  name: string;
  email: string;
  phone: string;
  address: AddressRequest;
}
