import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ManagementDto } from 'src/app/shared/Model/Management/ManagementDto';
import { FunctionsService } from 'src/app/utilities/functions.service';
import { ManagementService } from '../../management.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
})
export class ListComponent implements OnInit {
  managements: ManagementDto[] = [];

  constructor(
    private router: Router,
    private _service: ManagementService,
    private _utils: FunctionsService
  ) {}

  ngOnInit(): void {
    this.listado();
  }
  create() {
    this.router.navigate(['managements/create']);
  }

  listado() {
    this._service.getAll().subscribe((response) => {
      if (response.success) {
        this.managements = response.result;
      }
    });
  }
}
