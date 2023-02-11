import { Injectable, Logger } from '@nestjs/common';
import { AddressService } from 'src/@core/address/address.service';
import { PrismaService } from 'src/prisma/prisma.service';
import { CreateDeliveryRequest } from './create-delivery.request';

@Injectable()
export class CreateDeliveryService {
  constructor(
    private prisma: PrismaService,
    private readonly addressService: AddressService,
  ) {}

  private logger = new Logger(CreateDeliveryService.name);

  async create(delivery: CreateDeliveryRequest) {
    try {
      this.logger.debug('Creating delivery', delivery);

      const address = await this.addressService.findOrCreateAddress(
        delivery.address,
      );

      return await this.prisma.delivery.create({
        data: {
          description: delivery.description,
          deliveryStatus: 'PENDING',
          stablishment: { connect: { id: delivery.stablishmentId } },
          client: { connect: { id: delivery.clientId } },
          deliveryItem: {
            createMany: {
              data: delivery.deliveryItems.map((item) => ({
                quantity: item.quantity,
                productId: item.productId,
              })),
            },
          },
          DeliveryAddress: {
            create: {
              address: { connect: { id: address.id } },
            },
          },
        },
      });
    } catch (error) {
      this.logger.error('Error creating delivery', error.stack);
      throw error;
    }
  }
}
