dotnet ef dbcontext scaffold "Host=localhost;Database=XFramework;Username=dbAdmin;Password=4*5WD-K8%f*NqmPY" Npgsql.EntityFrameworkCore.PostgreSQL -o DataTransferObjects -f --project ../PaymentGateways.Domain.csproj --schema "Application" --schema "Identity" --schema "GeoLocation" --schema "Finance" --schema "Audit" --schema "Registry" --schema "UserData" --schema "Wallet" --schema "BusinessIncome" --schema "Integration.PaymentGateway"

pause