import { Body, Controller, Post } from '@nestjs/common';
import { ApiTags } from '@nestjs/swagger';
import { CreateDeliveryRequest } from './usecases/create-delivery/create-delivery.request';
import { CreateDeliveryService } from './usecases/create-delivery/create-delivery.service';

@ApiTags('Delivery')
@Controller('delivery')
export class DeliveryController {
  constructor(private createDelivery: CreateDeliveryService) {}

  @Post()
  async create(@Body() delivery: CreateDeliveryRequest) {
    return this.createDelivery.create(delivery);
  }
}
