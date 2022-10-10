import { SignServService } from './signing/sign-serv.service';
import { Injectable, Injector } from '@angular/core';
import { HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
// import {SignServService }
@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor{

  constructor(private injector:Injector) { }
  intercept(req: HttpRequest<any>, next: HttpHandler) {
    let logSer = this.injector.get(SignServService)
    let tokenReq = req.clone({
      setHeaders :{
        Authorization:`Bearer ${logSer.getToken()}`
      }
    })
    return next.handle(tokenReq)
  }

}
