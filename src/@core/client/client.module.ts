import { Module } from '@nestjs/common';
import { PrismaModule } from 'src/prisma/prisma.module';
import { AddressModule } from '../address/address.module';
import { ClientController } from './client.controller';
import { CreateClientService } from './usecases/create-client/create-client.service';

@Module({
  imports: [PrismaModule, AddressModule],
  controllers: [ClientController],
  providers: [CreateClientService],
})
export class ClientModule {}
