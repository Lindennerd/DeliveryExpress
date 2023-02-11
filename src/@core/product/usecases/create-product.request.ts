import { IsNotEmpty, IsOptional, Min } from 'class-validator';

export class CreateProductRequest {
  @IsOptional()
  id?: number;
  @IsNotEmpty()
  name: string;
  @IsNotEmpty()
  description: string;
  @Min(0)
  price: number;
}
