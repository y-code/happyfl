import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WebSeekerComponent } from './web-seeker.component';

describe('WebSeekerComponent', () => {
  let component: WebSeekerComponent;
  let fixture: ComponentFixture<WebSeekerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WebSeekerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WebSeekerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
