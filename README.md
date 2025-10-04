# 📚 Bookstore API

A modern RESTful API for managing a bookstore built with .NET 9 and Clean Architecture principles. This project demonstrates enterprise-level software development practices with comprehensive authentication, authorization, and CRUD operations.

## 🌟 Overview

The Bookstore API enables users to register, authenticate, browse books, and place orders. It features role-based access control with separate permissions for regular users and administrators, making it suitable for real-world e-commerce scenarios.

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

### 🔐 Authentication & Authorization
- User registration and login
- JWT token-based authentication
- Role-based access control (User, Admin)
- Secure password hashing

### 📖 Book Management
| Method | Endpoint | Description | Access |
|--------|----------|-------------|--------|
| `GET` | `/api/books` | List all books with pagination | Public |
| `GET` | `/api/books/{id}` | Get book details | Public |
| `POST` | `/api/books` | Add new book | Admin only |
| `PUT` | `/api/books/{id}` | Update book | Admin only |
| `DELETE` | `/api/books/{id}` | Delete book | Admin only |

### 🛒 Order Management
| Method | Endpoint | Description | Access |
|--------|----------|-------------|--------|
| `POST` | `/api/orders` | Place order for books | Authenticated |
| `GET` | `/api/orders` | View user's order history | Authenticated |

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

### Books
```sql
Books
├── Id (Guid, PK)
├── Title (string)
├── Author (string)
├── Price (decimal)
└── StockQuantity (int)
```

### Orders
```sql
Orders
├── Id (Guid, PK)
├── UserId (Guid, FK)
├── BookId (Guid, FK)
├── Quantity (int)
└── OrderDate (DateTime)
```

## 🛠️ Getting Started

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

### Sample Requests

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
- [ ] JWT Authentication implementation
- [ ] User registration and login endpoints
- [ ] Books CRUD operations
- [ ] Order management system
- [ ] Input validation and error handling
- [ ] Pagination and filtering
- [ ] Database seeding with sample data
- [ ] Comprehensive unit tests
- [ ] Integration tests
- [ ] Azure deployment configuration
- [ ] CI/CD pipeline setup

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