from fastapi import FastAPI
import uvicorn

app = FastAPI()

@app.get("/calc/{a}/{op}/{b}")
def clac(a: int , op: str ,b : int ):
    """
    calculator
    """
    if op == 'add':
        result = a + b 
    elif op == "sub":
        result = a - b
    elif op == "mul":
        result = a * b
    elif op == 'div':
        if b == 0:
            return "Division by zero is prohibited"
        else:
            result = a / b
    return{"operation": op, "result": result}

if __name__ == "__main__":
    uvicorn.run("server03:app", host="127.0.0.1", port=8000, reload=True)

    