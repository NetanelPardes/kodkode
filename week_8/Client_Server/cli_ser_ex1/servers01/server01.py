from fastapi import FastAPI
import uvicorn

app = FastAPI()

@app.get("/ping")
def get_ping():
    """
    Returns server status.
    """
    return {"status": "pong"}

@app.get("/greet/{name}")
def get_greet(name: str):
    """
    Returns a greeting message with the given name.
    """
    return {"message": f"Hello, {name}!"}

if __name__ == "__main__":
    uvicorn.run("server01:app", host="127.0.0.1", port=8000, reload=True)