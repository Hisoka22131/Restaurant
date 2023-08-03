import {HttpErrorResponse, HttpEvent, HttpHandler, HttpRequest} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {catchError, Observable, throwError} from 'rxjs';
import {AlertifyService} from "./view/alertify.service";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class HttpErrorInterceptorService {

  constructor(private alertify: AlertifyService,
              private router: Router) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Добавляем заголовки к каждому исходящему запросу
    const modifiedRequest = request.clone({
      setHeaders: {
        'Authorization': `Bearer ${localStorage.getItem('token')}`,
        'Content-Type': 'application/json',
      }
    });

    // Передаем измененный запрос дальше по цепочке обработки
    return next.handle(modifiedRequest).pipe(
      catchError((error: HttpErrorResponse) => {
        this.checkError(error);
        return throwError(error);
      })
    );
  }

  checkError(error: HttpErrorResponse){
    if (error.status === 401) {
      // Перенаправляем на страницу авторизации
      this.router.navigate(['/login']);
      this.alertify.warning("Необходима авторизация");
    }

    if (error.status === 403) {
      this.router.navigate(['/dish-list']);
      this.alertify.message("У вас нет доступа к текущем ресурсу");
    }

  }
}
