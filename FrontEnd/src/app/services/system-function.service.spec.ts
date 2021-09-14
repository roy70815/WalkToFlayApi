import { TestBed } from '@angular/core/testing';

import { SystemFunctionService } from './system-function.service';

describe('SystemFunctionService', () => {
  let service: SystemFunctionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SystemFunctionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
