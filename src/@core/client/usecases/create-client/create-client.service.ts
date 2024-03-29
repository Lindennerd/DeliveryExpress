import { BadRequestException, Injectable, Logger } from '@nestjs/common';
import { AddressService } from 'src/@core/address/address.service';
import { PrismaService } from 'src/prisma/prisma.service';
import { CreateClientRequest } from './create-client.request';

@Injectable()
export class CreateClientService {
  constructor(
    private readonly prisma: PrismaService,
    private readonly addressService: AddressService,
  ) {}

  private logger = new Logger(CreateClientService.name);

  async create(client: CreateClientRequest) {
    this.logger.log(`Creating client ${client.name}`);

    try {
      if (await this.checkUserExists(client.email)) {
        return new BadRequestException('Client already exists');
      }

      const address = await this.addressService.findOrCreateAddress(
        client.address,
      );
      return await this.prisma.client.create({
        data: {
          name: client.name,
          email: client.email,
          phone: client.phone,
          ClientAddress: {
            create: {
              address: { connect: { id: address.id } },
            },
          },
        },
      });
    } catch (e) {
      this.logger.error(`Error creating client ${client.name}`, e.stack);
      throw e;
    }
  }

  private async checkUserExists(email: string) {
    return await this.prisma.client.findFirst({
      where: {
        email,
      },
    });
  }
}
