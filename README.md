# SuperMarket


           Case Study Document

Contents
1.0	Problem statement	2
2.0	Skills to develop the project	2
3.0	Architecture Diagram for the Problem Statement	3
4.0	User Stories	4
5.0	Expected Deliverables	5
6.0	Milestone and duration	5
7.0	Implementation Notes	6
8.0	Evaluation rubrics	7







1.0	Problem statement
Application logic:
SuperMarketAssessment is an app used at the super market to billing purpose. Customer's shopping items sold if they are available in the stock. Super market also provides some discount to their predefined list of customers based on their past shopping history. This app is also integrated with a payment gateway to process the payments. If any payment is failed, app logs the error message.

Solution expected:
This code is already in a working version. You need to identify the opportunites to refactor the solution so that the codebase will be cleaner and testable. You can consider below pointers for the refactoring.

1. Make use of appropriate patterns and principles 
2. Improve the readability and maintanability of the code
3. Make sure that unit tests are covering ~100% of your code
4. Do no over-engineer the things (no use of any framework than nUnit and MOQ is allowed)
5. All the unit test cases must pass

6. Deploy application to Azure platform  and Implement below services in Azure portal
•	App Service
•	Cloud Service
•	Azure Storage
•	Azure Service Bus
•	Azure Functions & Logic Apps
•	Application Insights
•	Azure Service Fabric
2.0	Skills to develop the project

Associate will implement skills from Backend and Azure Cloud platform to develop the application.
Below are the skill details. Choose the Backend based on the technology stack.

Tower Name 	Topics 
Backed - .NET	Design patterns and principles 
.Net Core, C#
NUnit
Best Practices
[ASP.NET Web API Core, JSON, EF core, Microservices -Optional]

Cloud - Azure	•	App Service
•	Cloud Service
•	Azure Storage
•	Azure Service Bus
•	Azure Functions & Logic Apps
•	Application Insights
•	Azure Service Fabric



3.0	Architecture Diagram for the Problem Statement
Use Case Diagram
NA





Sample Architecture Diagram
 

4.0	User Stories
1. Make use of appropriate patterns and principles 
2. Improve the readability and maintainability of the code
3. Make sure that unit tests are covering ~100% of your code
4. Do no over-engineer the things (no use of any framework than nUnit and MOQ is allowed)
5. All the unit test cases must pass







5.0	Expected Deliverables
The following deliverables are expected as outcomes 
•	Application Code base
•	Readme document on the complete application 
o	Setup of the application 
o	High level steps used to convert to server less architecture
o	How to run the application
o	Any inference
o	Snapshot of any implementation
•	Reports:
o	Code Assessment Report
o	Functional Test Report
o	Vulnerability Assessment Report
o	Performance Test Report
o	Code Profiling Report
6.0	Milestone and duration
As per project requirement, modification can be done in the below table.
Milestone 	Topic
Milestone -1	1. Make use of appropriate patterns and principles 
2. Improve the readability and maintanability of the code
3. Make sure that unit tests are covering ~100% of your code
4. Do no over-engineer the things (no use of any framework than nUnit and MOQ is allowed)
5. All the unit test cases must pass

Milestone -2	Deploy existing application to Azure platform .Use server less architecture, API Gateways and implement DevOps on Cloud 
Implement below services:
•	App Service
•	Cloud Service
•	Azure Storage
•	Azure Service Bus
•	Azure Functions & Logic Apps
•	Application Insights
•	Azure Service Fabric

 


7.0	Implementation Notes

Backend –.NET, nUnit	Milestone-1
•	Use latest features from C# 7
•	Make use of appropriate patterns and principles 
•	Use browser / POST Man to invoke APIs
•	Any error message or exception should be logged (and help in refactor)
•	Unit test the application
•	Improve the readability and maintanability of the code
•	Make sure that unit tests are covering ~100% of your code
•	Do no over-engineer the things (no use of any framework than nUnit and MOQ is allowed)
•	All the unit test cases must pass
•	API versioning  is done to manage changes in the API without affecting the client that are using the existing API
•	Raising Pull Requests, closing them are highly encouraged
•	All implementation should publish Code Quality Metrics using SonarCloud/SonarQube
o	Technical Debt – lower-the-better
o	Code Smell – lower-the-better
o	Cyclomatic Complexity - lower-the-better
o	Code Coverage – higher-the-better
o	Secure coding practices
o	Follow coding standards
•	Message input/output format should be in JSON (Read the values from the property/input files, wherever applicable). Input/output format can be designed as per the discretion of the participant

Cloud - Azure	Milestone-2
Implement below azure services:
•	App Service
•	Cloud Service
•	Azure Storage
•	Azure Service Bus
•	Azure Functions & Logic Apps
•	Application Insights
•	Azure Service Fabric

•	Application should follow Serverless architecture on public cloud. Maximize use of cloud provider’s PaaS capabilities to minimize IT infrastructure management effort.
•	Usage of API Gateway as the entry point for service calls originating from clients (web or mobile). The API Gateway should also cater to authentication and handle SSL termination.
•	Use cloud provider’s DevOps tools to setup a CI/CD pipeline to automate your releases. API versioning best practices should be followed.
•	Publish of web app to azure app service
•	Implement functionality of FileUpload service which uploads a file from local to Azure Blob storage
•	Usage of Redis cache in the get operations to improve the performance of the App
•	Usage of logger to log critical actions in the app
•	Implement simple azure functions that gets triggered on message arrival on service bus or event trigger through grid

8.0	Evaluation rubrics

C#	•	Implement any 5 of the below C#7 features in your project use case
o	Out variables
o	Tuples and deconstruction
o	Pattern matching
o	Local functions
o	Expanded expression bodied members
o	Ref locals and returns
o	Discards
o	Binary Literals and Digit Separators
o	Throw expressions
o	async Main method
o	default literal expressions
o	Inferred tuple element names
o	Pattern matching on generic type parameters
o	Techniques for writing safe efficient code
o	Non-trailing named arguments
o	Leading underscores in numeric literals
o	private protected access modifier
o	Conditional ref expressions
o	Access fixed fields without pinning.
o	Reassign ref local variables.
o	Use initializers on stackalloc arrays.
o	Use fixed statements with any type that supports a pattern.
o	Additional generic constraints.

Unit Testing 	•	Test cases covers the functionality of API with custom inputs
•	Good test Coverage
Common	•	Code Smell
•	Technical Debt
•	Secured Coding
•	Coding Standards
Server less implementation	•	App Service
•	Cloud Service
•	Azure Storage
•	Azure Service Bus
•	Azure Functions & Logic Apps
•	Application Insights
•	Azure Service Fabric
•	APIs are added to the API management
•	Configuration of Azure service bus (via Topic or Queue)
•	Configuration of Event Grid and subscription (event handlers)  to the event grid for performing an action.
•	Azure functions that gets triggered on message arrival on service bus or event trigger through grid.
•	Azure SQL DB used to store data
•	API versioning  is done to manage changes in the API without affecting the client that are using the existing API
•	Implement functionality of FileUpload service which uploads a file from local to Azure Blob storage
•	Publish of web app to azure app service
•	Usage of Redis cache in the get operations to improve the performance of the App
•	Usage of logger to log critical actions in the app
•	Implement simple azure functions that gets triggered on message arrival on service bus or event trigger through grid
Usage of API Gateways	•	Associate must have used API Gateway as the entry point for service calls originating from client. The API Gateway should also cater to authentication and handle SSL termination.

DevOps on Cloud	•	DevOps pipeline for each microservices which uses cloud PaaS services to trigger a CI/CD pipeline when code is checked-in to GIT
•	The check-in process should trigger unit tests with mocked dependencies
•	Unit tests should not alter persistent data
•	DevOps dashboard should show status of CI/CD pipeline
•	DevOps pipeline should support manual approval for rollout, gradual traffic shifting and rollback to earlier version
•	Checked-in code should meet 75%+ code coverage in unit testing

