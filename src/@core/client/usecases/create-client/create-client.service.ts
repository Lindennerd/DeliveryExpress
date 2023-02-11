import { Injectable } from '@nestjs/common';
import { AddressFactory } from 'src/@core/address/address.factory';
import { PrismaService } from 'src/prisma/prisma.service';
import { CreateClientRequest } from './create-client.request';

@Injectable()
export class CreateClientService {
  constructor(private readonly prisma: PrismaService) {}

  async create(client: CreateClientRequest) {
    return await this.prisma.client.create({
      data: {
        ...client,
        address: {
          connectOrCreate: AddressFactory.connectOrCreate(client.address),
        },
      },
    });
  }
}
