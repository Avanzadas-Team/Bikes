import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProdSalesComponent } from './prod-sales.component';

describe('ProdSalesComponent', () => {
  let component: ProdSalesComponent;
  let fixture: ComponentFixture<ProdSalesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProdSalesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdSalesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
