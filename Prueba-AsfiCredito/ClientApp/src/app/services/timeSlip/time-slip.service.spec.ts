import { TestBed } from '@angular/core/testing';

import { TimeSlipService } from './time-slip.service';

describe('TimeSlipService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TimeSlipService = TestBed.get(TimeSlipService);
    expect(service).toBeTruthy();
  });
});
