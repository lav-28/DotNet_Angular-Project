import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraduatetraineeListComponent } from './graduatetrainee-list.component';

describe('GraduatetraineeListComponent', () => {
  let component: GraduatetraineeListComponent;
  let fixture: ComponentFixture<GraduatetraineeListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GraduatetraineeListComponent]
    });
    fixture = TestBed.createComponent(GraduatetraineeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
