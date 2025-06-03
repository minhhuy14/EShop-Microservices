# EShop-Microservices
My name is Le Minh Huy, This is my personal project, providing in-depth knowledge about .NET 8 by applying with **Microservices Architecture**, **DDD**, **CQRS**, **Vertical Slice** and **Clean Architecture**. One of the goals of this project is to practice and deepen my understanding of building microservices with .NET.

# Technology used
## Back-end
- **RESTful APIs implementation** using [**ASP.NET Core**](https://dotnet.microsoft.com/en-us/apps/aspnet)
- Applied **Vertical Slice Architecture**, **CQRS**, **DDD**, **Clean Architecture**
- Used [**MediatR**](https://github.com/jbogard/MediatR) for commands, queries, and pipeline behaviors
- Validation with [**FluentValidation**](https://fluentvalidation.net/)
- Data access using [**Entity Framework Core**](https://learn.microsoft.com/en-us/ef/core/) (SQL Server, SQLite) and [**Marten**](https://martendb.io/) (PostgreSQL)
- In-memory data with [**Redis**](https://redis.io/)
- Asynchronous communication using [**RabbitMQ**](https://www.rabbitmq.com/) with [**MassTransit**](https://masstransit-project.com/)
- Synchronous [**gRPC**](https://grpc.io/) between services
- Logging, Health Checks, Exception Handling across services
- API Gateway with [**YARP**](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/servers/yarp/getting-started?view=aspnetcore-9.0) applying route/cluster/transform configuration
- Applied design patterns: **Proxy**, **Decorator**, **Cache-aside**, **UnitOfWork**, **Generic Repository**
- Dockerized services and databases using [**Docker Compose**](https://docs.docker.com/compose/)


## Front-end

- Built Web UI with [**ASP.NET Core Razor Pages**](https://learn.microsoft.com/en-us/aspnet/core/razor-pages?view=aspnetcore-6.0) and [**Bootstrap 4**](https://getbootstrap.com/docs/4.0/)
- API consumption via [**Refit HttpClientFactory**](https://github.com/reactiveui/refit)
- Served via **YARP API Gateway**

# How to Run

1. You need to have the Docker Desktop with Docker compose on your machine
2. Clone this repository to your machine
3. Open terminal in this repository folder
4. Run the following commands in order:

```bash
docker-compose up -d
```
5. All done, you can access:
- Frontend: http://localhost:6005
- Backend: 
  - Catalog Service: http://localhost:6000
  - Basket Service: http://localhost:6001
  - Discount Grpc Service: http://localhost:6002
  - Order Service: http://localhost:6003
  - Gateway: http://localhost:6004
