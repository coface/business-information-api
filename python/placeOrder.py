#!/usr/bin/env python3

# Order a credit report on a company.

# You will need to specify at least:
# * the company to order (either with the company_id if the company has already been uniquely identified or with company_unidentified).
# * the product to order (product_details).
#    * product_code: 200 for a standard credit report (values from code table CC8800).
#    * language: the language of the report (e.g en for english).
#    * format: xml, pdf, html or txt.
# * if you're using the demo API key, restrict your order to the company_id of a demo company.

# more details at https://b2b.cofacecentraleurope.com/web/online/api-docs/bi/doc#operation/placeOrder

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
