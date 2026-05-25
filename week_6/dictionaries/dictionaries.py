# #ex1
# def sum_of_values(my_dict):
#     sum = 0
#     for val in my_dict.values():
#         sum += val
#     return sum

# print(sum_of_values( {"a": 1, "b": 2, "c": 3}))

# #ex2
# def Key_with_maximum_value(my_dict):
#     max_val = max(my_dict.values())
#     for key in my_dict:
#         if my_dict[key] == max_val:
#             return key
        
# print(Key_with_maximum_value({"a": 3, "b": 7, "c": 5}))

# #ex3
# def count_characters(my_str):
#     new_dict = {}
#     for key in my_str:
#         if key not in new_dict:
#             new_dict[key] = 1
#         else:
#             new_dict[key] += 1
#     return new_dict

# print(count_characters("banana"))

# #ex4
# def invert_a_dictionary(my_dict):
#     new_dict = {}
#     for key , val in my_dict.items():
#         new_dict[val] = key
#     return new_dict

# print(invert_a_dictionary({"a": 1, "b": 2, "c": 3}))

# #ex5
# def merge_two_dictionaries(my_dict1,my_dict2):
#     my_dict1.update(my_dict2)
#     return my_dict1

# print(merge_two_dictionaries({"a": 1, "b": 2}, {"b": 20, "c": 30}))

# #ex6
# def filter_by_value(my_dict , k):
#     new_dict = {}
#     for key,item in my_dict.items():
#         if item > k:
#             new_dict[key] = item
#     return new_dict

# print(filter_by_value({"a": 1, "b": 5, "c": 3, "d": 8},3))

# #ex7
# def group_by_first_letter(my_list):
#     new_dict ={}
#     for item in my_list:
#         if item[0] not in new_dict:
#             new_dict[item[0]] = []
#         new_dict[item[0]].append(item)
#     return new_dict

# print(group_by_first_letter(["apple", "ant", "banana", "berry", "cherry"]))

# #ex8
# def word_frequency(my_str):
#     new_dict ={}
#     my_str = my_str.split(" ")
#     for item in my_str:
#         if item not in new_dict:
#             new_dict[item] = 1
#         else:
#             new_dict[item] +=1
#     return new_dict

# print(word_frequency("the cat sat on the mat"))

# #ex9
# def common_keys(my_list1,my_list2):
#     new_list = []
#     for key in my_list1:
#         if key in my_list2:
#             new_list.append(key)
#     return new_list

# print(common_keys({"a": 1, "b": 2, "c": 3}, {"b": 9, "c": 8, "d": 7}))

# #ex10
# def most_frequent_value(my_dict):
#     new_dict ={}
#     for val in my_dict.values():
#         if val not in new_dict:
#             new_dict[val ] = 1
#         else:
#             new_dict[val] +=1
#     my_max = max(new_dict.values())
#     for key,val in new_dict.items():
#         if val == my_max:
#             return key
# print(most_frequent_value({"a": 1, "b": 2, "c": 1, "d": 3, "e": 1}))