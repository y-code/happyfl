import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipeSeekerIndexComponent } from './recipe-seeker-index.component';

describe('RecipeSeekerIndexComponent', () => {
  let component: RecipeSeekerIndexComponent;
  let fixture: ComponentFixture<RecipeSeekerIndexComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecipeSeekerIndexComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipeSeekerIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
