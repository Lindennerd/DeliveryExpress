import { Injectable } from '@nestjs/common';
import { AddressFactory } from 'src/@core/address/address.factory';
import { PrismaService } from 'src/prisma/prisma.service';
import { CreateDeliveryRequest } from './create-delivery.request';

@Injectable()
export class CreateDeliveryService {
  constructor(private prisma: PrismaService) {}

  async create(delivery: CreateDeliveryRequest) {
    return await this.prisma.delivery.create({
      data: {
        description: delivery.description,
        deliveryStatus: 'PENDING',
        stablishment: {
          connect: {
            id: delivery.stablishmentId,
          },
        },
        client: {
          connect: {
            id: delivery.clientId,
          },
        },
        deliveryItem: {
          create: delivery.deliveryItems.map((item) => ({
            quantity: item.quantity,
            product: {
              connect: {
                id: item.productId,
              },
            },
          })),
        },
        address: {
          connectOrCreate: AddressFactory.connectOrCreate(delivery.address),
        },
      },
    });
  }
}
