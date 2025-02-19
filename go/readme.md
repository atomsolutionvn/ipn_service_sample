# Gin-based IPN Listener

This is a lightweight IPN (Instant Payment Notification) listener built using the Gin framework in Go. It provides an endpoint for handling incoming IPN requests and processes them asynchronously with thread safety.

## Features
- Handles IPN requests securely with `sync.Mutex` for thread safety.
- Uses Gin for lightweight and fast HTTP handling.
- Processes IPN notifications asynchronously.
- Provides additional endpoints for authorization and payment processing.

## Requirements
- [Go](https://golang.org/) (1.16 or later recommended)
- [Gin Web Framework](https://github.com/gin-gonic/gin)

## Installation

Clone this repository and navigate to the project directory:

```sh
git clone <repository_url>
cd <project_directory>
```

Install dependencies:

```sh
go mod tidy
```

## Usage

Run the application:

```sh
go run main.go
```

The server will start on port `8000`.

## API Endpoints

### 1. IPN Notification
- **URL**: `http://localhost:8000/ipn`
- **Method**: `POST`
- **Headers**: `Content-Type: application/json`
- **Body** (Example JSON):

  ```json
  {
    "requestId": "12345",
    "orderId": "98765",
    "amount": "100.00",
    "tip": "5.00",
    "paymentType": "CreditCard",
    "narrative": "Payment for order",
    "fromAccNo": "1234567890",
    "extraData": { "key1": "value1" }
  }
  ```
- **Response**:

  ```json
  {
    "code": "00",
    "message": "success"
  }
  ```

### 2. Authorization Endpoint
- **URL**: `http://localhost:8000/authorize`
- **Method**: `POST`

### 3. Payment Terminal Processing
- **URL**: `http://localhost:8000/payment-terminal`
- **Method**: `POST`

## Notes
- IPN requests are processed asynchronously using Goroutines.
- `sync.Mutex` is used to ensure thread safety when processing payments.
- We recommend to use mongoDB for transaction data persistent

## License
This project is for public use and is a demo IPN service for ATOM's customer.