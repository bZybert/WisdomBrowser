import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpErrorResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ErrorInterceptor implements HttpInterceptor {
  constructor() { }
  intercept(req: import('@angular/common/http').HttpRequest<any>, next: import('@angular/common/http')
    .HttpHandler): import('rxjs').Observable<import('@angular/common/http').HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError(error => {
        if (error.status === 401) {
          return throwError(error.statusText);
        }
        if (error instanceof HttpErrorResponse) {
          const applicationError = error.headers.get('Application-Error');
          if (applicationError) {
            return throwError(applicationError);
          }

          const serwerError = error.error;
          let modelStateError = '';
          if (serwerError.errors && serwerError.errors === 'object') {
            for (const key in serwerError.errors) {
              if (serwerError.error[key]) {
                modelStateError += serwerError.error[key] + '\n';
              }
            }
          }
          return throwError(modelStateError || serwerError || 'Server Error');
        }
      })
    );
  }
}

export const ErrorInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: ErrorInterceptor,
  multi: true
};

