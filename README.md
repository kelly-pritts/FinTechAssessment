# FinTech Assessment

Kelly Pritts Notes for Assessment:

- Created a Visual Studio Solution that contains PersonsManagerApi and PersonsManagerTests.
- Controller that defines CRUD endpoints
- Service Interface and Implementation to provide logic for handling requests - Dependency Injection as Singleton for Controller
- Models for expected requests and responses
- Model for the Person Data
- SeedData to add as EF stand in and provide seed data for tests

## Unit Testing
- Right click on PersonsManagerTests and select Run Tests. I added Moq and XUnit but did not end up using them. I
  

# Project: Building a RESTful API for Managing Person Data

Description:

In this take-home coding project, your task is to create a RESTful API that enables CRUD operations on a "Person" object. You will be using C# and .NET Core for this task.

Requirements:
1. Person Model: Create a "Person" class with the following properties:
   - `Id` (integer, unique identifier)
   - `FirstName` (string)
   - `LastName` (string)
   - `Age` (integer)
2. API Endpoints: Implement the following RESTful endpoints for managing persons:
   - GET /api/persons: Retrieve a list of all persons.
   - GET /api/persons/{id}: Retrieve a specific person by their unique identifier.
   - POST /api/persons: Create a new person.
   - PUT /api/persons/{id}: Update an existing person.
   - DELETE /api/persons/{id}: Delete a person by their unique identifier.
3. Data Storage: You can use in-memory data storage for simplicity (e.g., a list of persons stored in memory). There's no need to implement a database in this exercise.
4. Validation: Implement basic input validation. Ensure that required fields (FirstName, LastName, and Age) are provided when creating a person. Validate that the age is a positive integer.
5. Testing: Write unit tests to ensure the API endpoints work correctly.
6. Documentation: Provide a brief README explaining how to run the project and test the API endpoints. Mention any relevant libraries or tools used.

Submission:
You are expected to create a public github repo and provide a link for us to review your submission. Please include a README file that contains any instructions for running and testing the app. 

Evaluation:
Your project will be evaluated based on the following criteria:
- Correct implementation of the API endpoints and CRUD operations.
- Code organization, readability, and adherence to best practices.
- Proper input validation and error handling.
- Completeness of the provided README.
- Unit tests to validate the functionality of your API.
Additional Notes:
- While a real-world scenario would involve a database, for the sake of this exercise, you can use in-memory data storage.
- Feel free to use any libraries or frameworks commonly used with C# and .NET Core to simplify your development.
- This project is designed to assess your coding skills, API development, and basic data validation abilities.
Good luck with your coding!
