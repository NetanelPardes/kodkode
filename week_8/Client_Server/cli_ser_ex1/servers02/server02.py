from fastapi import FastAPI
import uvicorn

app = FastAPI()

@app.get("/")
def home():
    """
    Will return general information about the server
    """
    return {"service": "my-api", "version": "1.0"}

@app.get("/users/admin")
def get_admin():
    """
    Will return permanent information about the admin user
    """
    return  {"role": "admin", "access": "full"}

@app.get("/users/{user_id}")
def get_user(user_id: int):
    """
    Gets a number from the URL and returns information about a user with that number.
    """
    return {"user_id" : user_id,
            "name": "Netanel",
            "email" : "sendi8475@gmail.com"}

if __name__ == "__main__":
    uvicorn.run("server02:app", host="127.0.0.1", port=8000, reload=True)