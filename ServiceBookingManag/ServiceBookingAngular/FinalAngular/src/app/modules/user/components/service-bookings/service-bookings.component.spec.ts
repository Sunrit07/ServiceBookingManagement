import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceBookingsComponent } from './service-bookings.component';

describe('ServiceBookingsComponent', () => {
  let component: ServiceBookingsComponent;
  let fixture: ComponentFixture<ServiceBookingsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ServiceBookingsComponent]
    });
    fixture = TestBed.createComponent(ServiceBookingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
