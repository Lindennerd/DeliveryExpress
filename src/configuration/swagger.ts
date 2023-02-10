import { INestApplication } from '@nestjs/common';
import { DocumentBuilder, SwaggerModule } from '@nestjs/swagger';

export const useSwagger = (app: INestApplication) => {
  const options = new DocumentBuilder()
    .setTitle('Delivery API')
    .setDescription('Delivery API description')
    .setVersion('1.0')
    .addTag('delivery')
    .build();
  const document = SwaggerModule.createDocument(app, options);
  SwaggerModule.setup('api', app, document);
};
