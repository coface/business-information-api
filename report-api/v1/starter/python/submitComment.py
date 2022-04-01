#!/usr/bin/env python3

# Submit a comment to an order.

# more details at https://b2b.cofacecentraleurope.com/web/online/api-docs/bi/doc#operation/submitComment

import requests
import json

order_id = "603f5ea2-b869-46c3-a85e-ed2677c1e4ed"
comment = "any comment"
headers = {"Accept": "application/json", "Content-Type": "application/json", "api_key": "8842ace2-e377-48d9-b129-f952950ea535"}
data = json.dumps({"comment": comment})
response = requests.put("https://test.cofacecentraleurope.com/api/bi/v1/order/{0}/comment".format(order_id), headers=headers, data=data)
if (response.status_code == 202):
    print("OK")
else:
    raise ValueError("server returned http status %d (%s)" % (response.status_code, response.text))
