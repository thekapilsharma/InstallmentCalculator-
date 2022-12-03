# CSharp Project

## Exception Handler
```
Exception Hanlder Middleware class inside Middleware folder of Zip.Installment.API is used for global exception handling
```

## Validation
```
Fluent Validator is used for validation purpose. Validation rules are defined in individual validation class for request object.
```

## API and Swagger Documentation
```
API edppoint is deined in API project for calulating installments. It has Frequency Type as enum where 0 represent to Month and 1 represent to 0. While configuring this API with UI we can use dropdown for ENUM by defiing values in redable format and enum can be set as value.
```

## Uni Tests / Integration Test
```
Unit test are defined in ZIP.InstallmentsServices.Test project. Controller related UTC are inside Controller forlder. Also for Integration test we have Swagger configured and we cna use postman collection as well.
```
## Logging
Logging is defined by using ILogger interface on diffrent levels

## Application layer details

- Web API with Swager documentation
- Services to calculate installments
- Entity to store in databse
- Models to represent entity to UI
- Cotracts for services
- Test project for unit test