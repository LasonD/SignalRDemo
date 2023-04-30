export interface LoginRequest {
  email: string;
  password: string;
}

export interface RegisterRequest {
  email: string;
  password: string;
  userName: string;
  jurisdictions: string[];
}

export interface AuthResult {
  userId: string;
  email: string;
  username: string;
  accessToken: string;
  jurisdictions: string[];
  expiresIn: number;
}

export class User implements UserModel {
  constructor(public userId: string,
              public username: string,
              public email: string,
              public _token: string,
              public expiresIn: number | null = null,
              public readonly expirationDate: Date | null = null) {
    if (expiresIn) {
      this.expirationDate = new Date(new Date().getTime() + expiresIn * 1000);
    } else if (expirationDate) {
      this.expirationDate = new Date(expirationDate);
    }
  }

  get token() {
    if (!this.expirationDate || new Date().getTime() > this.expirationDate.getTime()) {
      return null;
    }

    return this._token;
  }
}

export interface UserModel {
  expirationDate: Date | null,
  userId: string,
  username: string,
  email: string,
  _token?: string | null,
  expiresIn: number | null,
}
