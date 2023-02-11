import { MessageBody, WebSocketGateway } from '@nestjs/websockets';
import { Delivery } from '@prisma/client';

@WebSocketGateway({
  namespace: 'delivery',
  cors: {
    origin: '*',
  },
})
export class DeliveryGateway {
  handleDeliveryCreated(@MessageBody() delivery: Delivery) {
    return delivery;
  }
}
