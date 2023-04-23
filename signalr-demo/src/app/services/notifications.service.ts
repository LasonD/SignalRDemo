import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private toastr: ToastrService) { }

  showSuccess(message: string, title?: string): void {
    this.toastr.success(message, title);
  }

  showError(err: Error): void {
    this.toastr.error(JSON.stringify(err), 'Something went wrong');
  }

  showErrorMessage(message: string, title?: string): void {
    this.toastr.error(message, title);
  }

  showInfo(message: string, title?: string): void {
    this.toastr.info(message, title);
  }

  showWarning(message: string, title?: string): void {
    this.toastr.warning(message, title);
  }
}
