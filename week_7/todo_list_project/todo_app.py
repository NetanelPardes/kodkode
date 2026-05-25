def load_tasks(filename):
    """
    קוראת את הקובץ ומחזירה רשימה של מילונים:
    [
        {"id": 1, "status": "PENDING", "desc": "ללמוד Python"},
        ...
    ]

    אם הקובץ לא קיים — מחזירה רשימה ריקה.
    """
    try:
        with open (filename , 'r' , encoding="UTF-8") as mt_file:
            my_tasks_list = []
            for line in mt_file:

                task_line = line.strip().split('|')

                my_task = {}
                
                my_task['id'] = int(task_line[0])
                my_task['status'] = task_line[1]
                my_task['desc'] = task_line[2]

                my_tasks_list.append(my_task)
            return my_tasks_list
    except FileNotFoundError as e:
        print(f"{e}: sorry file not exist")
        return []


def save_tasks(filename, tasks):
    """
    שומרת את רשימת המשימות לקובץ.

    פורמט כל שורה בקובץ:
    id|status|description
    """
    with open (filename , 'w' , encoding="UTF-8") as my_file:
        for line in tasks:
            my_file.write(f"{line['id']}|{line['status']}|{line['desc']}\n")


def add_task(filename, description):
    """
    מוסיפה משימה חדשה עם:
    - id: מספר המשימה הבא
    - status: "PENDING"
    - desc: description
    """
    n = len(load_tasks(filename))

    with open (filename , 'a' , encoding="UTF-8") as my_file:
        my_file.write(f"{n+1}|PENDING|{description}\n")


def complete_task(filename, task_id):
    """
    משנה את הסטטוס של משימה לפי task_id
    מ-"PENDING" ל-"DONE".

    אם ה-id לא קיים — מדפיסה הודעת שגיאה.
    """
    my_list_task = load_tasks(filename)

    found = False
    for line in my_list_task:
        if line['id'] ==  task_id:
            line['status'] = "DONE"
            found = True
    if not found:
        print("Error: Task id does not exist.")
        return
    
    save_tasks(filename, my_list_task)


def list_tasks(filename):
    """
    מציגה את כל המשימות בפורמט מסודר.

    דוגמה:
    [✓] 1 | ללמוד Python
    [ ] 2 | לסיים את הפרויקט
    """
    my_list_task = load_tasks(filename)

    for task in my_list_task:
        if task['status'] == "PENDING":
            print(f"[ ] {task['id']} | {task['desc']}")
        else: 
            print(f"[✓] {task['id']} | {task['desc']}")


def main():
    FILENAME = "week_7//todo_list_project//tasks.txt"

    while True:
        print("\n=== To-Do List Manager ===")
        print("1. Show tasks")
        print("2. Add task")
        print("3. Mark as completed")
        print("4. Exit")

        choice = input("Choice: ")

        if choice == "1":
            list_tasks(FILENAME)

        elif choice == "2":
            desc = input("Task description: ")
            add_task(FILENAME, desc)
            print("Task added!")

        elif choice == "3":
            try:
                task_id = int(input("Task number: "))
                complete_task(FILENAME, task_id)
            except ValueError as e:
                print(f"{e} : this is not a number")
            

        elif choice == "4":
            print("Goodbye!")
            break

        else:
            print("Invalid choice")

if __name__ == "__main__":
    main()