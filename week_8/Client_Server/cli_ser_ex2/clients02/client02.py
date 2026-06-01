import requests

def safe_get(url):
    respons = requests.get(url)
    if respons.status_code == 200:
        return respons.json()
    elif respons.status_code == 404:
        return None
    else:
        raise Exception(F"Unexpected status code: {respons.status_code}")
try:
    print(safe_get("https://jsonplaceholder.typicode.com/users/1"))        
    print(safe_get("https://jsonplaceholder.typicode.com/posts/99999"))    
    print(safe_get("https://httpbin.org/status/500"))                      
except Exception as e:
    print(e)


