from fastapi import FastAPI
import uvicorn

grades = {
"1": {"name": "Moshe", "grade": 88},
"2": {"name": "Yaakov", "grade": 75},
"3": {"name": "David", "grade": 92},
}

app = FastAPI()

@app.get("/students")
def get_all_students():
    """
    Returns all students
    """
    return grades

@app.get("/students/top")
def best_grade():
    """
    Returns all students with the best score
    """
    my_best =  max(grades.values(), key=lambda student: student["grade"])
    return f"the best student is {my_best['name']} with grade {my_best['grade']}"

@app.get("/students/count")
def students_count():
    """
    Returns the number of students
    """
    return f"The number of students in the class is {len(grades)}"

@app.get("/students/average")
def students_average():
    """
    Returns the average of the students
    """
    sum = 0
    for student in grades.values():
        sum += student["grade"]
    return f"the average of the class is {sum / len(grades)}"

@app.get("/students/{student_id}")
def get_student(student_id):
    """
    Returns the specific student
    """
    if student_id in grades:
            return f"The student {grades[student_id]['name']}'s grade is {grades[student_id]['grade']}."
    return f"There is no student whose number is {student_id}."



if __name__ == "__main__":
    uvicorn.run("server05:app", host="127.0.0.1", port=8000, reload=True)