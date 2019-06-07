#!/usr/bin/env python3

import requests
import json

headers = {"Accept": "application/json", "api_key": "8842ace2-e377-48d9-b129-f952950ea535"}
order_id = "cc4b853d-f059-48e0-97cc-ef3785315213"
filename = "report.html"
response = requests.get("https://test.cofacecentraleurope.com/api/bi/v1/order/{0}/document/{1}".format(order_id, filename), headers=headers)
if (response.status_code == 200):
    print(response.text)
else:
    raise ValueError("server returned http status %d (%s)" % (response.status_code, response.text))
