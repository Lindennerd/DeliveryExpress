import { Module } from '@nestjs/common';
import { PrismaModule } from 'src/prisma/prisma.module';
import { DeliveryController } from './delivery.controller';
import { DeliveryGateway } from './delivery.gateway';
import { CreateDeliveryService } from './usecases/create-delivery/create-delivery.service';

@Module({
  imports: [PrismaModule],
  controllers: [DeliveryController],
  providers: [CreateDeliveryService, DeliveryGateway],
})
export class DeliveryModule {}
