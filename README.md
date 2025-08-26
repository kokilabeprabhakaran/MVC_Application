# Educational Library Management System

The **Educational Library Management System** is a role-based web application built with **ASP.NET Core MVC**, **Entity Framework Core**, and **SQL Server**.  

It is designed to provide a secure and scalable solution for managing books, users, and library operations with **Admin** and **User** functionalities.  

---

## Authentication & Authorization
- Secure **JWT + Cookies** based authentication.  
- Role-based access control (**Admin & User**).  
- Role-based redirection (**Admin Dashboard / User Dashboard**).  
- Login & Logout functionality.  

---

## Database & Persistence
- **SQL Server** as the database.  
- **Entity Framework Core**.  
- Fully database-backed system with persistent data.  

---

## Architecture
- **Repository-Service Pattern** for clean business logic separation.  
- Organized with **Areas**: Admin and User.  
- Support for **User Secrets** to protect sensitive information (e.g., connection strings, JWT keys).
- Use of Partial Views for reusability of common UI components (e.g., returning successfull message). 
- **Attribute Routing.** 

---

## Core Functionalities
- **CRUD Operations** (Create, Read, Update, Delete) for library entities.  
- Book management, issue/return handling, and user management.  
- **TempData & ViewBag** used for message passing & feedback.
- **Partial Views** used to simplify UI management and reduce code duplication.
- **Strongly Typed Views.**

---

## Validation & Error Handling
- Client-side validation with **jQuery Unobtrusive**.  
- Server-side validation with **Data Annotations**.  
- Production error handling with **user-friendly messages**.  

---

## User Experience
- Login form with **model binding and validation**.  
- Error handling with **clear feedback messages**.  
- Consistent layout with **Partial Views**.

---

## Technologies Used
- **ASP.NET Core MVC**  

- **Entity Framework Core**  
- **SQL Server**  
- **JWT Authentication + Cookies**  
- **Repository-Service Pattern**  
- **jQuery Validation + Unobtrusive JavaScript**  

---

## Security
- **JWT & Cookies authentication** for secure login.  
- **User Secrets** to prevent exposing sensitive data in GitHub.  
