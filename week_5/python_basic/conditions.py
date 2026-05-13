# #ex1
# age = int(input("Enter the age: "))
# if age < 0 or age > 120:
#     print("Invalid")
# elif age <= 12:
#     print("Child")
# elif age <= 17:
#     print("Teen")
# else:
#     print("Adult")

# #ex2
# my_char = (input("Enter the char: "))
# if not(my_char >= 'a' and my_char <= 'z') and not(my_char >= 'A' and my_char <= 'Z'):
#     print("Invalid")
# elif my_char in ['a', 'e', 'i', 'o', 'u']:
#     print("Vowel")
# else:
#     print ("Consonant")

# # #ex3
# age = int(input("Enter the age: "))
# vip = input("Is there a VIP? ")
# if age < 18:
#     print("reject")
# elif age in [19,20,21]:
#     print("welcom to the club")
# elif (age > 18 and vip == "yes"):
#     print("welcom to the club")
# else:
#     print("reject")

# #ex4
# my_pass = "gftrl7g!"
# your_pass = input("Enter your password ")
# if my_pass == your_pass:
#     print("Access Granted")
# elif len(your_pass) < 8 :
#     print("Too short")
# else:
#     print("Wrong password")

# #ex5
# x = int(input("Enter your x:" ))
# y = int(input("Enter your y:" ))

# if (x > 10 and x < 50 and y > 20 and y < 80):
#     print("Inside the rectangle")
# elif (x == 10 or x == 50) and (y >= 20 and y <= 80):
#     print("On the edge")

# elif (y == 20 or y == 80) and (x >= 10 and x <= 50):
#     print("On the edge")
# else:
#     print("Outside the rectangle")

# #ex6
# the_name = input("enter your name: ")
# print("Welcome" ,the_name or "Anonymous")

# #ex8
# x = int(input("enter a number: "))
# y = int(input("enter a number: "))
# z = int(input("enter a number: "))
# print((x>0) + (y>0) + (z>0))

# #ex10
# grade = int(input("Enter your grade: (from 0 to 100): "))
# print('A' if grade <= 100 and grade >= 90 else 'B' if grade <= 89 and grade >= 80 else 'C' if grade <= 79 and grade >= 70 else 'F')