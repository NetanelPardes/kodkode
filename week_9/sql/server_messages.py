from fastapi import FastAPI ,HTTPException
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

@app.get("/messages/{message_id}", status_code=200)
def get_message_by_id(message_id:int):
    message = db_messages.get_message_by_id(message_id)
    if not message:
        raise HTTPException(status_code=404 ,detail="Message does not exist.")
    return message

@app.put("/messages/{message_id}",status_code=200)
def update_message(message_id , new_data:dict):
    message = db_messages.update_message(message_id , new_data)
    if not message:
        raise HTTPException(status_code=404 ,detail="Message does not exist.")
    return message

@app.delete("/messages/{message_id}",status_code=200)
def delete_message(message_id):
    message = db_messages.delete_message(message_id)
    if not message:
        raise HTTPException(status_code=404 ,detail="Message does not exist.")
    return message

@app.get("/messages/{classification}")
def get_all_messages_by_classification(classification:str):
    messages_by_classification = db_messages.get_all_messages_by_classification(classification)
    return {f"{classification} messages":messages_by_classification}

@app.post("/messages", status_code=201)
def new_message(new_message:dict):
    new_id = db_messages.create_message(new_message['unit'], new_message['classification'],new_message['content'], new_message['source'])
    return {"status": "created", "id": new_id}




if __name__ == "__main__":
    uvicorn.run("server_messages:app" , reload=True)