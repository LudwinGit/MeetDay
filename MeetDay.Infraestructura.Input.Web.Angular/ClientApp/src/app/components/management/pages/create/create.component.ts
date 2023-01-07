import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Document } from 'src/app/shared/Model/Document';
import { ManagementDto } from 'src/app/shared/Model/Management/ManagementDto';
import { FunctionsService } from 'src/app/utilities/functions.service';
import { ManagementService } from '../../management.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
})
export class CreateComponent implements OnInit {
  documentos: Document[] = [];
  documentosDisponibles: Document[] = [
    { id: 1, name: 'DPI' },
    { id: 2, name: 'PASAPORTE' },
    { id: 3, name: 'LICENCIA' },
  ];
  documentoActual: number = 0;
  management: ManagementDto = {
    name: '',
    documents: [],
    id: 0,
    observation: '',
    state: '',
  };
  constructor(
    private router: Router,
    private _service: ManagementService,
    private _utils: FunctionsService
  ) {}

  ngOnInit(): void {}

  cancelar() {
    this.router.navigate(['managements']);
  }

  obtenerDocumentos() {
    // this._service.getAll().subscribe((response) => {
    //   console.log('====================================');
    //   console.log(response.Result);
    //   console.log('====================================');
    // });
  }

  agregarDocumento() {
    let doc = this.documentosDisponibles.find(
      (x) => x.id == this.documentoActual
    );
    if (doc) {
      this.documentos.push(doc);
      this.documentosDisponibles = this.documentosDisponibles.filter(
        (f) => f.id != this.documentoActual
      );
      this.documentoActual = 0;
    }
  }

  crear() {
    if (this.management) {
      this.management.documents = this.documentos;
      this._utils.loading(1, 'Creando gestión...');
      this._service.create(this.management).subscribe(
        (response) => {
          this._utils.loading(0);
          if (response.success) {
            this._utils.showAlert(true, 'Gestión agregada.');
            this.router.navigate(['managements']);
          }
          console.log('====================================');
          console.log(response.success);
          console.log('====================================');
        },
        (error) => {
          this._utils.loading(0);
          console.error(error);
          this._utils.showAlert(false, 'Ocurrio un error al crear.');
        }
      );
    }
  }
}
