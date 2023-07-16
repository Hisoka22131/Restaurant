import {Injectable} from '@angular/core';
import {AbstractControl, FormGroup} from "@angular/forms";

@Injectable({
  providedIn: 'root'
})

/**
 Форма создана для базовых валидаций, чтобы в html не был однотипный и громоздкий код
 **/
export class FormService {

  constructor() {
  }

  isEmpty = (field: any): boolean => field?.invalid ?? false;

}
