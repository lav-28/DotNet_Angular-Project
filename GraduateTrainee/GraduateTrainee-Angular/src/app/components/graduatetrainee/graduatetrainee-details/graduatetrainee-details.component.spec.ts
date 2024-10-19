import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraduatetraineeDetailsComponent } from './graduatetrainee-details.component';

describe('GraduatetraineeDetailsComponent', () => {
  let component: GraduatetraineeDetailsComponent;
  let fixture: ComponentFixture<GraduatetraineeDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GraduatetraineeDetailsComponent]
    });
    fixture = TestBed.createComponent(GraduatetraineeDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
