import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AppHttpInterceptorService implements HttpInterceptor  {

  constructor(public cookieService:CookieService,public router:Router) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // let token = this.cookieService.get('token');
    // const newRequest = req.clone({ setHeaders: {Authorization: 'Bearer '+token}});
    const newRequest = req.clone();
    return next.handle(newRequest).pipe(
      catchError(x=>this.handleError(x))
    );
  }

  private handleError(err: HttpErrorResponse): Observable<any> {
    if (err.status === 401 || err.status === 403) {
        this.router.navigateByUrl(`/login`);
        return of(err.message);
    }
    // handle your auth error or rethrow
    return Observable.throw(err);
}
}
