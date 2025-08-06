# 📦 Proyecto Backend - API en C# .NET Core 8.0

Este proyecto es una API REST desarrollada con **.NET Core 8.0**, diseñado para simular la creacion de cuentas y transacciones bancarias

## 🚀 Requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/)

## ⚙️ Configuración del Entorno

1. Clona el repositorio:
   ```bash
   git clone https://github.com/csamillan/BancoDv.git
   cd BancoDv
   ```

2. Restaura las dependencias:
   ```bash
   dotnet restore
   ```

3. Configura la cadena de conexión en `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "BancoDB": "Server=host.docker.internal;Database=BancoDB;User Id=user;Password=password;TrustServerCertificate=True;"
   }
   ```

4. Ejecuta las migraciones (si estás usando Entity Framework):
   ```bash
   dotnet ef database update
   ```

5. Corre la aplicación:
   ```bash
   dotnet run
   ```
