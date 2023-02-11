import { Body, Controller, Post } from '@nestjs/common';
import { ApiTags } from '@nestjs/swagger';
import { Delivery } from '@prisma/client';
import { DeliveryGateway } from './delivery.gateway';
import { CreateDeliveryRequest } from './usecases/create-delivery/create-delivery.request';
import { CreateDeliveryService } from './usecases/create-delivery/create-delivery.service';

@ApiTags('Delivery')
@Controller('delivery')
export class DeliveryController {
  constructor(
    private readonly createDelivery: CreateDeliveryService,
    private readonly deliveryGateway: DeliveryGateway,
  ) {}

  @Post()
  async create(@Body() delivery: CreateDeliveryRequest): Promise<Delivery> {
    const deliveryCreated = await this.createDelivery.create(delivery);
    this.deliveryGateway.handleDeliveryCreated(deliveryCreated);

    return deliveryCreated;
  }
}
