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

export class User {
  constructor(public userId: string,
              public username: string,
              public email: string,
              private _token: string,
              private expiresIn: number | null = null,
              private readonly expirationDate: Date | null = null) {
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
