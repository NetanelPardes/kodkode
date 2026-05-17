import random
# #x1
# def safe_int(s):
#     try:
#         return int(s)
#     except ValueError:
#         return None
    
# print (safe_int("42"))
# print (safe_int("42a"))

# #ex2
# def safe_divide(a, b):
#     try:
#         return a /b
#     except ZeroDivisionError:
#         return "undefined"
#     except TypeError:
#         return TypeError

# print(safe_divide(3,2))
# print(safe_divide(3,0))
# print(safe_divide(3,"2"))
# print(safe_divide("3",2))

# #ex3
# def get_value(d, key):
#     try:
#         return d[key]
#     except KeyError:
#         return "missing"
    
# print(get_value({"name": "Netanel", "age": 25}, "name"))  # Expected: Netanel
# print(get_value({"name": "Netanel", "age": 25}, "city"))  # Expected: missing

# print(get_value({}, "anything"))  # Expected: missing

# #ex4
# def parse_ints(values):
#     result = []
#     for i in values:
#         try:
#             result.append(int(i))
#         except ValueError:
#             continue
#     return result
    
# print (parse_ints(["1", "2", "x", "3", "y"]))

# #ex5
# def set_age(age):
#     if age < 0 or age > 150:
#         raise ValueError("Error age")
#     return age

# try:
#     print(set_age(151))
# except ValueError as error:
#     print(error)

# #ex6
# def retry(func, n):
#     count = 0 
#     for i in range(n):
#         try:
#             return int(func())
#         except ValueError:
#             count += 1
#             if count == n:
#                 raise
    

# def random_choce():
#     return random.choice(['b','a',4,5])

# print(retry(random_choce,3))

# #ex7
# def count_errors(funcs):
#     count = 0
#     for func in funcs:
#         try:
#             func()
#         except:
#             count +=1
#     return count

# def func1():
#     return 1*2


# def func2():
#     return 1 / 0


# def func3():
#     return int("x")


# def func4():
#     return 2/2

# print(count_errors([func1, func2, func3, func4]))

#ex8
def load_config(path):
    with open(path,'r',encoding='UTF-8') as f1:
        try:
            return int(f1.readline().strip())
        except Exception as e:
            raise RuntimeError("failed to load config") from e

print(load_config('text.txt'))