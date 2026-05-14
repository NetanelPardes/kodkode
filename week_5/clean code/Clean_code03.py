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

# #ex3
# def student_name_propriety_check(new_name):
#     if not new_name or len(new_name) < 2:
#         print("Error: invalid name")
#         return False
#     return True

# def student_grade_propriety_check(new_grade):
#     if new_grade < 0 or new_grade > 100:
#         print("Error: grade must be 0-100")
#         return False
#     return True

# def calculating_statistics (grades):
#     total = sum(grades)
#     average = total / len(grades)
#     top_count = sum(1 for grade in grades if grade >= 90)
#     failing_count = sum(1 for grade in grades if grade < 56)

#     return  average, top_count,failing_count

# def report_Print(names,grades, statistics_calc):
#     average, top_count,failing_count = statistics_calc
#     print("=== Student Report ===")
#     for i in range(len(names)):
#         print(f"{names[i]}: {grades[i]}")

#     print(f"Average: {average:.1f}")
#     print(f"Top students: {top_count}")
#     print(f"Failing: {failing_count}")

# def save_students_to_file(names,grades):
#     with open("students.txt", "w") as f:
#         for i in range(len(names)):
#             f.write(f"{names[i]},{grades[i]}\n")

# def add_new_student(names, grades, new_name, new_grade):
#     names.append(new_name)
#     grades.append(new_grade)
#     return names, grades
    


# def manage_students(names, grades, new_name, new_grade):
#     # validation
#     if student_name_propriety_check(new_name) and student_grade_propriety_check(new_grade):
        
#         # add student
#         names, grades = add_new_student(names, grades, new_name, new_grade)

#         # calculate stats
#         statistics_calc = calculating_statistics(grades)
        
#         # print report
#         report_Print(names,grades, statistics_calc)
        

#         # save to file
#         save_students_to_file(names,grades)
        

#         return names, grades
    
# names = ["David", "Sara", "Moshe"]
# grades = [95, 72, 44]

# manage_students(names, grades, "Noa", 88)


# #ex4
# def create_admin_user(name, email):
#     validate_name_and_email(name, email)
#     return name, email, "admin", "2024-01-01", True
    
# def create_editor_user(name, email):
#     validate_name_and_email(name, email)
#     return name, email, "editor", "2024-01-01", True
    
# def create_viewer_user(name, email):
#     validate_name_and_email(name, email)
#     return name, email, "viewer", "2024-01-01", True

# def validate_name_and_email(name, email):
#     if not name or len(name) < 2:
#         raise ValueError("Invalid name")
#     if "@" not in email:
#         raise ValueError("Invalid email")
    
# # tests
# print(create_admin_user("David", "david@gmail.com"))
# print(create_editor_user("Avi", "avi@gmail.com"))
# print(create_viewer_user("Moshe", "moshe@gmail.com"))
# print(create_admin_user("D", "david@gmail.com"))

# #ex5
# def get_status(score):
#     if score >= 90:
#         return "excellent"
#     elif score >= 70:
#         return "good"
#     elif score >= 55:
#         return "average"
#     else:
#         return "fail"


# def is_valid_age(age):
#     if isinstance(age, int) and 0 < age < 120:
#         return True
#     return False


# def get_greeting(hour):
#     if 5 <= hour < 12:
#         return "Good morning"
#     elif 12 <= hour < 17:
#         return "Good afternoon"
#     elif 17 <= hour < 21:
#         return "Good evening"
#     else:
#         return "Good night"

# #tests
# print(get_status(95))   # excellent
# print(get_status(80))   # good
# print(get_status(60))   # average
# print(get_status(40))   # fail

# print(is_valid_age(25))     # True
# print(is_valid_age(-3))     # False
# print(is_valid_age(130))    # False
# print(is_valid_age("25"))   # False

# print(get_greeting(8))    # Good morning
# print(get_greeting(14))   # Good afternoon
# print(get_greeting(19))   # Good evening
# print(get_greeting(23))   # Good night

# #ex6

# def validate_student(name, grades):
#     if not name:
#         print("Error: missing name")
#         return False

#     if not grades:
#         print(f"Error: {name} has no grades")
#         return False

#     return True


# def calculate_student_stats(grades):
#     average = sum(grades) / len(grades)
#     status = "pass" if average >= 56 else "fail"
#     highest = max(grades)
#     lowest = min(grades)

#     return round(average, 1), status, highest, lowest


# def print_report(result_names, result_averages, result_statuses, result_highs, result_lows):
#     print("=" * 40)
#     print("Student Grade Report")
#     print("=" * 40)

#     for i in range(len(result_names)):
#         print(f"Name: {result_names[i]}")
#         print(f"Average: {result_averages[i]}")
#         print(f"Status: {result_statuses[i]}")
#         print(f"Range: {result_lows[i]} - {result_highs[i]}")
#         print()

#     passing_count = sum(1 for status in result_statuses if status == "pass")
#     print(f"Total passing: {passing_count}/{len(result_names)}")


# def process_grades(names, all_grades):
#     result_names = []
#     result_averages = []
#     result_statuses = []
#     result_highs = []
#     result_lows = []

#     for i in range(len(names)):
#         name = names[i]
#         grades = all_grades[i]

#         if not validate_student(name, grades):
#             continue

#         average, status, highest, lowest = calculate_student_stats(grades)

#         result_names.append(name)
#         result_averages.append(average)
#         result_statuses.append(status)
#         result_highs.append(highest)
#         result_lows.append(lowest)

#     print_report(result_names, result_averages, result_statuses, result_highs, result_lows)

#     return result_names, result_averages, result_statuses

# names = ["David", "Avi", "", "Moshe", "Yossi"]
# all_grades = [
#     [90, 80, 100],
#     [40, 50, 60],
#     [70, 80],
#     [],
#     [55, 56, 57]
# ]

#tests
# print(process_grades(names, all_grades))



#ex7
TAX_RATE = 0.17


def process_cart(prices, quantities, user_type):
    total = 0

    for i in range(len(prices)):
        price = prices[i]
        quantity = quantities[i]
        total += price * quantity

    # Tax is added before discount because the store calculates discount on final taxed price
    total += total * TAX_RATE

    # Different user types receive different loyalty discounts
    if user_type == "premium":
        total *= 0.9
    elif user_type == "vip":
        total *= 0.8

    # Shipping becomes cheaper for larger orders to encourage bigger purchases
    if total > 500:
        shipping = 0
    elif total > 200:
        shipping = 25
    else:
        shipping = 50

    total += shipping

    return total

#tests
prices = [100, 50, 20]
quantities = [2, 3, 5]

print(process_cart(prices, quantities, "regular"))
print(process_cart(prices, quantities, "premium"))
print(process_cart(prices, quantities, "vip"))

