import { Test, TestingModule } from '@nestjs/testing';
import { PrismaModule } from '../../../prisma/prisma.module';
import { AddressRequest } from '../../address/address.request';
import { ClientController } from '../client.controller';
import { CreateClientRequest } from '../usecases/create-client/create-client.request';
import { CreateClientService } from '../usecases/create-client/create-client.service';

import { faker } from '@faker-js/faker';

describe('ClientController', () => {
  let controller: ClientController;

  //creates an instancie of CreateClientRequest
  const client = new CreateClientRequest();
  //sets the properties of the instancie
  client.name = faker.name.firstName() + ' ' + faker.name.lastName();
  client.email = faker.internet.email();
  client.phone = faker.phone.number('BR');
  //creates an instancie of AddressRequest
  const address = new AddressRequest();
  //sets the properties of the instancie
  address.street = faker.address.street();
  address.number = faker.address.buildingNumber();
  address.city = faker.address.city();
  address.state = faker.address.state();
  address.zipCode = faker.address.zipCode();
  //sets the address property of the client instancie
  client.address = address;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      imports: [PrismaModule],
      controllers: [ClientController],
      providers: [CreateClientService],
    }).compile();

    controller = module.get<ClientController>(ClientController);
  });

  it('should be defined', () => {
    expect(controller).toBeDefined();
  });

  it('should create a client', async () => {
    //calls the create method of the controller
    const result = await controller.create(client);
    //checks if the result is not null
    expect(result).not.toBeNull();
    //checks if the result has the properties
    expect(result).toHaveProperty('id');
    expect(result).toHaveProperty('name');
    expect(result).toHaveProperty('email');
    expect(result).toHaveProperty('phone');
    expect(result).toHaveProperty('address');
    //checks if the result has the same values as the client instancie
    expect(result.name).toBe(client.name);
    expect(result.email).toBe(client.email);
    expect(result.phone).toBe(client.phone);
  });
});
