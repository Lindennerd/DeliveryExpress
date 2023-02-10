import { Body, Controller, Post } from '@nestjs/common';
import { CreateDeliveryRequest } from './usecases/create-delivery/create-delivery.request';
import { CreateDeliveryService } from './usecases/create-delivery/create-delivery.service';

@Controller()
export class DeliveryController {
  constructor(private createDelivery: CreateDeliveryService) {}

  @Post()
  async create(@Body() delivery: CreateDeliveryRequest) {
    return this.createDelivery.create(delivery);
  }
}
