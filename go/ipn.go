package main

import (
	"github.com/gin-gonic/gin"
	"log"
	"net/http"
	"sync"
)

// IPNRequest represents the Instant Payment Notification request
type IPNRequest struct {
	RequestID   string            `json:"requestId"`
	OrderID     string            `json:"orderId"`
	Amount      string            `json:"amount"`
	Tip         string            `json:"tip"`
	PaymentType string            `json:"paymentType"`
	Narrative   string            `json:"narrative"`
	FromAccNo   string            `json:"fromAccNo"`
	ExtraData   map[string]string `json:"extraData"`
}

type IPNResponse struct {
	Code    string `json:"code"`
	Message string `json:"message"`
}

var ipnMutex sync.Mutex

func processIPN(ipn IPNRequest) {
	log.Println("Processing IPN:", ipn)
}

func ipnNotification(c *gin.Context) {
	var req IPNRequest
	if err := c.ShouldBindJSON(&req); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": "Invalid request"})
		return
	}

	go func() {
		ipnMutex.Lock()
		processIPN(req)
		ipnMutex.Unlock()
	}()

	c.JSON(http.StatusOK, IPNResponse{Code: "00", Message: "success"})
}

func main() {
	r := gin.Default()

	r.POST("/authorize", authorize)
	r.POST("/payment-terminal", processPayment)
	r.POST("/ipn", ipnNotification)

	r.Run(":8000")
}
