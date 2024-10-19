import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StreamAddComponent } from './stream-add.component';

describe('StreamAddComponent', () => {
  let component: StreamAddComponent;
  let fixture: ComponentFixture<StreamAddComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StreamAddComponent]
    });
    fixture = TestBed.createComponent(StreamAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
