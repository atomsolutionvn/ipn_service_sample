from fastapi import FastAPI, HTTPException, Depends
from pydantic import BaseModel
from typing import Dict, Optional
import jwt
import datetime
import threading

app = FastAPI()


@app.get("/")
def hello():
    return "Hello world"


class IPNRequest(BaseModel):
    requestId: str
    orderId: str
    amount: str
    tip: str
    paymentType: str
    narrative: str
    fromAccNo: str
    extraData: Dict[str, str]


class IPNResponse(BaseModel):
    code: str
    message: str


def process_ipn(ipn_request: IPNRequest):
    # Simulated processing of IPN in a separate thread
    print(f"Processing IPN: {ipn_request}")


@app.post("/ipn", response_model=IPNResponse)
def ipn_notification(ipn_request: IPNRequest):
    thread = threading.Thread(target=process_ipn, args=(ipn_request,))
    thread.start()
    return {"code": "00", "message": "success"}
