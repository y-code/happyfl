import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipeSeekerComponent } from './recipe-seeker.component';

describe('RecipeSeekerComponent', () => {
  let component: RecipeSeekerComponent;
  let fixture: ComponentFixture<RecipeSeekerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecipeSeekerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipeSeekerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
