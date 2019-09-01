import { TestBed, inject } from '@angular/core/testing';

import { RecipeManagementService } from './recipe-management.service';

describe('RecipeManagementService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RecipeManagementService]
    });
  });

  it('should be created', inject([RecipeManagementService], (service: RecipeManagementService) => {
    expect(service).toBeTruthy();
  }));
});
