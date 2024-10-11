

---

# **XYZ: Systems Integration Challenge**

## **Published Endpoints**

**Verification API:**  
`https://localhost:7205/api/StudentVerification/verify`  
This API verifies student enrollment status based on information provided.

### **Base URL**

```
http://localhost:7205/api
```

## **Endpoints**

### **Verify Student Enrollment**

- **POST** `/studentverification/verify`

#### **Description**

Verifies the enrollment status of a student based on their **Student ID**, **First Name**, and **Last Name**.

#### **Request Format**

- **Content-Type**: `application/json`

**Request Body:**

```json
{
    "StudentId": "S001",
    "FirstName": "John",
    "LastName": "Doe"
}
```

#### **Response Format**

- **200 OK**: If the student is found, the response will include their enrollment status.

**Success Response:**

```json
{
    "StudentId": "S001",
    "IsEnrolled": true,
    "Message": "Student found."
}
```

- **404 Not Found**: If the student is not found.

**Error Response:**

```json
{
    "StudentId": "S001",
    "IsEnrolled": false,
    "Message": "Student not found."
}
```

- **400 Bad Request**: If the request is invalid.

**Error Response:**

```json
{
    "error": "Invalid request."
}
```

## **Error Handling**

The API uses standard HTTP status codes for error handling:

- **400 Bad Request**: Indicates that the request was invalid.
- **404 Not Found**: Indicates that the specified student was not found.
- **500 Internal Server Error**: Indicates an unexpected server error.



- Here's an example of how you can document the `PaymentNotificationsController` API in a README file:

---

# Payment Notifications API

## Overview

The Payment Notifications API allows external payment services to send notifications regarding payment transactions. The endpoint receives payment notifications and processes them accordingly.

## Endpoint

### POST /api/payment/notifications

This endpoint receives a payment notification from an external service.

#### Request Body

The request must contain a JSON object that adheres to the `PaymentNotification` model. Below is the expected structure:

```json
{
  "TransactionId": "string",
  "Amount": "decimal"
}
```

#### Fields

| Field          | Type    | Description                           |
|----------------|---------|---------------------------------------|
| TransactionId  | string  | A unique identifier for the transaction. This field is required. |
| Amount         | decimal | The amount of the transaction. Must be greater than 0. This field is required. |

#### Responses

- **200 OK**: The notification was processed successfully.
  - Example response:
    ```json
    {
      "message": "Notification processed successfully"
    }
    ```

- **400 Bad Request**: The request was invalid. This occurs if the notification data is missing or the required fields are not provided.
  - Example response:
    ```json
    {
      "error": "Invalid notification data"
    }
    ```

#### Example Request

Here's an example of a valid POST request:

```http
POST /api/payment/notifications
Content-Type: application/json

{
  "TransactionId": "12345",
  "Amount": 100.00
}
```

### Error Handling

If the request body is missing required fields or if the fields contain invalid data, the API will respond with a `400 Bad Request` status and an error message explaining the issue.

### Logging

Upon receiving a notification, the API logs the notification data to the console for auditing purposes.

## Usage

To use this API, ensure that your application can send a POST request to the specified endpoint with the appropriate JSON body. Be mindful of the required fields and their validation rules.

## Additional Information

Make sure to handle the response appropriately in your application and implement necessary security measures to verify that notifications are coming from a trusted source.

---

Feel free to modify the content to fit your project's style or additional needs!
## **Setup Instructions**

### **Prerequisites**

- **.NET SDK** (version 6.0 or later)
- **A MySQL database**

### **Installation**

1. **Clone the repository**:
   ```bash
   git clone https://github.com/bryomunene/xyz.git
   cd xyz
   ```

2. **Update the connection string in `appsettings.json`**:

   ```json
   {
       "ConnectionStrings": {
           "DefaultConnection": "server=yourserver;database=yourdatabase;user=youruser;password=yourpassword;"
       }
   }
   ```

3. **Install dependencies**: 

   ```bash
   dotnet restore
   ```

4. **Apply migrations to set up the database**:

   ```bash
   dotnet ef database update
   ```

5. **Run the application**:

   ```bash
   dotnet run
   ```

## **Testing**

You can test the API using tools like **Postman** or **cURL**. Make a **POST** request to:

```
http://localhost:7205/api/studentverification/verify
```

### **Example Request**

Using cURL:

```bash
curl -X POST http://localhost:7205/api/studentverification/verify \
-H "Content-Type: application/json" \
-d '{"StudentId": "S001", "FirstName": "John", "LastName": "Doe"}'
```

---

Feel free to use this version for your README file! Adjust any sections as needed.