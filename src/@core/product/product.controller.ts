import { Body, Controller, Post } from '@nestjs/common';
import { ApiTags } from '@nestjs/swagger';
import { CreateProductRequest } from './usecases/create-product.request';
import { CreateProductService } from './usecases/create-product.service';

@ApiTags('Products')
@Controller('products')
export class ProductController {
  constructor(private readonly createProductService: CreateProductService) {}

  @Post()
  async create(@Body() product: CreateProductRequest) {
    return await this.createProductService.create(product);
  }
}
