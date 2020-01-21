import { TestBed } from '@angular/core/testing';

import { HubServiceService } from './hub-service.service';

describe('HubServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HubServiceService = TestBed.get(HubServiceService);
    expect(service).toBeTruthy();
  });
});
