import {Inject, Injectable} from '@angular/core';
import {environment} from "../../../../environments/environments";
import {map, Observable} from "rxjs";
import {IClient} from "../../client/IClient";
import {IBase} from "../../base/IBase";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export abstract class AbstractService {

  baseApiUrl: string = environment.baseApiUrl;

  abstract getAllEntities(): Observable<IBase[]>

  abstract getEntity(id: number): Observable<IBase>

}
