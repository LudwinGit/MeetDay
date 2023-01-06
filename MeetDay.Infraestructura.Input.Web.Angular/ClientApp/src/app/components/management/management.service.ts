import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { ResponseObject } from 'src/app/shared/ResponseObject';

@Injectable({
  providedIn: 'root',
})
export class ManagementService {
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) {}

  create(managementObj: any) {
    return this.http.post<any>(`${this.baseUrl}api/management/create`, managementObj);
  }

  getAll() {
    return this.http.get<ResponseObject>(`${this.baseUrl}api/management`);
  }
}
