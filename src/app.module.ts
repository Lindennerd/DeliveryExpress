import { Module } from '@nestjs/common';
import { ThrottlerModule } from '@nestjs/throttler';
import { ClientModule } from './@core/client/client.module';
import { DeliveryModule } from './@core/delivery/delivery.module';
import { ThrottleGuard } from './guards/throttle.guard';

@Module({
  imports: [
    ThrottlerModule.forRoot({
      ttl: 60,
      limit: 10,
    }),
    DeliveryModule,
    ClientModule,
  ],
  controllers: [],
  providers: [ThrottleGuard],
  exports: [ThrottleGuard],
})
export class AppModule {}
