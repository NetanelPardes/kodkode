from fastapi import FastAPI
import db_soldiers as db_soldiers
import uvicorn

app = FastAPI()

@app.post("/setup")
def run_setup():
    return {"status":"setup triggered"}

@app.get("/schema")
def get_schema():   
    columns = db_soldiers.get_schema()
    return{"columns":columns}

@app.get("/soldiers")
def get_all_soldiers():
    return {"soldiers": []}

@app.post("/new_soldier")
def add_new_soldier(new_soldier:dict):
    new_id = db_soldiers.crate_soldier(new_soldier['name'],new_soldier['soldier_rank'],new_soldier['unit'],new_soldier['active'])
    return {"status": "created", "id": new_id}

if __name__ == "__main__":
    uvicorn.run("server_soldiers:app" , reload=True)