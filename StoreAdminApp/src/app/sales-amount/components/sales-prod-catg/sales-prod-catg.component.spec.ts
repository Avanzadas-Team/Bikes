import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesProdCatgComponent } from './sales-prod-catg.component';

describe('SalesProdCatgComponent', () => {
  let component: SalesProdCatgComponent;
  let fixture: ComponentFixture<SalesProdCatgComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SalesProdCatgComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SalesProdCatgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
