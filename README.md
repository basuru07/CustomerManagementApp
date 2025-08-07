# CustomerManagementApp 

A simple Customer Management CRUD application built using **ASP.NET Core 8** following **Clean Architecture** principles. This app is organized into three core layers:

- **API**: Handles HTTP requests and acts as the entry point
- **Core**: Contains business logic, interfaces, and entities
- **Infrastructure**: Implements data access logic using EF Core

---

## 🗂️ Project Structure

```
CustomerManagementApp/
├── CustomerManagement.API/          # Web API project (Presentation Layer)
│   ├── Controllers/                 # API controllers
│   ├── DTOs/                       # Request and response models
│   └── Program.cs                  # Entry point of the app
├── CustomerManagement.Core/         # Core domain logic
│   ├── Entities/                   # Domain entities (e.g., Customer)
│   ├── Interfaces/                 # Service and repository contracts
│   └── Services/                   # Business logic implementation
├── CustomerManagement.Infrastructure/ # Infrastructure and DB logic
│   ├── Data/                       # EF Core DbContext
│   └── Repositories/               # Concrete repository implementations
```

---

## 💡 Features

- Create new customers
- Retrieve all or specific customers
- Update customer details
- Delete customers
- Supports RESTful API standards

---

## 🛠️ Tech Stack

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **Clean Architecture**
- **Swagger** (for API testing)

---

### Run the Application

1. **Clone the repo**
   ```bash
   git clone https://github.com/basuru07/CustomerManagementApp.git
   cd CustomerManagementApp
   ```

2. **Restore packages**
   ```bash
   dotnet restore
   ```

3. **Run the API**
   ```bash
   dotnet run --project CustomerManagement.API
   ```

4. **Open in browser**
   - Swagger UI: https://localhost:5001/swagger
   - API Base URL: https://localhost:5001/api/customer

---

## 📦 CRUD API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/customer | Get all customers |
| GET | /api/customer/{id} | Get customer by ID |
| POST | /api/customer | Add a new customer |
| PUT | /api/customer/{id} | Update customer info |
| DELETE | /api/customer/{id} | Delete customer |

---

