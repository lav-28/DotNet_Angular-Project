import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DegreeUpdateComponent } from './degree-update.component';

describe('DegreeUpdateComponent', () => {
  let component: DegreeUpdateComponent;
  let fixture: ComponentFixture<DegreeUpdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DegreeUpdateComponent]
    });
    fixture = TestBed.createComponent(DegreeUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
