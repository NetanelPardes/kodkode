#part a
def create_grades_file(filename):
    students = [
    ("Dan", [85, 90, 78]),
    ("MOMO", [92, 88, 95]),
    ("Yoni", [70, 65, 80]),
    ("Avi", [100, 95, 98]),
    ("Sara", [60, 72, 68]),
    ("Netanel" , [20,50])
    ]
    with open (filename , 'w' ,encoding="UTF-8") as file1:
        try:
            for student in students:
                file1.write(f"{student[0]} , {student[1][0]} , {student[1][1]} , {student[1][2]}\n")
        except IndexError as  e:
            print("Warning, ungraded")

#PART B
def calculate_averages(filename):
    '''
    מחשבת ממוצע לכל סטודנט ,txt.grades קוראת
    {שם: ממוצע} dict :מחזיר
    '''
    averages = {}
    try:
        with open (filename , 'r' ,encoding="UTF-8") as file1:
            for line in file1:
                myline = line.split(',')
                averages[myline[0]] = (int(myline[1]) + int(myline[2]) + int(myline[3])) /3 
    except FileNotFoundError as e:
        print("file not found")    
    return averages

#part c
def save_results(averages, output_filename):
    '''
    כותבת לקובץ:
    שורה ראשונה: כותרת
    שורות הבאות: שם וממוצע, ממוין מהגבוה לנמוך
    '''
    with open(output_filename, 'w', encoding="UTF-8") as file1:
        file1.write("=== Student Results ===\n")

        averages = sorted(
            averages.items(),
            key=lambda item: item[1],
            reverse=True
        )

        for key, val in averages:
            file1.write(f"{key}: {val:.1f}\n")

#part d
def add_statistics(averages, output_filename):
    with open (output_filename , 'a' , encoding="UTF-8") as file1:
        file1.write("\n=== Statistics ===\n")
        file1.write(f"Class average: {sum(averages.values())/len(averages):.1f}\n")
        my_max = max(averages , key = averages.get)
        file1.write(f"Highest: {my_max} ({averages[my_max]:.1f})\n")
        my_min = min(averages , key = averages.get)
        file1.write(f"Lowest: {my_min} ({averages[my_min]:.1f})\n")
        count = 0
        for grade in averages.values():
            if grade >= 60:
                count += 1
        file1.write(f"Passing (>=60): {count}")

def main():
    create_grades_file('week_7//grades.txt')

    results = calculate_averages('week_7//grades.txt')
    for name, avg in results.items():
        print(f'{name}: {avg:.1f}')

    averages = calculate_averages('week_7//grades.txt')
    save_results(averages, 'week_7//results.txt')

    add_statistics(averages, 'week_7//results.txt')

if __name__ == "__main__":
    main()