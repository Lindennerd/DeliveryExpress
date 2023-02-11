import { faker } from '@faker-js/faker';
import { Test, TestingModule } from '@nestjs/testing';
import { AddressModule } from 'src/@core/address/address.module';
import { AddressRequest } from 'src/@core/address/address.request';
import { PrismaModule } from 'src/prisma/prisma.module';
import { DeliveryController } from '../delivery.controller';
import { DeliveryGateway } from '../delivery.gateway';
import { CreateDeliveryRequest } from '../usecases/create-delivery/create-delivery.request';
import { CreateDeliveryService } from '../usecases/create-delivery/create-delivery.service';

describe('DeliveryController', () => {
  let controller: DeliveryController;
  const delivery = new CreateDeliveryRequest();
  delivery.description = faker.commerce.productDescription();
  delivery.clientId = 1;
  delivery.deliveryItems = [
    { productId: 1, quantity: 1 },
    { productId: 2, quantity: 2 },
    { productId: 3, quantity: 3 },
  ];
  delivery.address = new AddressRequest();
  delivery.address.street = faker.address.street();
  delivery.address.number = faker.address.buildingNumber();
  delivery.address.city = faker.address.city();
  delivery.address.state = faker.address.state();
  delivery.address.zipCode = faker.address.zipCode();
  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      imports: [PrismaModule, AddressModule],
      controllers: [DeliveryController],
      providers: [CreateDeliveryService, DeliveryGateway],
    }).compile();
    controller = module.get<DeliveryController>(DeliveryController);
  });
  it('should be defined', () => {
    expect(controller).toBeDefined();
  });
  it('should create a delivery', async () => {
    const result = await controller.create(delivery);
    expect(result).not.toBeNull();
    expect(result).toHaveProperty('id');
    expect(result).toHaveProperty('name');
    expect(result).toHaveProperty('description');
    expect(result).toHaveProperty('phone');
    expect(result).toHaveProperty('email');
    expect(result).toHaveProperty('address');
  });
});
