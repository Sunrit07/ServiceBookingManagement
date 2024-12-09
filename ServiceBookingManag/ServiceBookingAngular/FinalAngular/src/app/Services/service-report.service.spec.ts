import { TestBed } from '@angular/core/testing';

import { ServiceReportService } from './service-report.service';

describe('ServiceReportService', () => {
  let service: ServiceReportService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServiceReportService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
