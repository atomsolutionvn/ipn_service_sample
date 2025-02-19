# ASP.NET Core IPN Listener

This is a simple ASP.NET Core application that listens for Instant Payment Notification (IPN) messages and processes them asynchronously.

## Features
- Handles IPN requests using an API controller.
- Processes IPN asynchronously using `Task.Run`.
- Uses `Thread.Sleep` to simulate a processing delay.

## Requirements
- [.NET 6.0 or later](https://dotnet.microsoft.com/)

## Installation

Clone this repository and navigate to the project directory:

```sh
git clone <repository_url>
cd <project_directory>
```

Restore dependencies:

```sh
dotnet restore
```

## Usage

Run the application:

```sh
dotnet run
```

By default, the server will listen on `http://localhost:5000`.

## API Endpoint

### 1. IPN Notification
- **URL**: `http://localhost:5000/ipn`
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

## Notes
- IPN requests are processed asynchronously in the background.
- `Thread.Sleep(1000)` is used to simulate a processing delay.
- We recommend to use mongoDB for transaction data persistent

## License
This project is for public use and is a demo IPN service for ATOM's customer.

