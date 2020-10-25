import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesAmountHomePageComponent } from './sales-amount-home-page.component';

describe('SalesAmountHomePageComponent', () => {
  let component: SalesAmountHomePageComponent;
  let fixture: ComponentFixture<SalesAmountHomePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SalesAmountHomePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SalesAmountHomePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
