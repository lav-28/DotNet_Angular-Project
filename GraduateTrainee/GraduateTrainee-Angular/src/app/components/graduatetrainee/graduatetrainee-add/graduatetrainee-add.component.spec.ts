import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraduatetraineeAddComponent } from './graduatetrainee-add.component';

describe('GraduatetraineeAddComponent', () => {
  let component: GraduatetraineeAddComponent;
  let fixture: ComponentFixture<GraduatetraineeAddComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GraduatetraineeAddComponent]
    });
    fixture = TestBed.createComponent(GraduatetraineeAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
