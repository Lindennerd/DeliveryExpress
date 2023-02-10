import { Module } from '@nestjs/common';
import { ThrottlerModule } from '@nestjs/throttler';
import { DeliveryModule } from './@core/delivery/delivery.module';
import { ThrottleGuard } from './guards/throttle.guard';

@Module({
  imports: [
    ThrottlerModule.forRoot({
      ttl: 60,
      limit: 10,
    }),
    DeliveryModule,
  ],
  controllers: [],
  providers: [ThrottleGuard],
  exports: [ThrottleGuard],
})
export class AppModule {}
