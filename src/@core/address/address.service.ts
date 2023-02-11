import { Injectable, Logger } from '@nestjs/common';
import { PrismaService } from 'src/prisma/prisma.service';
import { AddressRequest } from './address.request';

@Injectable()
export class AddressService {
  constructor(private readonly prisma: PrismaService) {}

  private logger = new Logger(AddressService.name);

  async findOrCreateAddress(address: AddressRequest) {
    try {
      const found = await this.prisma.address.findFirst({
        where: {
          zipCode: address.zipCode,
        },
        select: {
          id: true,
        },
      });

      if (!found) {
        return await this.prisma.address.create({
          data: address,
          select: { id: true },
        });
      }

      return found;
    } catch (error) {
      this.logger.error('Error finding or creating address', error.stack);
      throw error;
    }
  }
}
