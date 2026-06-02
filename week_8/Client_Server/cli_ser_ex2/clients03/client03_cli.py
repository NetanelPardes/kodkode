import requests

response1 = requests.get('http://127.0.0.1:8000/greet')
response2 = requests.get('http://127.0.0.1:8000/greet?name=Moshe')
print(response1.json())
print(response2.json())