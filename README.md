# Lazurit

### Migrations

> dotnet ef migrations add Init -s "Src\Apps\LazuritApp\Lazurit\Web\Lazurit.Web" -p "Src\Apps\LazuritApp\Lazurit\Lazurit.Content.Database" -c "Lazurit.Content.Database.Context.ContentContext"
>dotnet ef database update -s "Src\Apps\LazuritApp\Lazurit\Web\Lazurit.Web" -p "Src\Apps\LazuritApp\Lazurit\Lazurit.Content.Database" -c "Lazurit.Content.Database.Context.ContentContext"

