# #ex1
# for i in range(10):
#     if i%2==0:
#         continue
#     if i == 7:
#         break
#     print(i)

# #ex2
# while True:
#     my_paas = input("enter your passeord please: ")
#     if my_paas == '1234':
#         print("Welcome!")
#         break
#     print ("Try again")

# #ex3
# result = []
# while True:
#     my_product = input("what product do you want ? ")
#     if my_product == 'done':
#         print(result)
#         break
#     result.append(my_product)

# #ex3+
# for row in range(1,4):
#     for col in range(1,4):
#         if col == 2:
#             break
#         print((row,col))

# #ex4
# count = 0
# my_str = input("what do you want to say? ")
# for i in my_str:
#     if i.lower() in ['a', 'e', 'i', 'o', 'u']:
#         count +=1
# print(count)

# #ex5
# for row in range(1,6):
#     for col in range(1,6):
#         print(f" {row} * {col} = {col*row }")

# #ex6
# my_string = input("what do you want to say? ")
# result = ""
# for i in range(len(my_string)):
#     result += my_string[len(my_string) - i-1]
# print(result)

# #ex7
# count = 0
# my_number = int(input("enter a number: "))
# while my_number > 0:
#     if my_number % 2 == 0:
#         count += 1
#     my_number //=10
# print(count)

# #ex8
# my_string = input("what do you want to say? ")
# result = ""
# for index in my_string:
#     result += index + index
# print(result)

# #ex9
# my_max = 0
# while True:
#     my_num = int(input('enter a number please: '))
#     if my_num == 0:
#         print(f"the maximum number is: {my_max}")
#         break
        
#     if my_num > my_max:
#         my_max = my_num

# #ex10
# result = 0
# my_string = input("what do you want to say? ")
# for char in my_string:
#     if not(char.isalpha() or char.isdigit()):
#         result += 1
# print(False) if result > 0 else print(True)

# #ex11
# result = 0
# my_number = int(input("enter a number: "))
# while my_number > 0:
#     result = (result *10)  + my_number % 10
#     my_number //= 10
# print('The reciprocal number is: ' , result)