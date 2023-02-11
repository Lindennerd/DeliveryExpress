import { Injectable } from '@nestjs/common';
import { AddressService } from 'src/@core/address/address.service';
import { PrismaService } from 'src/prisma/prisma.service';
import { CreateStablishmentRequest } from './create-stablishment.request';

@Injectable()
export class CreateStablishmentService {
  constructor(
    private readonly prisma: PrismaService,
    private readonly addressService: AddressService,
  ) {}

  async create(stablishment: CreateStablishmentRequest) {
    const address = await this.addressService.findOrCreateAddress(
      stablishment.address,
    );

    return await this.prisma.stablishment.create({
      data: {
        email: stablishment.email,
        name: stablishment.name,
        phone: stablishment.phone,
        StablishmentAddress: {
          create: { address: { connect: { id: address.id } } },
        },
      },
    });
  }
}
