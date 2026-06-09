from fastapi import FastAPI, HTTPException, Query
import db_soldiers
import uvicorn
from pydantic import BaseModel

app = FastAPI()

class SoldierCreate(BaseModel):
    name: str
    rank: str | None = None
    unit: str | None = None
    active: bool = True

class SoldierUpdate(BaseModel):
    name: str | None = None
    rank: str | None = None
    unit: str | None = None
    active: bool | None = None

@app.post("/setup")
def run_setup():
    db_soldiers.setup()
    return {"status": "setup completed"}

@app.get("/schema")
def get_schema():
    columns = db_soldiers.get_schema()
    return {"columns": columns}

@app.post("/soldiers", status_code=201)
def add_soldier(body: SoldierCreate):
    new_id = db_soldiers.create_soldier(body.name,body.rank,body.unit,body.active)
    return {"id": new_id,"message": "Soldier created"}

@app.put("/soldiers/{soldier_id}")
def edit_soldier(soldier_id: int, body: SoldierUpdate):
    data = body.model_dump(exclude_none=True)
    if "rank" in data:
        data["soldier_rank"] = data.pop("rank")
    if not data:
        raise HTTPException(status_code=400, detail="No fields to update")
    success = db_soldiers.update_soldier(soldier_id, data)
    if not success:
        raise HTTPException(status_code=404, detail="Soldier not found")
    return {"message": "Updated"}

@app.get("/soldiers")
def list_soldiers(soldier_rank: str | None = Query(default=None),sort: str = Query(default="asc")):
    if soldier_rank:
        return {"soldiers": db_soldiers.get_by_rank(soldier_rank)}
    return {"soldiers": db_soldiers.get_active_sorted(sort)}


@app.get("/soldiers/units")
def list_units():
    return {"units": db_soldiers.get_distinct_units()}

@app.get("/soldiers/search")
def search_soldiers(name: str = Query(...)):
    return {"soldiers": db_soldiers.search_by_name(name)}

@app.get("/soldiers/{soldier_id}")
def get_soldier(soldier_id: int):
    soldier = db_soldiers.get_by_id(soldier_id)
    if soldier is None:
        raise HTTPException(status_code=404, detail="Soldier not found")
    return soldier

@app.delete("/soldiers/{soldier_id}")
def remove_soldier(soldier_id: int):
    success = db_soldiers.delete_soldier(soldier_id)
    if not success:
        raise HTTPException(status_code=404, detail="Soldier not found")
    return {"message": "Deleted"}

if __name__ == "__main__":
    uvicorn.run("server_soldiers:app", reload=True)