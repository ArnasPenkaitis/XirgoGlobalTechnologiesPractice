import { TestBed } from '@angular/core/testing';

import { DeviceRecordsService } from './device-records.service';

describe('DeviceRecordsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DeviceRecordsService = TestBed.get(DeviceRecordsService);
    expect(service).toBeTruthy();
  });
});
