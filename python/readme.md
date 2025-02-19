# FastAPI POS Service

## Overview
This FastAPI service provides APIs for:
1. **Authentication**: Generates a JWT token.
2. **Payment Processing**: Handles payment requests.
3. **Instant Payment Notifications (IPN)**: Processes payment notifications in a separate thread.

## Requirements
- Python 3.12+
- FastAPI
- Pydantic
- PyJWT

## Installation

```sh
pip install fastapi uvicorn pydantic jwt
```

## Running the Service

Run the service using:
```sh
uvicorn main:app --host 0.0.0.0 --port 8000
```

## API Endpoints

### 1. Instant Payment Notification (IPN) API
- **Endpoint:** `POST /ipn`
- **Request Body:**
    ```json
    {
        "requestId": "00017-058-0001",
        "orderId": "1234:5263763487",
        "amount": "100000",
        "tip": "0",
        "paymentType": "QR",
        "narrative": "Payment success",
        "fromAccNo": "123456789",
        "extraData": { "key1": "value1" }
    }
    ```
- **Response:**
    ```json
    {
        "code": "00",
        "message": "success"
    }
    ```
- **Response Code:**

| Code | Description                                    |
|------|------------------------------------------------|
| 00   | Success                                        |  
| 01   | Authenticate error                             |
| 02   | The requested URL was not found on the server. |
| 03   | Missing one or more required fields.           |
| 04   | Invalid Field Type                             |
| 05   | Unauthorized Access                            |
| 06   | Permission Denied                              |
| 07   | POS Connect failed                             |

- **Partner Error Code Suggestion Table:**

| Status code                | Retry    |
|----------------------------|----------|
| 200 =< status_code < 300   | No       |  
| status_code >= 300         | Yes      |


## Notes
- **IPN runs in a separate thread** to ensure non-blocking execution.
- The customer business login can be implement in 'process_ipn' function

## License
This project is for public use and is a demo IPN service for ATOM's customer.