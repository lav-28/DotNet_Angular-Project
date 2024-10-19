import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StreamUpdateComponent } from './stream-update.component';

describe('StreamUpdateComponent', () => {
  let component: StreamUpdateComponent;
  let fixture: ComponentFixture<StreamUpdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StreamUpdateComponent]
    });
    fixture = TestBed.createComponent(StreamUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
