import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AttrByTitleComponent } from './attr-by-title.component';

describe('AttrByTitleComponent', () => {
  let component: AttrByTitleComponent;
  let fixture: ComponentFixture<AttrByTitleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AttrByTitleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AttrByTitleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
