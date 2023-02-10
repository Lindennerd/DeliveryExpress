import { Injectable } from '@nestjs/common';
import { PrismaService } from 'src/prisma/prisma.service';
import { CreateDeliveryRequest } from './create-delivery.request';

@Injectable()
export class CreateDeliveryService {
  constructor(private prisma: PrismaService) {}

  async create(delivery: CreateDeliveryRequest) {
    return this.prisma.delivery.create({
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
          connectOrCreate: {
            where: {
              id: delivery.address.id,
            },
            create: {
              street: delivery.address.street,
              number: delivery.address.number,
              complement: delivery.address.complement,
              neighborhood: delivery.address.neighborhood,
              city: delivery.address.city,
              state: delivery.address.state,
              zipCode: delivery.address.zipCode,
            },
          },
        },
      },
    });
  }
}
