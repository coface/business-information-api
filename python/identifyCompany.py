#!/usr/bin/env python3

# Find a company using a unique identifier (returns exactly 1 or 0 results).

# Tips for finding a company:
# * If you are searching using national identifiers, provide the country (via the country_iso_code)
# * You don't need to include the legal form in the name (e.g. if the company is called PRINT Solutions Ltd, just search for PRINT Solutions).

# more details at https://b2b.cofacecentraleurope.com/web/online/api-docs/bi/doc#operation/identifyCompany

import requests
import json

headers = {"Accept": "application/json", "api_key": "8842ace2-e377-48d9-b129-f952950ea535"}
response = requests.get("https://test.cofacecentraleurope.com/api/bi/v1/company?identifier_type=120&identifier_value=6551640402&country_iso_code=PL", headers=headers)
if (response.status_code == 200):
    print(json.dumps(response.json(), indent=2))
else:
    raise ValueError("server returned http status %d (%s)" % (response.status_code, response.text))
