[![Build Status][build-status-shield]][build-status-url] [![LinkedIn][linkedin-shield]][linkedin-url]

# jwt-auth-api

## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Deployment](#deployment)
* [Usage](#usage)
* [Contact](#contact)

## About the project

 ASP .NET Core REST API using JWT(JSON Web Token) for authentication and Role and Policy based authorization, using SQLite database provider, with three-tier variant of multitier(n-tier) architecture: presentation, business and data layer, using service-repository pattern with Inversion of Control container.

### Built with
* ASP .NET Core
* EntityFrameworkCore
* AutoMapper




## Getting Started
These instructions will get you a copy of the project up and running on your local machine, for development and testing purposes. See deployment for notes on how to deploy the project using Docker containerization.

### Prerequisites
- .NET Core 3.1
	For installation see: [https://dotnet.microsoft.com/download/dotnet-core/3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

### Installation

#### Clone the repo
```
git clone https://github.com/krzysztofzajaczkowski/jwt-auth-api
```
#### Visual Studio or Rider
Open .sln file and run project
#### Visual Studio Code
See: [https://code.visualstudio.com/docs/languages/csharp](https://code.visualstudio.com/docs/languages/csharp)
#### Other
```
cd JWTAuthApi.Web
```
```
dotnet run
```

## Deployment
For deployment purpose we use Docker.
In general solution directory, where Dockerfile is, build image with
```
docker build -f Dockerfile -t jwt-auth-api .
```
And run container using
```
docker run -d -p 8080:80 -- jwt-auth-api jwt-auth-api_container
```
## Usage
SQLite .db file is pre-filled with data, there are 4 users and their roles/policies. These are their credentials
`` Login:Password``
``admin:admin``
``staff3:staff3``
``staff2:staff2``
``staff1:staff1``
``user:user``

Each one has a different variant of Role/Policy, to show differences between them.
There is a basic Postman collection with description in ``JWTAuthAPI.postman_collection.json``, for authentication and authorization test purposes. 

## Contact
Krzysztof Zajączkowski - krzysztof.m.zajaczkowski@gmail.com

[build-status-shield]: https://travis-ci.org/krzysztofzajaczkowski/jwt-auth-api.svg?branch=develop
[build-status-url]: https://travis-ci.org/krzysztofzajaczkowski/jwt-auth-api
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/krzysztof-m-zajaczkowski/