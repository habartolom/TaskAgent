import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalTimeslipComponent } from './modal-timeslip.component';

describe('ModalTimeslipComponent', () => {
  let component: ModalTimeslipComponent;
  let fixture: ComponentFixture<ModalTimeslipComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalTimeslipComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalTimeslipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
