import { Injectable, Logger } from '@nestjs/common';
import { PrismaService } from 'src/prisma/prisma.service';
import { CreateDeliveryRequest } from './create-delivery.request';

@Injectable()
export class CreateDeliveryService {
  constructor(private prisma: PrismaService) {}

  private logger = new Logger(CreateDeliveryService.name);

  async create(delivery: CreateDeliveryRequest) {
    this.logger.debug('Creating delivery', delivery);

    return await this.prisma.delivery.create({
      data: {
        description: delivery.description,
        deliveryStatus: 'PENDING',
        stablishment: { connect: { id: delivery.stablishmentId } },
        client: { connect: { id: delivery.clientId } },
        DeliveryAddress: {
          create: {
            address: {
              connectOrCreate: {
                where: { id: delivery.address.id },
                create: {
                  ...delivery.address,
                },
              },
            },
          },
        },
      },
    });
  }
}
