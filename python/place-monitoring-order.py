#!/usr/bin/env python3

import requests
import json

headers = {"Accept": "application/json", "Content-Type": "application/json", "api_key": "8842ace2-e377-48d9-b129-f952950ea535"}
data = json.dumps({
    "company_id": 102296980,
    "product_details": {
        "product_code": 200,
        "language": "en",
        "format": "pdf"
    },
    "monitoring_details": {
        "start_date": "2018-03-09",
        "duration_months": 12
    }
})
response = requests.post("https://test.cofacecentraleurope.com/api/bi/v1/orders/monitoring", headers=headers, data=data)
if (response.status_code == 202):
    print(json.dumps(response.json(), indent=2))
else:
    raise ValueError("server returned http status %d (%s)" % (response.status_code, response.text))
