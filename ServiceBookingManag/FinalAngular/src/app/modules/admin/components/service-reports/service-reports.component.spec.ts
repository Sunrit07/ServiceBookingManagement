import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceReportsComponent } from './service-reports.component';

describe('ServiceReportsComponent', () => {
  let component: ServiceReportsComponent;
  let fixture: ComponentFixture<ServiceReportsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ServiceReportsComponent]
    });
    fixture = TestBed.createComponent(ServiceReportsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
