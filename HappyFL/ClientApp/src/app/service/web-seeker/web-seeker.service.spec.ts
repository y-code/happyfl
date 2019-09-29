import { TestBed, inject } from '@angular/core/testing';

import { WebSeekerService } from './web-seeker.service';

describe('WebSeakerService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [WebSeekerService]
    });
  });

  it('should be created', inject([WebSeekerService], (service: WebSeekerService) => {
    expect(service).toBeTruthy();
  }));
});
