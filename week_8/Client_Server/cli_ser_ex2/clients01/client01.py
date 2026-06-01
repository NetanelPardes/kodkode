import requests

respons = requests.get("https://jsonplaceholder.typicode.com/users/1")

print(respons.json()['name'])
print(respons.json()['email'])
print(respons.json()['address']['city'])

respons = requests.get("https://jsonplaceholder.typicode.com/posts")
print(len(respons.json()))

respons = requests.get("https://jsonplaceholder.typicode.com/posts?userId=2")
for user in respons.json():
    print(user['title'])