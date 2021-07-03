# AdventureWorks.Domain
AdventureWorks domain in ef core published as a github package to be shared between appps.

`dotnet ef dbcontext scaffold "Server=localhost,1433;Database=AdventureWorks;User Id=SA;Password=my_password" Microsoft.EntityFrameworkCore.SqlServer -o Models`

The tables `Production.Document` and `Production.ProductDocument` cant be scaffolded cause [cause](https://github.com/dotnet/efcore/issues/10131)

