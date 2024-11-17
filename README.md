
# **SchoolProject In Clean Architecture**

## **Overview**
SchoolProject is a web API developed using **ASP.NET Core** and **Clean Architecture** principles. It is built to manage school-related operations with high efficiency, scalability, and maintainability. The project adopts modern design patterns and follows best practices in software development.

---

## **Features**
### **Core Architecture**
1. **Clean Architecture**: Ensures separation of concerns and maintainability.  
2. **CQRS Design Pattern**: Optimized for command-query separation for better performance and readability.  
3. **Generic Repository Design Pattern**: Simplifies database operations and promotes reusability.  

### **API Enhancements**
4. **Pagination**: Efficient data fetching with customizable pagination.  
5. **Localization**: Support for multiple languages in data and responses.  
6. **Validation**: Input validations using **FluentValidation** and **Data Annotations**.  
7. **Swagger Integration**: API documentation with JWT token support for testing.

### **Security**
8. **Identity Integration**: User management and authentication.  
9. **JWT Token Authentication**: Secure API access using JSON Web Tokens.  
10. **Role-Based Authorization**: Granular access control using roles and claims.  
11. **CORS Support**: Enables cross-origin requests securely.  

### **Database Operations**
12. **Configurations**: Leveraging **Fluent API** and **Data Annotations** for entity configurations.  
13. **Database Procedures**: Includes views, stored procedures, and functions accessible via endpoints.  

### **Additional Services**
14. **Email Service**: Automated email notifications.  
15. **Image Upload**: Simplified image handling with storage integration.  

### **Utilities**
16. **Filters**: For custom request/response handling.  
17. **Logs**: Comprehensive logging for debugging and monitoring.

### **Testing**
18. **Unit Testing**: Ensures reliability with **XUnit**.

---

## **Technologies Used**
- **ASP.NET Core Web API**  
- **Entity Framework Core**  
- **JWT Authentication**  
- **Swagger UI**  
- **FluentValidation**  
- **XUnit**  

---

## **Setup Instructions**
1. Clone the repository:  
   ```bash
   git clone https://github.com/AdelMuhammad-23/SchoolManagementSystem.git
   cd SchoolProject
   ```
2. Set up the database connection in `appsettings.json`.
3. Run database migrations:  
   ```bash
   dotnet ef database update
   ```
4. Start the application:  
   ```bash
   dotnet run
   ```

---

## **Project Structure**
```plaintext
- SchoolProject
  - API
  - Core
  - Infrastructure
  - Tests
```

---

## **Future Enhancements**
- Adding real-time notifications.  
- Integrating advanced analytics.  
- Supporting mobile platforms.
