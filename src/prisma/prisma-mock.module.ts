import { DynamicModule, Provider } from '@nestjs/common';

export const PrismaMockModule = (providers: Provider[]): DynamicModule => {
  return {
    module: class MockModule {},
    providers,
    exports: providers,
    global: true,
  };
};
