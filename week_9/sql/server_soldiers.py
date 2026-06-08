from fastapi import FastAPI,HTTPException
import db_soldiers as db_soldiers
import uvicorn
from pydantic import BaseModel

app = FastAPI()

class SoldierIn(BaseModel):
    name: str
    rank: str | None = None
    unit: str | None = None

@app.post("/setup")
def run_setup():
    return {"status":"setup triggered"}

@app.get("/schema")
def get_schema():   
    columns = db_soldiers.get_schema()
    return{"columns":columns}

@app.get("/soldiers")
def get_all_soldiers():
    return {"soldiers": db_soldiers.get_all()}

@app.post("/soldiers", status_code=201)
def add_soldier(body: SoldierIn):
    new_id = db_soldiers.crate_soldier(body.name, body.rank, body.unit)
    return {"id": new_id, "message": "Soldier created"}

@app.put("/soldiers/{soldier_id}")
def edit_soldier(soldier_id: int, body: SoldierIn):
    data = body.model_dump(exclude_none=True)
    success = db_soldiers.update_soldier(soldier_id, data)
    if not success:
        raise HTTPException(status_code=404, detail="Soldier not found")
    return {"message": "Updated"}

@app.get("/soldiers/{soldier_id}")
def get_soldier(soldier_id: int):
    soldier = db_soldiers.get_by_id(soldier_id)
    if soldier is None:
        raise HTTPException(status_code=404, detail="Soldier not found")
    return soldier

@app.delete("/soldiers/{soldier_id}")
def remove_soldier(soldier_id: int):
    success = db_soldiers.delete(soldier_id)
    if not success:
        raise HTTPException(status_code=404, detail="Soldier not found")
    return {"message": "Deleted"}


if __name__ == "__main__":
    uvicorn.run("server_soldiers:app" , reload=True)