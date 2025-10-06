# 📚 Bookstore API

> ⚠️ **Work in Progress** - This project is currently under active development. Features are being implemented incrementally following Clean Architecture principles.

A modern RESTful API for managing a bookstore built with .NET 9 and Clean Architecture principles. This project demonstrates enterprise-level software development practices with comprehensive authentication, authorization, and CRUD operations.

## 🌟 Overview

The Bookstore API enables users to register, authenticate, browse books, and place orders. It features role-based access control with separate permissions for regular users and administrators, making it suitable for real-world e-commerce scenarios.

### 🚧 Current Development Status

This project is being developed incrementally to sharpen .NET development skills and demonstrate Clean Architecture implementation. The foundation has been established with:

- ✅ **Project Structure**: Clean Architecture layers properly organized
- ✅ **Domain Layer**: Book and User entities with comprehensive business logic
- ✅ **Infrastructure**: Entity Framework Core setup with SQL Server and User support
- ✅ **Application Layer**: Book DTOs with comprehensive validation attributes
- ✅ **API Foundation**: ASP.NET Core Web API with Swagger documentation
- ✅ **Input Validation**: DataAnnotations validation implemented for Book DTOs
- ✅ **Role-Based Design**: User roles (User/Admin) prepared for authorization
- 🚧 **Authentication**: JWT implementation in progress
- 🚧 **CRUD Operations**: Book management endpoints in development
- 🚧 **Order System**: Order management features planned

**Note**: Some features mentioned in this README are planned but not yet implemented. Check the [Upcoming Features](#-upcoming-features) section for the current roadmap.

## 🏗️ Architecture

This project follows **Clean Architecture** principles with clear separation of concerns:

```
src/
├── Bookstore.Domain/          # Business entities and domain logic
├── Bookstore.Application/     # Application services and DTOs
├── Bookstore.Infrastructure/  # Data access and external concerns
└── Bookstore.Api/            # Web API controllers and configuration
test/
└── Bookstore.Tests/          # Unit and integration tests
```

## 🚀 Tech Stack

- **Backend**: ASP.NET Core Web API (.NET 9)
- **Database**: SQL Server (LocalDB/Azure SQL)
- **ORM**: Entity Framework Core 9.0
- **Authentication**: JWT Bearer Tokens
- **Documentation**: Swagger/OpenAPI
- **Testing**: xUnit, Moq
- **Deployment**: Azure App Service (planned)

## ✨ Core Features

### 🔐 Authentication & Authorization (Planned)
- User registration and login
- JWT token-based authentication
- Role-based access control (User, Admin)
- Secure password hashing

### 📚 Book Management (In Development)
| Method | Endpoint | Description | Access | Status |
|--------|----------|-------------|--------|--------|
| `GET` | `/api/books` | List all books with pagination | Public | 🚧 Planned |
| `GET` | `/api/books/{id}` | Get book details | Public | 🚧 Planned |
| `POST` | `/api/books` | Add new book | Admin only | 🚧 Planned |
| `PUT` | `/api/books/{id}` | Update book | Admin only | 🚧 Planned |
| `DELETE` | `/api/books/{id}` | Delete book | Admin only | 🚧 Planned |

### 🛍 Order Management (Planned)
| Method | Endpoint | Description | Access | Status |
|--------|----------|-------------|--------|--------|
| `POST` | `/api/orders` | Place order for books | Authenticated | 🚧 Planned |
| `GET` | `/api/orders` | View user's order history | Authenticated | 🚧 Planned |

## 🗃️ Database Schema

### Users
```sql
Users
├── Id (Guid, PK)
├── Username (string)
├── Email (string)
├── PasswordHash (string)
└── Role (enum: User, Admin)
```
**Status**: ✅ **Entity Implemented** - Domain entity and DbSet configured

### Books
```sql
Books
├── Id (Guid, PK)
├── Title (string)
├── Author (string)
├── Price (decimal)
└── StockQuantity (int)
```
**Status**: ✅ **Entity Enhanced** - Business logic methods (AddStock, RemoveStock) and validation added

### Orders
```sql
Orders
├── Id (Guid, PK)
├── UserId (Guid, FK)
├── BookId (Guid, FK)
├── Quantity (int)
└── OrderDate (DateTime)
```
**Status**: 🚧 **Planned** - Entity and relationships to be implemented

## 🚽️ Getting Started

> ⚠️ **Note**: The application is currently in development. Some setup steps may not work as expected until core features are fully implemented.

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb) or SQL Server instance
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/aceladines/Bookstore-API.git
   cd Bookstore-API
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Update connection string**
   
   Edit `src/Bookstore.Api/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BookstoreDB;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

4. **Create and migrate database**
   ```bash
   dotnet ef database update --project src/Bookstore.Infrastructure --startup-project src/Bookstore.Api
   ```

5. **Run the application**
   ```bash
   dotnet run --project src/Bookstore.Api
   ```

6. **Access the API**
   - API: `https://localhost:7000`
   - Swagger UI: `https://localhost:7000/swagger`

## 🧪 Testing

Run the test suite:
```bash
dotnet test
```

## 📚 API Documentation

The API is documented using OpenAPI/Swagger. When running the application in development mode, navigate to `/swagger` to explore the interactive documentation.

### Sample Requests (Planned)

> ⚠️ **Note**: These endpoints are not yet implemented. They represent the planned API structure.

**Register a new user:**
```json
POST /api/auth/register
{
  "username": "john_doe",
  "email": "john@example.com",
  "password": "SecurePass123!"
}
```

**Add a new book (Admin only):**
```json
POST /api/books
Authorization: Bearer <jwt_token>
{
  "title": "Clean Architecture",
  "author": "Robert C. Martin",
  "price": 29.99,
  "stockQuantity": 50
}
```

## 🔮 Upcoming Features

- [x] Clean Architecture implementation
- [x] Domain entities and DTOs
- [x] Database context setup
- [x] Enhanced domain entities (User, Book with business logic)
- [x] Book DTO validation with DataAnnotations (UpdateBookDto, PartialUpdateBookDto)
- [x] Role-based access control foundation (User/Admin roles)
- [x] Improved encapsulation and business methods
- [ ] JWT Authentication implementation
- [ ] Authentication DTOs with validation (RegisterDto, LoginDto)
- [ ] User registration and login endpoints
- [ ] Books CRUD operations with controllers
- [ ] Order entity and management system
- [ ] Pagination and filtering
- [ ] Database seeding with sample data
- [ ] Comprehensive unit tests
- [ ] Integration tests
- [ ] Azure deployment configuration
- [ ] CI/CD pipeline setup

## 🎯 Development Purpose

This project serves as a practical learning exercise to:
- **Sharpen .NET development skills** with the latest .NET 9 features
- **Master Clean Architecture** implementation in real-world scenarios
- **Practice enterprise patterns** like Repository, CQRS, and DDD
- **Explore modern development practices** including JWT authentication, API versioning, and comprehensive testing

The incremental development approach allows for focused learning on each architectural layer and design pattern.

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Your Name** - [@aceladines](https://github.com/aceladines)

## 📞 Support

If you have any questions or need help with setup, please [open an issue](https://github.com/aceladines/Bookstore-API/issues) or reach out via email.

---

⭐ **Star this repository if you found it helpful!** ⭐