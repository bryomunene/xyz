

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

Here’s a comprehensive documentation for the Payment Notification API. This documentation includes an overview, endpoint details, request and response formats, and example usage.

---

# Payment Notification API Documentation

## Overview

The Payment Notification API allows external systems to send payment notifications to your application. This API receives payment details and processes them, updating the payment status in the database accordingly.

## Base URL

```
https://<your-domain>/api/payment/notifications
```

## Endpoint

### POST /api/payment/notifications

#### Description

Receives a payment notification and updates the corresponding payment status in the database.

#### Request

- **Content-Type**: `application/json`

##### Request Body

The request body must be a JSON object containing the following properties:

| Field          | Type     | Required | Description                                     |
|----------------|----------|----------|-------------------------------------------------|
| TransactionId  | string   | Yes      | The unique identifier for the transaction.      |
| Amount         | decimal  | Yes      | The amount of the payment.                       |

##### Example Request

```json
{
    "TransactionId": "trans123",
    "Amount": 100.00
}
```

#### Response

The API returns a JSON response indicating the result of the notification processing.

##### Success Response

- **Status Code**: `200 OK`

```json
{
    "message": "Notification processed successfully"
}
```

##### Error Responses

- **Status Code**: `400 Bad Request`

If the request is invalid, the response will contain an error message.

```json
{
    "error": "Invalid notification data"
}
```

#### Example Usage

Here’s an example of how to call the Payment Notification API using `curl`:

```bash
curl -X POST https://<your-domain>/api/payment/notifications \
-H "Content-Type: application/json" \
-d '{
    "TransactionId": "trans123",
    "Amount": 100.00
}'
```

### Notes

- Ensure that the `TransactionId` is unique for each payment to avoid conflicts.
- The `Amount` must be greater than zero. Invalid amounts will result in a `400 Bad Request` response.

## Error Handling

If any issues occur while processing the notification, appropriate error responses will be returned. Always check for the error messages to understand the cause of the failure.

## Security Considerations

- Consider implementing authentication and authorization to protect the endpoint from unauthorized access.
- Validate incoming requests to ensure they are coming from trusted sources.

---

This documentation provides a clear and concise guide for developers who want to integrate with the Payment Notification API. If you need any further modifications or additional information, let me know!

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