import { TestBed } from '@angular/core/testing';

import { GraduatetraineeService } from './graduatetrainee.service';

describe('GraduatetraineeService', () => {
  let service: GraduatetraineeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GraduatetraineeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
