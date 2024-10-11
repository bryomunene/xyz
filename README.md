

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

Here’s an updated version of the README documentation that includes the successful 200 response as well. 

---

# Payment Notification API

## Overview

The Payment Notification API allows you to create and manage payment notifications in the system. This API accepts details about payment transactions and stores them in a MySQL database.

## API Endpoint

### POST /api/paymentnotifications

This endpoint creates a new payment notification.

#### Request Body

The request body must be in JSON format and include the following fields:

| Field          | Type    | Description                                              | Required |
|----------------|---------|----------------------------------------------------------|----------|
| `transactionId`| string  | A unique identifier for the payment transaction.        | Yes      |
| `amount`       | decimal | The total amount of the payment.                        | Yes      |
| `currency`     | string  | The currency in which the payment was made (e.g., USD).| Yes      |
| `status`       | string  | The current status of the payment (e.g., Completed).   | Yes      |
| `timestamp`    | string  | The date and time when the payment was processed (ISO 8601 format). | Yes      |
| `customerId`   | string  | An identifier for the customer associated with the transaction. | Yes      |
| `paymentMethod`| string  | The method used for the payment (e.g., Credit Card).   | Yes      |

#### Example Request Body

```json
{
    "transactionId": "txn_001",
    "amount": 150.00,
    "currency": "USD",
    "status": "Completed",
    "timestamp": "2024-10-11T15:15:06.391Z",
    "customerId": "cust_001",
    "paymentMethod": "Credit Card"
}
```

#### Example cURL Command

To create a new payment notification, you can use the following cURL command:

```bash
curl -X POST "https://yourapi.com/api/paymentnotifications" \
-H "Content-Type: application/json" \
-d '{
    "transactionId": "txn_001",
    "amount": 150.00,
    "currency": "USD",
    "status": "Completed",
    "timestamp": "2024-10-11T15:15:06.391Z",
    "customerId": "cust_001",
    "paymentMethod": "Credit Card"
}'
```

#### Successful Response

On a successful request, the API will return a **200 OK** status code with the details of the created payment notification:

```json
{
    "id": 1,
    "transactionId": "txn_001",
    "amount": 150.00,
    "currency": "USD",
    "status": "Completed",
    "timestamp": "2024-10-11T15:15:06.391Z",
    "customerId": "cust_001",
    "paymentMethod": "Credit Card"
}
```

#### Error Handling

In case of an error, the API will return an appropriate status code along with an error message. Common error responses include:

- **400 Bad Request**: Invalid request body or missing required fields.
- **500 Internal Server Error**: An unexpected error occurred on the server.

## Conclusion

This API allows you to efficiently manage payment notifications in your application. Make sure to handle the responses and errors properly to provide a seamless user experience.

---

This version includes the successful response with a 200 status code. Feel free to modify any part of it to better fit your project's context!

---

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