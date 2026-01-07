📱 Mobile Shops System

A microservices-based multi-shop system built with ASP.NET Core, designed to support two independent mobile shops with isolated data, centralized authentication, and scalable deployment using Docker.

🧩 Project Overview
The Mobile Shops System is a scalable backend solution that demonstrates modern microservices architecture. Each shop operates independently with its own database, while shared concerns such as authentication and routing are handled centrally.

The system focuses on:

Scalability

Security

Service isolation

Clean architecture

🏗️ Architecture
Microservices Architecture

Ocelot API Gateway for routing and security

Dedicated Authentication Service

Separate database per shop

Dockerized services



MobileShopsSystem/
│
├── docker-compose.yml
├── README.md
│
├── ApiGateway/
│   └── Ocelot.ApiGateway/
│       ├── ocelot.json
│       └── Dockerfile
│
├── Services/
│   ├── AuthService/
│   │   └── Auth.API/
│   │       └── Dockerfile
│   │
│   ├── ShopAService/
│   │   └── ShopA.API/
│   │       └── Dockerfile
│   │
│   └── ShopBService/
│       └── ShopB.API/
│           └── Dockerfile
│
├── UI/
│   └── Mvc/
│       └── Dockerfile
│
├── Shared/
│   └── Common/
│
└── Databases/
    ├── AuthDb/
    ├── ShopADb/
    └── ShopBDb/




🔧 Technologies Used
ASP.NET Core Web APIs

ASP.NET Core MVC

Ocelot API Gateway

JWT Authentication

Role-Based Authorization

Docker & Docker Compose

SQL Server (Dockerized)

Custom Middleware

Rate Limiting & Caching

🔐 Authentication & Authorization
A dedicated Authentication Service handles:

User authentication

JWT token generation

JWT tokens are validated across all services

Role-based authorization is enforced

Custom middleware is used to protect sensitive endpoints

🐳 Docker & Containerization
Each microservice runs in its own Docker container

Authentication Service is containerized separately

API Gateway runs in its own container

Two separate database containers:

One database per shop

Ensures data isolation and independent scaling

Docker Compose is used to orchestrate all services

🗄️ Databases
Shop 1 Database → Dedicated container

Shop 2 Database → Dedicated container

Improves:

Data isolation

Fault tolerance

Scalability

Maintainability

⚙️ Features
Multi-shop support

Secure authentication & authorization

Centralized routing with Ocelot

Rate limiting and caching

Scalable and containerized deployment

Clean separation of concerns

🚀 Getting Started
Prerequisites
Docker

Docker Compose

.NET SDK (for local development)

Run the Project
bash
Copy code
docker-compose up --build
Once running:

API Gateway handles all incoming requests

Services communicate internally via Docker networking

📂 Repository
🔗 GitHub Repository
https://github.com/ziadali007/Mobile-Shops

📌 Notes
This project was developed as a freelance project and showcases best practices in:

Microservices design

Secure authentication

Docker-based deployment

Backend scalability
