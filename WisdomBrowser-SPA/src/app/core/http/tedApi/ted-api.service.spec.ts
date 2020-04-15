/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TedApiService } from './ted-api.service';

describe('Service: TedApi', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TedApiService]
    });
  });

  it('should ...', inject([TedApiService], (service: TedApiService) => {
    expect(service).toBeTruthy();
  }));
});
