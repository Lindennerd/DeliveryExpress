import { Injectable } from '@nestjs/common';
import { PrismaService } from 'src/prisma/prisma.service';
import { CreateProductRequest } from './create-product.request';

@Injectable()
export class CreateProductService {
  constructor(private readonly prisma: PrismaService) {}

  async create(product: CreateProductRequest) {
    return await this.prisma.product.create({
      data: {
        name: product.name,
        description: product.description,
        price: product.price,
      },
    });
  }
}
