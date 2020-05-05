export class TokenGetter {
  static GetToken(): string{
    return localStorage.getItem("jwt");
  }
}
