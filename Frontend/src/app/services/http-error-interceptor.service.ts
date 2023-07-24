import {HttpErrorResponse, HttpEvent, HttpHandler, HttpRequest} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {catchError, Observable, throwError} from 'rxjs';
import {AlertifyService} from "./view/alertify.service";

@Injectable({
  providedIn: 'root'
})
export class HttpErrorInterceptorService {

  constructor(private alertify: AlertifyService) {
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
        this.alertify.error(this.setError(error));
        return throwError(error);
      })
    );
  }

  setError(error: HttpErrorResponse): string {
    let errorMessage = 'Unknown error occured';
    if (error.error instanceof ErrorEvent) {
      // Client side error
      errorMessage = error.error.message;
    } else {
      // server side error
      if (error?.status === 401) {
        return error.statusText;
      }

      if (error?.error?.errorMessage && error?.status !== 0) {
        {
          errorMessage = error?.error?.errorMessage;
        }
      }

      if (!error?.error?.errorMessage && error?.error && error?.status !== 0) {
        {
          errorMessage = error?.error;
        }
      }
    }
    return errorMessage;
  }
}
