import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NumberOfOrdersComponent } from './number-of-orders.component';

describe('NumberOfOrdersComponent', () => {
  let component: NumberOfOrdersComponent;
  let fixture: ComponentFixture<NumberOfOrdersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NumberOfOrdersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NumberOfOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
