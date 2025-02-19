const express = require("express");
const bodyParser = require("body-parser");
const cors = require("cors");
const app = express();
const PORT = 8000;

app.use(cors());
app.use(bodyParser.json());

// IPN API
const processIPN = (ipnRequest) => {
    console.log("Processing IPN:", ipnRequest);
};

app.post("/ipn", (req, res) => {
    const ipnRequest = req.body;
    setImmediate(() => processIPN(ipnRequest)); // Process IPN asynchronously
    res.json({ code: "00", message: "success" });
});

app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
});
