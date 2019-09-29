
export enum NotificationType {
  success = "success",
  error = "danger",
  info = "info",
}

export class Notification {
  type: NotificationType;
  message: string;
  constructor(type: NotificationType, message: string) {
    this.type = type;
    this.message = message;
  }
}
