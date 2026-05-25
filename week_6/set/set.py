# #ex1
# def remove_duplicates(my_list):
#     return list(set(my_list))

# print(remove_duplicates( [1, 2, 2, 3, 1, 4, 3]))

# #ex2
# def count_unique_elements(my_list):
#     my_list = list(set(my_list))
#     sum = 0 
#     for _ in my_list:
#         sum += 1
#     return sum

# print(count_unique_elements([1, 2, 2, 3, 1, 4]))

# #ex3
# def common_elements(my_list1 , my_list2):
#     return list(set(my_list1)& set(my_list2))
    

# print(common_elements([1, 2, 3, 4], [3, 4, 5, 6]))

# #ex4
# def elements_in_only_one(my_list1 , my_list2):
#     return list(set(my_list1)^ set(my_list2))
# print(elements_in_only_one([1, 2, 3, 4], [3, 4, 5, 6]))

# #ex5
# def is_subset(my_list1 , my_list2):
#     if set(my_list1) <= set(my_list2):
#         return True
#     return False

# print(is_subset([1, 2, 3], [1, 2, 3, 4, 5]))
# print(is_subset([1, 2, 6], [1, 2, 3, 4, 5]))

# #ex6
# def unique_characters(my_str):
#     if len(my_str) == len(set(my_str)):
#         return True
#     return False

# print(unique_characters( "abcdef"))
# print(unique_characters("hello"))


# #ex7
# def first_repeated_element(my_list):
#     for item in my_list:
#         if my_list.count(item) > 1:
#             return item
#     return None

# print(first_repeated_element([1, 2, 3, 2, 4, 1] ))
# print(first_repeated_element([1, 2, 3, 4]))

# #ex8
# def distinct_words(my_str):
#     new_str = my_str.lower()
#     new_list =new_str.split(" ")
#     return len(set(new_list))

# print(distinct_words("The cat and the dog and the bird"))

# #ex9
# def pair_sum_exists (my_list, target):
#     for item in my_list:
#         if (target - item) in my_list:
#             return True
#     return False

# print(pair_sum_exists( [3, 1, 4, 7, 2],6))
# print(pair_sum_exists( [3, 1, 4, 7, 2],100))

# #ex10
# def symmetric_difference_without_operators(my_list1,my_list2):
#     return list((set(my_list1)|set(my_list2)) - (set(my_list1)&set(my_list2)))

# print(symmetric_difference_without_operators( [1, 2, 3, 4], [3, 4, 5, 6]))
