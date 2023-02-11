import { Injectable, Logger } from '@nestjs/common';
import { PrismaService } from 'src/prisma/prisma.service';
import { CreateProductRequest } from './create-product.request';

@Injectable()
export class CreateProductService {
  constructor(private readonly prisma: PrismaService) {}

  private logger = new Logger(CreateProductService.name);

  async create(product: CreateProductRequest) {
    try {
      this.logger.log(`Creating product ${product.name}`);
      return await this.prisma.product.create({
        data: {
          name: product.name,
          description: product.description,
          price: product.price,
        },
      });
    } catch (error) {
      this.logger.error(`Error creating product ${product.name}`, error.stack);
      throw error;
    }
  }
}
