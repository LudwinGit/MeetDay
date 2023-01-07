import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { ManagementDto } from 'src/app/shared/Model/Management/ManagementDto';
import { ResponseObject } from 'src/app/shared/ResponseObject';

@Injectable({
  providedIn: 'root',
})
export class ManagementService {
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) {}

  create(managementObj: ManagementDto) {
    return this.http.post<ResponseObject>(
      `${this.baseUrl}api/management`,
      managementObj
    );
  }

  getAll() {
    return this.http.get<ResponseObject>(`${this.baseUrl}api/management`);
  }
}
