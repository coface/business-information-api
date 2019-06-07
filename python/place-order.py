import requests
import json

headers = {"Accept": "application/json", "api_key": "8842ace2-e377-48d9-b129-f952950ea535"}
data = json.dumps({
    "order_details": {
        "company_id": 5606280,
        "product_code": 200,
        "language": "en",
        "format": "pdf"
    }
})
response = requests.post("https://test.cofacecentraleurope.com/api/bi/v1/orders/creditreport", headers=headers, data=data)
if (response.status_code == 202):
    print(json.dumps(response.json(), indent=2))
else:
    raise ValueError("server returned http status %d (%s)" % (response.status_code, response.text))
