import {
  ArrayMinSize,
  IsNotEmptyObject,
  IsOptional,
  Min,
} from 'class-validator';

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
  address: {
    id?: number;
    street: string;
    number: string;
    complement?: string;
    neighborhood: string;
    city: string;
    state: string;
    zipCode: string;
  };
}
