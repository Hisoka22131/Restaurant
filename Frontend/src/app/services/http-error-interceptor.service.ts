import {HttpErrorResponse, HttpEvent, HttpHandler, HttpHeaders, HttpRequest} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {catchError, Observable, throwError} from 'rxjs';
import {AlertifyService} from "./view/alertify.service";
import {Router} from "@angular/router";
import {environment} from "../../../environments/environments";
import {CookieService} from "ngx-cookie-service";

@Injectable({
  providedIn: 'root'
})
export class HttpErrorInterceptorService {

  constructor(private alertify: AlertifyService,
              private router: Router) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    let authReq: HttpRequest<any>;

    // Проверяем, отправляется ли файл
    if (request.body instanceof FormData) {
      // Для FormData не устанавливаем заголовки
      authReq = request.clone({
        withCredentials: true
      });
    } else {
      // Если это не FormData, то устанавливаем заголовки
      const headers = new HttpHeaders({
        'Content-Type': 'application/json'
      });

      authReq = request.clone({
        headers: headers,
        withCredentials: true
      });
    }

    // Передаем измененный запрос дальше по цепочке обработки
    return next.handle(authReq).pipe(
      catchError((error: HttpErrorResponse) => {
        this.checkError(error);
        return throwError(error);
      })
    );
  }

  checkError(error: HttpErrorResponse) {
    if (error.status === 401) {
      // Перенаправляем на страницу авторизации
      this.router.navigate(['/login']);
      this.alertify.warning("Необходима авторизация");
    }

    if (error.status === 403) {
      this.router.navigate(['/dish-list']);
      this.alertify.message("У вас нет доступа к текущем ресурсу");
    }

    if (error.status === 415) {
      this.alertify.error("Неверные данные");
    }

    if (error.status === 500) {
      this.alertify.error("Произошла ошибка на сервере");
    }
  }
}
