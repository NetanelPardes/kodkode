from fastapi import FastAPI
import uvicorn
from datetime import datetime

app = FastAPI()

@app.get("/status")
def get_system_information():
    """
    
    """
    return f"time: {datetime.now()} | system_information: app"

if __name__ == "__main__":
    uvicorn.run("server04:app", host="127.0.0.1", port=8000, reload=True)