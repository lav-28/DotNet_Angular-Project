import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DegreeListComponent } from './degree-list.component';

describe('DegreeListComponent', () => {
  let component: DegreeListComponent;
  let fixture: ComponentFixture<DegreeListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DegreeListComponent]
    });
    fixture = TestBed.createComponent(DegreeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
