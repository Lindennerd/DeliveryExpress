import { faker } from '@faker-js/faker';
import { Test, TestingModule } from '@nestjs/testing';
import { PrismaModule } from 'src/prisma/prisma.module';
import { ProductController } from '../product.controller';
import { CreateProductRequest } from '../usecases/create-product.request';
import { CreateProductService } from '../usecases/create-product.service';

describe('ProductController', () => {
  let controller: ProductController;
  const product = new CreateProductRequest();
  product.name = faker.commerce.productName();
  product.description = faker.commerce.productDescription();
  product.price = Number(faker.commerce.price());
  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      imports: [PrismaModule],
      controllers: [ProductController],
      providers: [CreateProductService],
    }).compile();
    controller = module.get<ProductController>(ProductController);
  });
  it('should be defined', () => {
    expect(controller).toBeDefined();
  });
  it('should create a product', async () => {
    const result = await controller.create(product);
    expect(result).not.toBeNull();
    expect(result).toHaveProperty('id');
    expect(result).toHaveProperty('name');
    expect(result).toHaveProperty('description');
    expect(result).toHaveProperty('price');
    expect(result.name).toBe(product.name);
    expect(result.description).toBe(product.description);
    expect(result.price).toBe(product.price);
  });
});
