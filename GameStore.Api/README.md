# Game Store API

##Starting SQL Server

```powershell
$sa_password = "[SA PASSWORD HERE]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -e "MSSQL_PID=Evaluation" -p 1433:1433  -v sqlvolume:/var/opt/mssql  --name sqlpreview --hostname sqlpreview -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04
```

##setting connection string into secrete manager
```powershell
$sa_password = "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost; Database=GameStore; User Id=sa; Password=$sa_password; TrustServerCerificate=true"
```
###to ensure saving of connection string to secret 
dotnet user-secrets list