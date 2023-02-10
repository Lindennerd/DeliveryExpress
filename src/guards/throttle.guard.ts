import { ThrottlerGuard } from '@nestjs/throttler';

export const ThrottleGuard = {
  provide: 'ThrottleGuard',
  useClass: ThrottlerGuard,
};
