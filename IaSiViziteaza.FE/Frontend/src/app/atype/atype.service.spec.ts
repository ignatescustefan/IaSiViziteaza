import { TestBed } from '@angular/core/testing';

import { ATypeService } from './atype.service';

describe('ATypeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ATypeService = TestBed.get(ATypeService);
    expect(service).toBeTruthy();
  });
});
