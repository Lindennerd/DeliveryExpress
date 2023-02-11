import { Module } from '@nestjs/common';
import { PrismaModule } from 'src/prisma/prisma.module';
import { ProductController } from './product.controller';
import { CreateProductService } from './usecases/create-product.service';

@Module({
  imports: [PrismaModule],
  controllers: [ProductController],
  providers: [CreateProductService],
})
export class ProductModule {}
