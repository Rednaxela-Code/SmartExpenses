# SmartExpenses

SmartExpenses is a modern application for managing personal expenses, built with a layered architecture consisting of a frontend, backend, and shared logic.

## 📁 Project Structure

- `SmartExpenses.Client` – Frontend built with Vue.js  
- `SmartExpenses.Api` – Backend API built with ASP.NET Core (.NET 9)  
- `SmartExpenses.Core` – Domain logic and interfaces  
- `SmartExpenses.Data` – Data access layer using Entity Framework  
- `SmartExpenses.Shared` – Shared models and DTOs  

## ⚙️ Requirements

Ensure the following tools are installed on your development machine:

- [Docker](https://www.docker.com/) and [Docker Compose](https://docs.docker.com/compose/)  
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)  

## 🚀 Running the Project Locally with Docker Compose

1. **Clone the repository**

   ```bash
   git clone https://github.com/Rednaxela-Code/SmartExpenses
   cd SmartExpenses
   ```

2. **Start the Docker containers**

   ```bash
   docker-compose up
   ```

   This will build and start PostgreSQL and PgAdmin containers.

## 🧪 Running

### Backend

Navigate to the project directory and run:

```bash
cd SmartExpenses.Api
dotnet run watch
```

### Frontend Tests

From the `SmartExpenses.Client` directory:

```bash
npm install
npm run dev
```

## 📝 Notes

- Make sure the ports defined in `docker-compose.yml` are not used by other applications.
- If you make changes to the code, rebuild or restart the relevant containers to apply the changes.

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
