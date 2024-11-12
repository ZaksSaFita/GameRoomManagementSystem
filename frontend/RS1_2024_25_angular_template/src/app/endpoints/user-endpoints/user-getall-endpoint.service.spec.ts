import { TestBed } from '@angular/core/testing';

import { UserGetallEndpointService } from './user-getall-endpoint.service';

describe('UserGetallEndpointService', () => {
  let service: UserGetallEndpointService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserGetallEndpointService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
