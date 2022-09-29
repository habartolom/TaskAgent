import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTimeslipComponent } from './add-timeslip.component';

describe('AddTimeslipComponent', () => {
  let component: AddTimeslipComponent;
  let fixture: ComponentFixture<AddTimeslipComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddTimeslipComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTimeslipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
