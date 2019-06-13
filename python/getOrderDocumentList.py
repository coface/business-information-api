#!/usr/bin/env python3

# Lists the documents (e.g. reports) associated with an order.

# more details at https://b2b.cofacecentraleurope.com/web/online/api-docs/bi/doc#operation/getOrderDocumentList

import requests
import json

headers = {"Accept": "application/json", "api_key": "8842ace2-e377-48d9-b129-f952950ea535"}
order_id = "cc4b853d-f059-48e0-97cc-ef3785315213"
response = requests.get("https://test.cofacecentraleurope.com/api/bi/v1/order/{0}/documents".format(order_id), headers=headers)
if (response.status_code == 200):
    print(json.dumps(response.json(), indent=2))
else:
    raise ValueError("server returned http status %d (%s)" % (response.status_code, response.text))
