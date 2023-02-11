import { Body, Controller, Post } from '@nestjs/common';
import { ApiTags } from '@nestjs/swagger';
import { CreateClientRequest } from './usecases/create-client/create-client.request';
import { CreateClientService } from './usecases/create-client/create-client.service';

@ApiTags('Client')
@Controller('client')
export class ClientController {
  constructor(private readonly createClient: CreateClientService) {}

  @Post()
  async create(@Body() client: CreateClientRequest) {
    return this.createClient.create(client);
  }
}
