/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { BookSelectedListComponent } from './book-selected-list.component';

describe('BookSelectedListComponent', () => {
  let component: BookSelectedListComponent;
  let fixture: ComponentFixture<BookSelectedListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookSelectedListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookSelectedListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
