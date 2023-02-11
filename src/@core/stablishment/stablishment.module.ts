import { Module } from '@nestjs/common';
import { PrismaModule } from 'src/prisma/prisma.module';
import { StablishmentController } from './stablishment.controller';
import { CreateStablishmentService } from './usecases/create-stablishment.service';

@Module({
  imports: [PrismaModule],
  controllers: [StablishmentController],
  providers: [CreateStablishmentService],
})
export class StablishmentModule {}
