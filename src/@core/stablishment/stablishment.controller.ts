import { Body, Controller, Post } from '@nestjs/common';
import { ApiTags } from '@nestjs/swagger';
import { CreateStablishmentRequest } from './usecases/create-stablishment.request';
import { CreateStablishmentService } from './usecases/create-stablishment.service';

@ApiTags('Stablishment')
@Controller('stablishment')
export class StablishmentController {
  constructor(
    private readonly createStablishmentService: CreateStablishmentService,
  ) {}

  @Post()
  async create(@Body() stablishment: CreateStablishmentRequest) {
    return await this.createStablishmentService.create(stablishment);
  }
}
