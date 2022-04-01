#!/usr/bin/env python3

# Retrieves a monitoring notification.

# more details at https://b2b.cofacecentraleurope.com/web/online/api-docs/bi/doc#operation/getNotificationDocument

import requests
import json

notification_id = 55
headers = {"Accept": "application/json", "api_key": "8842ace2-e377-48d9-b129-f952950ea535"}
response = requests.get("https://test.cofacecentraleurope.com/api/bi/v1/notification/{0}".format(notification_id), headers=headers)
if (response.status_code == 200):
    print(json.dumps(response.json(), indent=2))
else:
    raise ValueError("server returned http status %d (%s)" % (response.status_code, response.text))
