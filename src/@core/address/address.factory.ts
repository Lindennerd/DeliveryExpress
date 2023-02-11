import { AddressRequest } from './address.request';

export class AddressFactory {
  static connectOrCreate(address: AddressRequest) {
    return {
      where: {
        id: address.id,
      },
      create: {
        street: address.street,
        number: address.number,
        complement: address.complement,
        neighborhood: address.neighborhood,
        city: address.city,
        state: address.state,
        zipCode: address.zipCode,
      },
    };
  }
}
