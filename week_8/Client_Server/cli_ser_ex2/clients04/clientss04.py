import requests

respons = requests.get('https://jsonplaceholder.typicode.com/posts')
posts = respons.json()  

respons = requests.get('https://jsonplaceholder.typicode.com/users')
users = respons.json()

for post in posts:
    for user in users:
        if post['userId'] == user['id']:
            post["author's name"] = user['name']

for post in posts:
    print(f"{post['title']} by {post["author's name"]}")