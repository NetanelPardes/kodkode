# #ex1   
# count = 0
# def  bump():
#     global count
#     count += 1
# def value():
#     return count
# bump()
# bump()
# bump()
# print(value())

# #ex2
# def make_counter():
#     count = 0
#     def add_func():
#         nonlocal count
#         count += 1
#         return count
#     return add_func
# c = make_counter()
# print(c()) # 1
# print(c()) # 2
# print(c()) # 3

# #ex3
# x = "global"
# def outer():
#     x = "enclosing"
#     def inner():
#         x = "local"
#         print(x)
#     inner()
#     print(x)
# outer()
# print(x)

# #ex4
# list = [1, 2, 3]
# print(list(range(5)))
#Because once I call a function with the name of a variable, I won't be able to use it.

