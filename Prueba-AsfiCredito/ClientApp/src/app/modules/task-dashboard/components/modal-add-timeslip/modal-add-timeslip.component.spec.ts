import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalAddTimeslipComponent } from './modal-add-timeslip.component';

describe('ModalAddTimeslipComponent', () => {
  let component: ModalAddTimeslipComponent;
  let fixture: ComponentFixture<ModalAddTimeslipComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalAddTimeslipComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalAddTimeslipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
