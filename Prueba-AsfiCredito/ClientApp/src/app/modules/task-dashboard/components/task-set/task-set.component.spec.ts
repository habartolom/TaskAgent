import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskSetComponent } from './task-set.component';

describe('TaskSetComponent', () => {
  let component: TaskSetComponent;
  let fixture: ComponentFixture<TaskSetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaskSetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskSetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
