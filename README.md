# TaskUtil

* git https://github.com/web-projects/TASK_UTIL.git

# Prerequisites

To get started on the project you will need the following software installed on your machine.

* Visual Studio 2019
* .NET Core 3.0 SDK
    * https://dotnet.microsoft.com/download/dotnet-core/3.0
    * .NET Core Installer: x64
* Docker for Windows
* Visual Studio Extensions to Install:
    * Markdown Editor (Mads Kristensen)
    * EditorConfig Language Service (Mads Kristensen)
    * Cloud Explorer for VS 2019 Preview (Microsoft)
    * ProjectHero2 - Sync Bindings (Fonzie)

# Project Folder Structure

The folder structure is designed to support a collection of projects, tools and scripts necessary to build everything. Below is a concise listing of the project.

* **build/**
    * Contains any necessary scripts or tools to support building the project in the Azure DevOps build pipeline.

* **samples/**
    * Contains any sample code that provide a sample on how to use various libraries or demonstrate a particular pattern. This is here for convenience so engineers can find everything the need within this project repository.

* **src/**
    * Contains the entire source code for the production ready IPA5 codebase. Relevant parts of the project are broken down into their respective folders so engineers can focus in on the parts they are working on.

* **test/**
    * Contains all test projects to make it easy to separate pure production code from test only code.

* **tools/**
    * Contains all support tools that are necessary to support development. This can be tools such as a test harness or anything else that speeds up the development process.

Please do not modify the top level structure of this repository as it will be linked to the CI/CD pipeline and is designed to follow best practices.

# Getting Started

At the top level of the **src/** directory you will find a master solution which serves as the master view of all projects in the repository. This is useful when you want to have a high-level view of the entire project. More realistic use cases are that you will be working in distinctive solutions for various components when you are interested in debugging some items.

When you are working in a separate solution other than the master solution you may add new projects which will not be known to the main solution. To resolve this, please run the "build/generate.py" script which will regenerate the entire project structure to update the main solution view. At the moment this file doesn't exist but will be added to support that effort when the number of projects begins to increase.

# Testing your code

During development of new projects you will be adding new test projects, all of which must go into the **test/** folder. For our project we are using **XUnit.NET** as our testing framework to take advantage of many advanced testing scenarios. Please be sure that all of your tests pass prior to submitting your check-in for code review.

For more information on how to utilize XUnit please visit their website at [XUnit.net](https://xunit.net/).

# Dependency Injection 

As part of our stack we are using Ninject for all of our needs rather than the built-in .NET dependency injection framework.** 

**Note:** _For applications that take advantage of the MVC Framework and have a user interface the usage of the built-in IoC Container for .NET Core can be used instead of Ninject. The reasoning behind it is that there are some built-in services that Microsoft has baked into their IoC Framework which benefit tremendously when using ASP.NET Core with MVC._


# Further Information for Contributors

For more information to help you get started contributing to the code base please read the following files at the root of the repository:

* **Coding-Style**.md
* **Contributing**.md
* **Best-Practice-Patterns**.md

### HISTORY ###

* 20191121 - Initial repository
* 29181122 - Added Ninject Testing Framework
