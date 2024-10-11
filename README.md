# XYZ : Systems Integration Challenge

Published Endpoints

https://localhost:7205/api/StudentVerification/verify : API to verify student enrolment status based on information provided

Base URL : http://localhost:7205/api

Endpoints
Verify Student Enrollment
POST /studentverification/verify	

Description
Verifies the enrollment status of a student based on their Student ID, First Name, and Last Name.

Request Format
Content-Type: application/json

Request Body:

{
    "StudentId": "S001",
    "FirstName": "John",
    "LastName": "Doe"
}


Response Format
200 OK: If the student is found, the response will include their enrollment status.

Success Response:

{
    "StudentId": "S001",
    "IsEnrolled": true,
    "Message": "Student found."
}


404 Not Found: If the student is not found.

Error Response:

{
    "StudentId": "S001",
    "IsEnrolled": false,
    "Message": "Student not found."
}


400 Bad Request: If the request is invalid

{
    "error": "Invalid request."
}


Error Handling
The API uses standard HTTP status codes for error handling:

400 Bad Request: Indicates that the request was invalid.
404 Not Found: Indicates that the specified student was not found.
500 Internal Server Error: Indicates an unexpected server error.


Setup Instructions

Prerequisites
.NET SDK (version 6.0 or later)
A MySQL database


Installation

1. Clone the repository: git clone 
cd xyz

2. Update the connection string in appsettings.json:

{
    "ConnectionStrings": {
        "DefaultConnection": "server=yourserver;database=yourdatabase;user=youruser;password=yourpassword;"
    }
}


3. Install dependencies: 

dotnet restore

4. Apply migrations to set up the database:

dotnet ef database update

5. Run the application:

dotnet run


Testing

You can test the API using tools like Postman or cURL. Make a POST request to:

http://localhost:7205/api/studentverification/verify

Example Request

curl -X POST http://localhost:7205/api/studentverification/verify \
-H "Content-Type: application/json" \
-d '{"StudentId": "S001", "FirstName": "John", "LastName": "Doe"}'


