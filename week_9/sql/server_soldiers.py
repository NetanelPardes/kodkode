from fastapi import FastAPI, HTTPException, Query
import db_soldiers
import uvicorn
from pydantic import BaseModel

app = FastAPI()

class SoldierIn(BaseModel):
    name: str
    rank: str | None = None
    unit: str | None = None



@app.post("/setup")
def run_setup():
    db_soldiers.setup()
    return {"status": "setup completed"}

@app.get("/schema")
def get_schema():
    columns = db_soldiers.get_schema()
    return {"columns": columns}

@app.post("/soldiers", status_code=201)
def add_soldier(body: SoldierIn):
    new_id = db_soldiers.create(body.name, body.rank, body.unit)
    return {"id": new_id, "message": "Soldier created"}

@app.put("/soldiers/{soldier_id}")
def edit_soldier(soldier_id: int, body: SoldierIn):
    data = body.model_dump(exclude_none=True)
    success = db_soldiers.update(soldier_id, data)
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

@app.get("/soldiers/missing-rank")
def get_rank_with_null():
    return {"null rank": db_soldiers.get_with_missing_rank()}

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

@app.get("/stats/units")
def stats_by_unit():
    return {"by_unit": db_soldiers.count_by_unit()}

@app.get("/stats/summary")
def stats_summary():
    return db_soldiers.get_summary()

@app.get("/stats/understaffed")
def stats_by_understaffed():
    return {"by_unit": db_soldiers.get_units_with_multiple_soldiers()}

@app.get("/stats/units/top")
def most_soldiers():
    return {"most solders in" : db_soldiers.get_most_soldiers_unit()}

if __name__ == "__main__":
    uvicorn.run("server_soldiers:app", reload=True)