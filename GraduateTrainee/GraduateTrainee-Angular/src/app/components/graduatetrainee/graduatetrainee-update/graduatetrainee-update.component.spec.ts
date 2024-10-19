import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraduatetraineeUpdateComponent } from './graduatetrainee-update.component';

describe('GraduatetraineeUpdateComponent', () => {
  let component: GraduatetraineeUpdateComponent;
  let fixture: ComponentFixture<GraduatetraineeUpdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GraduatetraineeUpdateComponent]
    });
    fixture = TestBed.createComponent(GraduatetraineeUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
