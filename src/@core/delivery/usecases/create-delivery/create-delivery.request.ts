import {
  ArrayMinSize,
  IsNotEmptyObject,
  IsOptional,
  Min,
} from 'class-validator';
import { AddressRequest } from 'src/@core/address/address.request';

export class CreateDeliveryRequest {
  @IsOptional()
  description: string;
  @Min(1)
  clientId: number;
  @Min(1)
  stablishmentId: number;
  @ArrayMinSize(1)
  deliveryItems: [
    {
      productId: number;
      quantity: number;
    },
  ];
  @IsNotEmptyObject()
  address: AddressRequest;
}
