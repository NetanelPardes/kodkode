# #ex1 
# def active_pepole_sort(pepole_list):
#     active_pepole_result = []
#     for person in pepole_list:
#         if person[1] >= 18 and person[2] == "active":
#             active_pepole_result.append(person[0])
#     return active_pepole_result

# pepole = [
#     ["Dan", 25, "active"],
#     ["Noa", 16, "active"],
#     ["Yael", 30, "inactive"],
# ]

# print(active_pepole_sort(pepole))

# #ex2


# def product_check_quantity(stock, quantity):
#     if quantity <= 0 or quantity > stock:
#         print("Invalid quantity")
#         return None
#     return True
    
# def product_check_email(user_email):
#     if not user_email:
#         print("Invalid user")
#         return None
#     return True

# def discount_calc(product_price,quantity):
#     price = product_price * quantity
#     if quantity >= 10:
#         price *= 0.9
#     if quantity >= 50:
#         price *= 0.85
#     return price

# def order_get(user_email, product_name,quantity,price):
#     order_user = user_email
#     order_product = product_name
#     order_quantity = quantity
#     order_total = price
#     order_status = "confirmed"
#     return order_user, order_product, order_quantity, order_total, order_status

# def order_print (order):
#     order_user, order_product, order_quantity, order_total, order_status = order
   
#     print(f"Order {order_status}: {order_user} \nbought {order_quantity} x {order_product} for ${order_total}")

# def stock_sum(stock,quantity):
#     stock -= quantity

# def handle_purchase(user_email, product_name, product_price, stock, quantity):
#     if product_check_quantity(stock, quantity) and product_check_email (user_email):
#         price = discount_calc(product_price,quantity)
#         order = order_get(user_email, product_name,quantity,price)
#         stock = stock_sum(stock,quantity)
#         order_print(order)

# handle_purchase("test@gmail.com", "Laptop", 100, 20, 10)

#ex3
def student_name_propriety_check(new_name):
    if not new_name or len(new_name) < 2:
        print("Error: invalid name")
        return False
    return True

def student_grade_propriety_check(new_grade):
    if new_grade < 0 or new_grade > 100:
        print("Error: grade must be 0-100")
        return False
    return True

def calculating_statistics (grades):
    total = sum(grades)
    average = total / len(grades)
    top_count = sum(1 for grade in grades if grade >= 90)
    failing_count = sum(1 for grade in grades if grade < 56)

    return  average, top_count,failing_count

def report_Print(names,grades, statistics_calc):
    average, top_count,failing_count = statistics_calc
    print("=== Student Report ===")
    for i in range(len(names)):
        print(f"{names[i]}: {grades[i]}")
    print(f"Average: {average:.1f}")
    print(f"Top students: {top_count}")
    print(f"Failing: {failing_count}\n")

def save_students_to_file(names,grades):
    with open("students.txt", "w") as f:
        for i in range(len(names)):
            f.write(f"{names[i]},{grades[i]}\n")

def add_new_student(names, grades, new_name, new_grade):
    names.append(new_name)
    grades.append(new_grade)
    return names, grades
    


def manage_students(names, grades, new_name, new_grade):
    # validation
    if student_name_propriety_check(new_name) and student_grade_propriety_check(new_grade):
        
        # add student
        names, grades = add_new_student(names, grades, new_name, new_grade)

        # calculate stats
        statistics_calc = calculating_statistics(grades)
        
        # print report
        report_Print(names,grades, statistics_calc)
        

        # save to file
        save_students_to_file(names,grades)
        

        return names, grades
    
names = ["David", "Sara", "Moshe"]
grades = [95, 72, 44]

manage_students(names, grades, "Noa", 88)
