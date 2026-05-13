# #ex1
# def is_even(n):
#     return True if n % 2 == 0 else False

# #tests
# print(is_even(4))
# print(is_even(3))


# #ex2
# def  factorial(n):
#     sum = 1 
#     for i in range (2,n+1):
#         sum *= i
#     return sum 

# #tests
# print(factorial(1))
# print(factorial(2))
# print(factorial(3))
# print(factorial(4))
# print(factorial(5))

# #ex3
# def digital_root(n):
#     while n > 9:
#         n = sum_digits(n)
#     return n

# def sum_digits(n):
#     result = 0
#     while n > 0:
#         result += (n%10)
#         n //= 10
#     return result

# #tests
# print(digital_root(123))
# print(digital_root(1234))
# print(digital_root(234))
# print(digital_root(111))
# print(digital_root(99))
# print(digital_root(999))

# #ex4
# def is_palindrome(s):
#     for i in range(len(s)//2): 
#         if s[i] != s[len(s)-i-1]:
#             return False
#     return True

# #tests
# print(is_palindrome("aba"))
# print(is_palindrome("abba"))
# print(is_palindrome("agba"))
# print(is_palindrome("agb"))
# print(is_palindrome("123"))
# print(is_palindrome("123321"))
# print(is_palindrome("12321"))

# #ex6
# def count_digits(n):
#     counter = 0
#     while n > 0:
#         counter += 1
#         n //= 10
#     return counter

# #tests
# print(count_digits(1))
# print(count_digits(12))
# print(count_digits(123))
# print(count_digits(13))
# print(count_digits(1258))
# print(count_digits(178776))

#ex7
def reverse_integer(n):
    result = 0
    while n > 0:
        






