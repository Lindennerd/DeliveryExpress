import { Injectable } from '@nestjs/common';
import { PrismaService } from 'src/prisma/prisma.service';
import { CreateStablishmentRequest } from './create-stablishment.request';

@Injectable()
export class CreateStablishmentService {
  constructor(private readonly prisma: PrismaService) {}

  async create(stablishment: CreateStablishmentRequest) {
    return await this.prisma.stablishment.create({
      data: {
        email: stablishment.email,
        name: stablishment.name,
        phone: stablishment.phone,
        StablishmentAddress: {
          create: {
            address: {
              connectOrCreate: {
                where: { id: stablishment.address.id },
                create: {
                  ...stablishment.address,
                },
              },
            },
          },
        },
      },
    });
  }
}
