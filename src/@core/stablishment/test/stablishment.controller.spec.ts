import { faker } from '@faker-js/faker';
import { Test, TestingModule } from '@nestjs/testing';
import { AddressRequest } from 'src/@core/address/address.request';
import { PrismaModule } from 'src/prisma/prisma.module';
import { StablishmentController } from '../stablishment.controller';
import { CreateStablishmentRequest } from '../usecases/create-stablishment.request';
import { CreateStablishmentService } from '../usecases/create-stablishment.service';

describe('StablishmentController', () => {
  let controller: StablishmentController;
  const stablishment = new CreateStablishmentRequest();
  stablishment.name = faker.company.name();
  stablishment.phone = faker.phone.number('BR');
  stablishment.email = faker.internet.email();
  stablishment.address = new AddressRequest();
  stablishment.address.street = faker.address.street();
  stablishment.address.number = faker.address.buildingNumber();
  stablishment.address.city = faker.address.city();
  stablishment.address.state = faker.address.state();
  stablishment.address.zipCode = faker.address.zipCode();
  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      imports: [PrismaModule],
      controllers: [StablishmentController],
      providers: [CreateStablishmentService],
    }).compile();
    controller = module.get<StablishmentController>(StablishmentController);
  });
  it('should be defined', () => {
    expect(controller).toBeDefined();
  });
  it('should create a stablishment', async () => {
    const result = await controller.create(stablishment);
    expect(result).not.toBeNull();
    expect(result).toHaveProperty('id');
    expect(result).toHaveProperty('name');
    expect(result).toHaveProperty('description');
    expect(result).toHaveProperty('phone');
    expect(result).toHaveProperty('email');
    expect(result).toHaveProperty('address');
    expect(result.name).toBe(stablishment.name);
    expect(result.phone).toBe(stablishment.phone);
    expect(result.email).toBe(stablishment.email);
  });
});
