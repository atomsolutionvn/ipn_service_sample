# Express IPN Listener

This is a simple Express server that listens for Instant Payment Notification (IPN) messages on a specified endpoint. It processes incoming IPN requests asynchronously and returns a success response.

## Features
- Handles IPN (Instant Payment Notification) requests.
- Uses `body-parser` to parse incoming JSON requests.
- Supports CORS to allow cross-origin requests.
- Processes IPN requests asynchronously using `setImmediate()`.

## Requirements
- [Node.js](https://nodejs.org/) (v14 or later recommended)
- [npm](https://www.npmjs.com/) or [pnpm](https://pnpm.io/) for package management

## Installation

Clone this repository and navigate to the project directory:

```sh
git clone <repository_url>
cd <project_directory>
```

Install dependencies:

```sh
npm install
```

## Usage

Start the server:

```sh
node server.js
```

The server will run on port `8000` by default.

### IPN Endpoint
- **URL**: `http://localhost:8000/ipn`
- **Method**: `POST`
- **Headers**: `Content-Type: application/json`
- **Body** (Example JSON):

  ```json
  {
    "transaction_id": "123456789",
    "status": "completed",
    "amount": 100.00,
    "currency": "USD"
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
- The IPN request is processed asynchronously in the `processIPN` function.
- We recommend to use mongoDB for transaction data persistent

## License
This project is for public use and is a demo IPN service for ATOM's customer.

