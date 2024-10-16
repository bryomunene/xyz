

---

# **XYZ: Systems Integration Challenge**

#### 1A. Authentication API Documentation

## Overview

The Authentication API allows users to log in and receive a JSON Web Token (JWT) upon successful authentication. This token can be used to access secured endpoints in the application.

## Base URL

```
https://<your-domain>/api/auth
```

## Endpoint

### POST /login

#### Description

Authenticates a user and returns a JWT token if the credentials are valid.

#### Request Format

- **Content-Type**: `application/json`

#### Request Body

The request body should contain the following fields:

| **Field Name** | **Type** | **Description**                       | **Example**   |
|----------------|----------|---------------------------------------|---------------|
| `Username`     | String   | The username of the user.            | `"test"`      |
| `Password`     | String   | The password for the user.           | `"password"`  |

##### Example Request

```json
{
    "Username": "test",
    "Password": "password"
}
```

#### Response Format

- **200 OK**: If the authentication is successful, the response will include the JWT token.

**Success Response:**

```json
{
    "token": "<your_jwt_token>"
}
```

- **401 Unauthorized**: If the authentication fails due to invalid credentials.

**Error Response:**

```json
{
    "error": "Unauthorized"
}
```

## Configuration

The JWT settings should be included in your `appsettings.json` file as follows:

```json
"JwtSettings": {
    "SecretKey": "this_is_a_very_strong_secret_key_12345",
    "Issuer": "MyApp",
    "Audience": "MyAppClient"
}
```

### Example `appsettings.json` Snippet

```json
{
    "JwtSettings": {
        "SecretKey": "this_is_a_very_strong_secret_key_12345",
        "Issuer": "MyApp",
        "Audience": "MyAppClient"
    }
}
```

## Example Usage with `curl`

Here’s an example of how to call the Authentication API using `curl`:

```bash
curl -X POST "https://<your-domain>/api/auth/login" \
-H "Content-Type: application/json" \
-d '{
    "Username": "test",
    "Password": "password"
}'
```

Replace `<your-domain>` with your API's domain.

## Security

Make sure to protect your `SecretKey` and do not expose it publicly. Use environment variables or secure storage solutions to manage sensitive configuration values.

---

#### 2. **Student Verification Published Endpoints**

**Verification API:**  

`https://localhost:7205/api/StudentVerification/verify`  

This API verifies student enrollment status based on information provided.

### **Base URL**

```
http://localhost:7205/api
```

## **Endpoints**

# Verify Student Enrollment API Documentation

### **Overview**

The Verify Student Enrollment API allows clients to verify the enrollment status of a student based on their **Student ID**, **First Name**, and **Last Name**. 

### **Authentication**

This API requires JWT (JSON Web Token) authentication. You must include a valid token in the **Authorization** header of your requests.

- **Authorization Header**: `Bearer <your_jwt_token>`

### **Endpoint**

- **POST** `/studentverification/verify`

### **Description**

Verifies the enrollment status of a student based on their provided details.

### **Request Format**

- **Content-Type**: `application/json`

#### **Request Body**

```json
{
    "StudentId": "S001",
    "FirstName": "John",
    "LastName": "Doe"
}
```

### **Response Format**

#### **Successful Response**

- **200 OK**: If the student is found, the response will include their enrollment status.

**Success Response:**

```json
{
    "StudentId": "S001",
    "IsEnrolled": true,
    "Message": "Student found."
}
```

#### **Error Responses**

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

### **Error Handling**

The API uses standard HTTP status codes for error handling:

- **400 Bad Request**: Indicates that the request was invalid.
- **404 Not Found**: Indicates that the specified student was not found.
- **500 Internal Server Error**: Indicates an unexpected server error.

### **Example Usage with `curl`**

Here’s an example of how to call the Verify Student Enrollment API using `curl`, including the authentication bearer token:

```bash
curl -X POST "https://<your-domain>/studentverification/verify" \
-H "Content-Type: application/json" \
-H "Authorization: Bearer <your_jwt_token>" \
-d '{
    "StudentId": "S001",
    "FirstName": "John",
    "LastName": "Doe"
}'
```

Replace `<your-domain>` with your API's domain and `<your_jwt_token>` with your actual JWT token.

---

##### 3. Payment Notification API Documentation

## Overview

The Payment Notification API allows external systems to send payment notifications to your application. This API receives payment details and processes them, updating the payment status in the database accordingly. The API is secured using JWT (JSON Web Tokens) for authentication.

## Base URL

```
https://<your-domain>/api/payment/notifications
```

## Authentication

To access the API endpoints, a valid JWT token must be included in the request headers. You can obtain a token by calling the `/login` endpoint.

### Example Header with JWT

```http
Authorization: Bearer <your_jwt_token>
```

## Endpoints

### 1. POST /api/payment/notifications/receive-notification

#### Description

Receives a payment notification and updates the corresponding payment status in the database.

#### Request

- **Content-Type**: `application/json`
- **Authorization**: `Bearer <your_jwt_token>`

##### Request Body

The request body should contain the following fields:

| **Field Name**   | **Type**   | **Description**                                         | **Example**               |
|-------------------|------------|---------------------------------------------------------|---------------------------|
| `transactionId`   | String     | Unique identifier for the transaction.                  | `"txn_002"`              |
| `amount`          | Decimal    | The amount of the payment.                               | `4000`                    |
| `currency`        | String     | Currency code for the transaction.                       | `"USD"`                   |
| `status`          | String     | Current status of the payment (e.g., Completed, Failed).| `"Completed"`             |
| `timestamp`       | DateTime   | The time at which the payment was processed.            | `"2024-10-14T06:32:57.541Z"` |
| `customerId`      | String     | Unique identifier for the customer associated with the payment. | `"cust_002"`              |
| `paymentMethod`   | String     | Method used for the payment (e.g., Credit Card, PayPal).| `"PayPal"`                |

#### Example Request

```json
{
  "transactionId": "txn_002",
  "amount": 4000,
  "currency": "USD",
  "status": "Completed",
  "timestamp": "2024-10-14T06:32:57.541Z",
  "customerId": "cust_002",
  "paymentMethod": "PayPal"
}
```

#### Response

On success, the API will return a status code of `200 OK` along with a message indicating the notification was processed successfully.

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

- **Status Code**: `404 Not Found`

If the payment is not found for the given `transactionId`, it will return:

```json
{
    "error": "Payment not found."
}
```

### Example Usage

Here’s an example of how to call the Payment Notification API using `curl`:

```bash
curl -X POST "https://localhost:7205/api/payment/notifications/receive-notification" \
-H "Content-Type: application/json" \
-H "Authorization: Bearer <your_jwt_token>" \
-d '{
  "transactionId": "txn_002",
  "amount": 4000,
  "currency": "USD",
  "status": "Completed",
  "timestamp": "2024-10-14T06:32:57.541Z",
  "customerId": "cust_002",
  "paymentMethod": "PayPal"
}'
```

Here's the updated API documentation reflecting the use of JWT tokens for authentication:

# Payment Notification API Documentation

## Overview

The Payment Notification API allows external systems to send payment notifications to your application. This API receives payment details and processes them, updating the payment status in the database accordingly.

## Base URL

```
https://<your-domain>/api/payment/notifications
```

## Endpoint

### 4. POST /api/payment/notifications/update-status

#### Description

Updates the payment status based on the provided payment notification data.

#### Request

- **Content-Type**: `application/json`
- **Authorization**: `Bearer <your_jwt_token>`

##### Request Body

The request body should contain the following fields:

| **Field Name**   | **Type**   | **Description**                                         | **Example**               |
|-------------------|------------|---------------------------------------------------------|---------------------------|
| `id`              | Integer    | Unique identifier for the payment notification.         | `2`                       |
| `transactionId`   | String     | Unique identifier for the transaction.                  | `"txn_002"`              |
| `amount`          | Decimal    | The amount of the payment.                               | `4000`                    |
| `currency`        | String     | Currency code for the transaction.                       | `"USD"`                   |
| `status`          | String     | Current status of the payment (e.g., Completed, Failed).| `"Completed"`             |
| `timestamp`       | DateTime   | The time at which the payment was processed.            | `"2024-10-14T06:32:57.541Z"` |
| `customerId`      | String     | Unique identifier for the customer associated with the payment. | `"cust_002"`              |
| `paymentMethod`   | String     | Method used for the payment (e.g., Credit Card, PayPal).| `"PayPal"`                |

#### Example Request

```json
{
  "id": 2,
  "transactionId": "txn_002",
  "amount": 4000,
  "currency": "USD",
  "status": "Completed",
  "timestamp": "2024-10-14T06:32:57.541Z",
  "customerId": "cust_002",
  "paymentMethod": "PayPal"
}
```

#### Response

On success, the API will return a status code of `200 OK` along with a message indicating the payment status was updated successfully.

##### Success Response

- **Status Code**: `200 OK`

```json
{
    "message": "Payment status updated successfully."
}
```

##### Error Responses

- **Status Code**: `400 Bad Request`

If the request is invalid, the response will contain an error message.

```json
{
    "error": "Invalid payment notification."
}
```

- **Status Code**: `404 Not Found`

If the payment is not found for the given `transactionId`, it will return:

```json
{
    "error": "Payment not found."
}
```

### Example Usage

Here’s an example of how to call the Payment Status Update API using `curl`:

```bash
curl -X POST "https://localhost:7205/api/payment/notifications/update-status" \
-H "Content-Type: application/json" \
-H "Authorization: Bearer <your_jwt_token>" \
-d '{
  "id": 2,
  "transactionId": "txn_002",
  "amount": 4000,
  "currency": "USD",
  "status": "Completed",
  "timestamp": "2024-10-14T06:32:57.541Z",
  "customerId": "cust_002",
  "paymentMethod": "PayPal"
}'
```

Make sure to replace `<your_jwt_token>` with the actual JWT token you received upon login, and `<your-domain>` with your actual API domain.

---

## Notes

- Ensure that the `TransactionId` is unique for each payment to avoid conflicts.
- The `Amount` must be greater than zero. Invalid amounts will result in a `400 Bad Request` response.

## Error Handling

If any issues occur while processing the notification, appropriate error responses will be returned. Always check for the error messages to understand the cause of the failure. 

This documentation provides a comprehensive overview of how to interact with the Payment Notification API, including endpoints, request formats, expected responses, and JWT authentication details.

---

#### 5. Payment Notification API

## Overview

The Payment Notification API allows you to create and manage payment notifications in the system. This API accepts details about payment transactions and stores them in a MySQL database.

## Authentication

To access the API endpoints, you must include a JWT (JSON Web Token) in the `Authorization` header of your requests. You can obtain a JWT by authenticating through the login endpoint.

### Example JWT Authentication

```bash
curl -X POST "https://localhost:7205/api/auth/login" \
-H "Content-Type: application/json" \
-d '{
    "username": "test",
    "password": "password"
}'
```

#### Example Response

```json
{
    "token": "<your_jwt_token>"
}
```

## API Endpoint

### POST /api/payment/notifications/receive-notification

This endpoint creates a new payment notification.

#### Request Headers

- **Content-Type**: `application/json`
- **Authorization**: `Bearer <your_jwt_token>`

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
curl -X POST "https://localhost:7205/api/payment/notifications/receive-notification" \
-H "Content-Type: application/json" \
-H "Authorization: Bearer <your_jwt_token>" \
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


- 
## 6. **Setup Instructions**

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
-H "Authorization: Bearer <your_jwt_token>" \
-d '{"StudentId": "S001", "FirstName": "John", "LastName": "Doe"}'
```

---

Feel free to use this version for your README file! Adjust any sections as needed.