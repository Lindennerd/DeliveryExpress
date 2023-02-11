import { faker } from '@faker-js/faker';
import {
  BadRequestException,
  INestApplication,
  ValidationPipe,
} from '@nestjs/common';
import { Test, TestingModule } from '@nestjs/testing';
import { CreateProductRequest } from 'src/@core/product/usecases/create-product.request';
import * as request from 'supertest';
import { AppModule } from './../src/app.module';

describe('Product (e2e)', () => {
  let app: INestApplication;
  let product: CreateProductRequest;

  beforeEach(async () => {
    product = new CreateProductRequest();
    product.name = faker.commerce.productName();
    product.description = faker.commerce.productDescription();
    product.price = Number(faker.commerce.price());

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
    it('should create a product', async () => {
      const res = await request(app.getHttpServer())
        .post('/products')
        .send(product)
        .expect(201);

      expect(res.body).toHaveProperty('id');
      expect(res.body).toHaveProperty('price');
      expect(res.body.price).toBe(product.price);
      expect(res.body.name).toBe(product.name);

      return res;
    });

    it('should not create a roduct when price is 0 or less', async () => {
      const failedProduct = { ...product, price: 0 };
      const res = await request(app.getHttpServer())
        .post('/products')
        .send(failedProduct)
        .expect(400);

      return res;
    });
  });
});
