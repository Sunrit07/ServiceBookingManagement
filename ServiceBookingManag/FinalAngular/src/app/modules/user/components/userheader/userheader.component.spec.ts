import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserheaderComponent } from './userheader.component';

describe('UserheaderComponent', () => {
  let component: UserheaderComponent;
  let fixture: ComponentFixture<UserheaderComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserheaderComponent]
    });
    fixture = TestBed.createComponent(UserheaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
