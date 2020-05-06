export class TokenGetter {
  public static GetToken(): string{
    return localStorage.getItem("jwt");
  }
}
