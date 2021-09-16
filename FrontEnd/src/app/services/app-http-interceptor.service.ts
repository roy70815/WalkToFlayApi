import { CookieService } from 'ngx-cookie-service';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppHttpInterceptorService implements HttpInterceptor  {

  constructor(public cookieService:CookieService) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // let token = this.cookieService.get('token');
    // const newRequest = req.clone({ setHeaders: {Authorization: 'Bearer '+token}});
    const newRequest = req.clone();
    return next.handle(newRequest);
  }
}
