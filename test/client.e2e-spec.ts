import { faker } from '@faker-js/faker';
import {
  BadRequestException,
  INestApplication,
  ValidationPipe,
} from '@nestjs/common';
import { Test, TestingModule } from '@nestjs/testing';
import { AddressRequest } from 'src/@core/address/address.request';
import { CreateClientRequest } from 'src/@core/client/usecases/create-client/create-client.request';
import * as request from 'supertest';
import { AppModule } from './../src/app.module';

describe('Client (e2e)', () => {
  let app: INestApplication;
  let client: CreateClientRequest;

  beforeEach(async () => {
    client = new CreateClientRequest();
    //sets the properties of the instancie
    client.name = faker.name.firstName() + ' ' + faker.name.lastName();
    client.email = faker.internet.email();
    client.phone = faker.phone.number('#########');
    //creates an instancie of AddressRequest
    const address = new AddressRequest();
    //sets the properties of the instancie
    address.street = faker.address.street();
    address.number = faker.address.buildingNumber();
    address.city = faker.address.city();
    address.state = faker.address.state();
    address.zipCode = faker.address.zipCode();
    address.neighborhood = faker.address.county();
    //sets the address property of the client instancie
    client.address = address;

    const moduleFixture: TestingModule = await Test.createTestingModule({
      imports: [AppModule],
    }).compile();

    app = moduleFixture.createNestApplication();
    app.useGlobalPipes(
      new ValidationPipe({
        exceptionFactory: (errors) => {
          const error = errors.map((e) => ({
            field: e.property,
            message: Object.values(e.constraints).join(', '),
          }));
          return new BadRequestException(error);
        },
      }),
    );
    await app.init();
  });

  describe('/ (POST', () => {
    it('should create a client', async () => {
      const res = await request(app.getHttpServer())
        .post('/client')
        .send(client)
        .expect(201);

      expect(res.body).toHaveProperty('id');
      expect(res.body).toHaveProperty('name');
      expect(res.body.name).toBe(client.name);
      expect(res.body.email).toBe(client.email);

      return res;
    });
  });
});
