import { faker } from '@faker-js/faker';
import { Client } from '@prisma/client';
export const PrismaMockService = {
  client: {
    create: jest.fn().mockResolvedValue({
      id: Number(faker.random.numeric()),
      name: faker.name.firstName() + ' ' + faker.name.lastName(),
      email: faker.internet.email(),
      phone: faker.phone.number('#########'),
      createdAt: new Date(),
      updatedAt: new Date(),
    } as Client),
    findFirst: jest.fn().mockResolvedValue(null),
  },
};
