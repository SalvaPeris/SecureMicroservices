
# Secured Microservices with IS4, OAuth2 and OIDC with Ocelot API Gateway

In this repository, you will see that how to secure microservices with using **standalone Identity Server 4** and backing with **Ocelot API Gateway**. We’re going to protect our ASP.NET Web MVC and API applications with using **OAuth 2 and OpenID Connect** in IS4. Securing your web application and API with tokens, working with claims, authentication and authorization middlewares and applying policies, and so on.

![Overall Picture of Repository](https://github.com/SalvaPeris/SecureMicroservices/assets/79948536/a866e1d6-376b-4642-9bed-72be3fbc139a)

### Movies.API
First of all, we are going to develop **Movies.API** project and protect this API resources with **IS4 OAuth 2.0 implementation**.

### Movies.MVC
After that, we are going to develop Movies.MVC Asp.Net project for Interactive Client of our application. This Interactive Movies.MVC Client application will be secured with OpenID Connect in IdentityServer4.

### Identity Server
Also, we are going to develop centralized standalone **Authentication Server** and **Identity Provider** with implementing IdentityServer4 package and the name of microservice is Identity Server.
Identity Server4 is an open source framework which implements **OpenId Connect and OAuth2 protocols** for .Net Core.
With Identity Server, we can provide authentication and access control for our web applications or Web APIs from a single point between applications or on a user basis.

### Ocelot API Gateway
Lastly, we are going to develop **Ocelot API Gateway** and make secure protected API resources over the Ocelot API Gateway with transferring **JWT web tokens**.
Also over these picture, we have also apply the **claim based authentications**.

* **Movies.Client -> https://localhost:5002/**
* **Movies.API -> https://localhost:5001/**
* **API.Gateway -> https://localhost:5010/**
* **IdentityServer -> https://localhost:5005/**

Check the application with logging the system with below credentials;
* **username: speris**
* **password: speris**
