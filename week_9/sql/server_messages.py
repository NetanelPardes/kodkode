from fastapi import FastAPI
import db_messages
import uvicorn

app = FastAPI()

@app.post("/setup")
def run_setup():
    return {"status":"ok", "table" : "messages"}

@app.get("/schema")
def get_schema():
    columns = db_messages.get_schema()
    return {"columns":columns}

@app.get("/messages")
def get_all_messages():
    message = db_messages.get_all_messages()
    return {"message": message}

@app.post("/new_messages")
def new_message(new_message:dict):
    new_id = db_messages.add_new_message(new_message)
    return {"status": "created", "id": new_id}

@app.get("/messages/{classification}")
def get_all_messages_by_classification(classification:str):
    messages_by_classification = db_messages.get_all_messages_by_classification(classification)
    return {f"{classification} messages":messages_by_classification}


if __name__ == "__main__":
    uvicorn.run("server_messages:app" , reload=True)