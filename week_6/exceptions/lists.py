# #ex1
# def list_sum(my_list):
#     sum = 0
#     for item in my_list:
#         sum+= item
#     return sum 

# print(list_sum([1, 2, 3, 4]))

# #ex2
# def max_number(my_list):
#     my_max = my_list[0]
#     for item in my_list:
#         if my_max < item:
#             my_max = item
#     return my_max

# print(max_number([3, 7, 2, 8, 5]))

# #ex3
# def time_in_list(my_list , val):
#     count = 0
#     for item in my_list:
#         if item == val:
#             count += 1
#     return count

# print(time_in_list([1, 2, 3, 2, 4, 2],2))

# #ex4
# def reverce_list(my_list):
#     result = []
#     for index in my_list:
#         result.insert(0,index)
#     return result

# print(reverce_list( [1, 2, 3, 4] ))

# #ex5
# def no_duplicates_list(my_list):
#     new_list = []
#     for item in my_list:
#         if item not in new_list:
#             new_list.append(item)
#     return new_list

# print(no_duplicates_list([1, 2, 2, 3, 1, 4, 3]))

# #ex6
# def secend_largest(my_list):
#     my_max = max(my_list)
#     secend = None
#     for item in my_list:
#         if item != my_max:
#             if secend is None or item > secend:
#                 secend = item
#     return secend

# print(secend_largest([4, 1, 7, 7, 3, 5]))
# print(secend_largest( [10, 10, 10]))

# #ex7
# def two_sorted_lists_to_onw(list1,list2):
#     list3 = []
#     list1_index = 0
#     list2_index = 0
#     while list1_index < len(list1) and list2_index < len(list2):
#         if list1[list1_index] <= list2[list2_index]:
#             list3.append(list1[list1_index])
#             list1_index += 1
#         else:
#             list3.append(list2[list2_index])
#             list2_index += 1
#     list3.extend(list2[list2_index:])
#     list3.extend(list1[list1_index:])
#     return list3

# print(two_sorted_lists_to_onw( [1, 3, 5], [2, 4, 6]))

#ex8
def otated_to_the_right_by_k(my_list , k):
    k = k % len(my_list)
    return my_list[-k:] + my_list[:-k]

print(otated_to_the_right_by_k( [1, 2, 3, 4, 5],2))
print(otated_to_the_right_by_k( [1, 2, 3, 4, 5],7))