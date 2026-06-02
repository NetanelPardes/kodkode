from fastapi import FastAPI
import uvicorn

app = FastAPI()

@app.get("/greet")
def get_name(name = 'world'):
    return {"message": f"Hello, {name}!"}

# print(get_name())
# print(get_name('moshe'))

if __name__ == "__main__":
    uvicorn.run("client03_ser:app", reload=True)