# mslearn-oop-labs

This repository serves as a laboratory for small standalone C# projects from `mslearn-develop-oop-csharp` that were not part of the `BankingApp` project.

## Sources
[mslearn-develop-oop-csharp](https://microsoftlearning.github.io/mslearn-develop-oop-csharp/)

## Projects
| Project Name | Description | Concepts Explored |
| :--- | :--- | :--- |
| **InterfacesClassroom** | Modeling people in different roles (Teacher/Student) to demonstrate contracts and custom collections. | - **Polymorphism:** treating `Student` and `Teacher` as `IPerson`.<br>- **Custom Collections:** implementing `IEnumerable<T>`.<br>- **Sorting Logic:** implementing `IComparable` for `List.Sort()`.<br>- **Modern C#:** pattern matching and default interface implementations. |
| **InterfacesLogger** | Refactoring a tightly coupled application to use a flexible, loosely coupled architecture. | - **Decoupling:** separating logic from infrastructure .<br>- **Depencency injection:** using constructor injection to pass dependencies. |
| **BankApp** | Modeling bank accounts and transactions to explore value types, immutability, and generic collections. | - **Enums & Structs:** Creating lightweight, stack-allocated data types.<br>- **Records:** Using immutable data models with value-based equality.<br>- **Generics:** Building reusable, type-safe collections using constraints.<br>- **LINQ & Anonymous Types:** Querying transaction data and projecting results into lightweight, on-the-fly structures. |
| **CounterApp** | Implementing a simple counter to demonstrate event-driven programming and the publisher/subscriber pattern. | - **Events:** Defining and raising custom events using `EventHandler<T>`.<br>- **Custom EventArgs:** Passing data payloads by inheriting from `EventArgs`.<br>- **Publisher/Subscriber:** Subscribing to and handling events using named methods. |