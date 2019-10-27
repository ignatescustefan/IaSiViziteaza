import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAtypeComponent } from './add-atype.component';

describe('AddAtypeComponent', () => {
  let component: AddAtypeComponent;
  let fixture: ComponentFixture<AddAtypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddAtypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAtypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
