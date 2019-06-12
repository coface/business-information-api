#!/usr/bin/env python3

import requests
import json

headers = {"Accept": "application/json", "Content-type": "application/json", "api_key": "8842ace2-e377-48d9-b129-f952950ea535"}
data = json.dumps(
    {
        "company_id": "5415240",
        "product_details": {
            "product_code": "200",
            'language': 'EN',
            'format': "html",
        },
        "credit_report_details": {
            'research_instructions': 'immediate_no_research'
        },
    })

response = requests.post("https://test.cofacecentraleurope.com/api/bi/v1/orders/creditreport", headers=headers, data=data)
if (response.status_code == 202):
    print(json.dumps(response.json(), indent=2))
else:
    raise ValueError("server returned http status %d (%s)" % (response.status_code, response.text))
