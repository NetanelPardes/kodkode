from datetime import datetime

#part b
def add_entry(filename, date, content):
        with open(filename , 'a' ,encoding="UTF-8") as file1:
            file1.write(f"{date} : {content}\n")

#part c
def search_diary(filename, keyword):
    try:
        with open(filename , 'r' ,encoding="UTF-8") as file1:
            result = []
            for line in file1:
                if keyword in line:
                    result.append(line)
            return result
    except FileNotFoundError as e:
        print(f"file not found")


def main():
    #part a
    with open("week_7//diary.txt" , 'w' ,encoding="UTF-8") as file1:
        file1.write(f"{datetime.now().strftime("%d/%m/%Y %H:%M")} I started learning Python today.\n")
        file1.write(f"{datetime.now().strftime("%d/%m/%Y %H:%M")} I practiced writing files with open().\n")
        file1.write(f"{datetime.now().strftime("%d/%m/%Y %H:%M")} I created my first diary file successfully!\n")
        print("The calendar was created successfully.")

    with open("week_7//diary.txt" , 'r' ,encoding="UTF-8") as file1:
        print(file1.read())

    add_entry("week_7//diary.txt",datetime.now().strftime("%d/%m/%Y %H:%M"),"Today I reviewed everything I learned this week .")

    print(search_diary("week_7//diary.txt" , 'this'))
    

if __name__ == "__main__":
    main()
