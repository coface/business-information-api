#!/usr/bin/env python3

# Retrieves the list of possible code values (i.e. legal forms, activities etc.)

# more details at https://b2b.cofacecentraleurope.com/web/online/api-docs/bi/doc#operation/getCodetableValues

import requests
import json

headers = {"Accept": "application/json", "api_key": "8842ace2-e377-48d9-b129-f952950ea535"}
response = requests.get("https://test.cofacecentraleurope.com/api/bi/v1/codedvalues/CC0040", headers=headers)
if (response.status_code == 200):
    print(json.dumps(response.json(), indent=2))
else:
    raise ValueError("server returned http status %d (%s)" % (response.status_code, response.text))
