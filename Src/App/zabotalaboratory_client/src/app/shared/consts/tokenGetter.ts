export class TokenGetter {
  public static getToken(): string{
    return localStorage.getItem("jwt");
  }
}
