#!/usr/bin/env python3

# Request an update to the status of a previously submitted order.

# more details at https://b2b.cofacecentraleurope.com/web/online/api-docs/bi/doc#operation/updateStatus

import requests
import json

order_id = "603f5ea2-b869-46c3-a85e-ed2677c1e4ed"
headers = {"Accept": "application/json", "api_key": "8842ace2-e377-48d9-b129-f952950ea535", "Content-Type": "application/json"}
data = json.dumps({"action": "cancel", "cancel_reason": "order placed by mistake"})
response = requests.put("https://test.cofacecentraleurope.com/api/bi/v1/order/{0}/status".format(order_id), headers=headers, data=data)
if (response.status_code == 200):
    print(json.dumps(response.json(), indent=2))
else:
    raise ValueError("server returned http status %d (%s)" % (response.status_code, response.text))
