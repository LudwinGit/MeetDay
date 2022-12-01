import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import Swal, { SweetAlertIcon } from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})

/**Centraliza diferentes funciones repetitivas, las cuales son usadas desde diferentes partes del sistema */
export class FunctionsService {

  constructor(private _Router: Router) { }

  /**
   * Almacena el parametro recibido en SessionStorage
   * @param data Recibe un objeto any o variable
   * @param keyName Nombre con el que se guardara la data de la solicitud
   */
  setData(data: any, keyName: string = 'data'){
    sessionStorage.setItem(keyName, JSON.stringify(data))
  }

  /**
   * Obtiene y retorna lo almacenado en el SessionStorage
   * @param keyName Nombre con el que se guardara la data de la solicitud
   * @returns {any} retorna un objeto
   */
  getData(keyName: string = 'data'):any{
    return JSON.parse(sessionStorage.getItem(keyName)??"");
  }

  /**
   * Elimina los datos registrados en el SessionStorage
   * @param keyName Nombre con el que se guardara la data de la solicitud
   */
  deleteData(keyName: string = 'data'){
    sessionStorage.removeItem(keyName)
  }


/**
 * Funcion que lanza una alerta del plugin showAlert
 * @param tipo Define el tipo de alerta a mostrarse;  true = success, false= error
 * @param message Recibe el mensaje que se mostrara en la alerta
 */
  showAlert(tipo: boolean | SweetAlertIcon, message: string){

    /**
     * Anteriormente la funcion solo se utilizaba con booleanos
     * Por ese motivo se utiliza este if
     */
    let icon: SweetAlertIcon;
    let title: string;

     if(typeof tipo == 'boolean'){
        icon = (tipo)? 'success' : 'error';
        title = (tipo)? 'Completado' : 'error';
      }else{
        icon = tipo;

    title = (tipo == 'success')? 'Completado' :
            (tipo == 'error')? 'Error' :
            (tipo == 'warning')? 'Advertencia' :
            (tipo == 'info')? 'Informacion': 'Completado';

      }


    Swal.fire({
      icon: icon,
      title: title,
      text: message,
      confirmButtonColor: '#0779E4',
      allowOutsideClick: false,
      allowEscapeKey: false
    })

  }

  /**
   * Funcion utilizada para mostrar una alerta success de confirmacion para el usuario
   * que redirige a una ruta en especifico
   * @param type tipo de alerta a mostrar
   * @param message mensaje que desea mostrar en la alerta
   * @param ruta Ruta a la cual desea redirigir
   */
  showAlertRedirect(type: SweetAlertIcon, message: string, ruta: string){


    let title = (type == 'success')? 'Completado' :
                (type == 'error')? 'Error' :
                (type == 'warning')? 'Advertencia' :
                (type == 'info')? 'Informacion': 'Completado';

    Swal.fire({
      title: title,
      text: message,
      icon: type,
      showCancelButton: false,
      confirmButtonColor: '#0779E4',
      confirmButtonText: 'OK',
      allowOutsideClick: false,
      allowEscapeKey: false
    }).then((result) => {

      if (result.isConfirmed) {
        this._Router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
          this._Router.navigate([ruta]);
        });
      }

    })
  }

  /**
   * Mustra una alerta al usuario y retorna el ok del ususuario en un callback
   * @param type tipo de alerta a mostrar
   * @param title Titulo de la alerta
   * @param message mensaje que desea mostrar en la alerta
   * @param ruta Ruta a la cual desea redirigir
   */
   showAlertConfirm(type: SweetAlertIcon, title: string, message: string, callback: any){

    Swal.fire({
      title: title,
      text: message,
      icon: type,
      showCancelButton: false,
      confirmButtonColor: '#0779E4',
      confirmButtonText: 'OK',
      allowOutsideClick: false,
      allowEscapeKey: false
    }).then((result) => {

      callback(result.isConfirmed);

    })
  }


    /**
   * Muestra una alerta con un contador, que ejecuta una accion al cerrarse automaticamente
   * @param timer Tiempo en el que se cerrara la alerta
   * @param type tipo de alerta a mostrar
   * @param message mensaje que desea mostrar en la alerta
   * @param ruta Ruta a la cual desea redirigir
   */

  showAlertTimerConfirm(timer: number, type: SweetAlertIcon, message: string, ruta: string){

    let title = (type == 'success')? 'Completado' :
                (type == 'error')? 'Error' :
                (type == 'warning')? 'Advertencia' :
                (type == 'info')? 'Informacion': 'Completado';

    Swal.fire({
      title: title,
      text: message,
      icon: type,
      timer: timer,
      timerProgressBar: true,
      showCancelButton: false,
      confirmButtonColor: '#0779E4',
      confirmButtonText: 'OK',
      allowOutsideClick: false,
      allowEscapeKey: false
    }).then((result) => {

      if (result.isConfirmed) {

      }else{
        this._Router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
          this._Router.navigate([ruta]);
        });
      }

    })

  }

  /**
   * Muestra un loading de SweetAlert en la pantalla
   * @param tipo Define el tipo de alerta a mostrarse;  1 = Mostrar, 0= Ocultar
   * @param message {?} (Opcional) Recibe el mensaje que quieree mostrar en la alerta
   */
  loading(tipo: number, message: string = 'Por favor espere...'){

    if(tipo == 1){
      Swal.fire({
        allowOutsideClick: false,
        icon: 'info',
        text: message
      });
      Swal.showLoading();

    }else{
      Swal.close();
    }

  }


  /**
   * Retorna un objeto con la configuracion de datatables para que este siempre centralizada
   * @returns {dtOptiona} Objeto de opciones DataTable
   */
  getDtOptions(){

    return {
      // Declare the use of the extension in the dom parameter
      deferRender: true,
    	retrieve: true,
    	processing: true,
      lengthChange: true,
    	language: {
    		processing: "Procesando...",
        sLengthMenu: "Mostrar _MENU_ registros",
    		zeroRecords: "No se encontraron resultados",
    		emptyTable: "Ningún dato disponible en esta tabla",
    		info: "Mostrando registros del _START_ al _END_",
    		infoEmpty: "Mostrando registros del 0 al 0 ",
    		infoFiltered: "(de _MAX_ registros)",
    		infoPostFix: "",
    		search: "Buscar:",
    		url: "",
    		loadingRecords: "Cargando...",
    		paginate: {
    			first: "Primero",
    			last: "Último",
    			next: ">",
    			previous: "<",
    		},
    		aria: {
    			sortAscending: ": Activar para ordenar la columna de manera ascendente",
    			sortDescending:
    				": Activar para ordenar la columna de manera descendente",
    		},
    	}
    };

  }



}
