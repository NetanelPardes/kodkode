# #ex1
# def Sum_of_a_tuple(my_tuple):
#     sum = 0
#     for item in my_tuple:
#         sum += item
#     return sum

# print(Sum_of_a_tuple((1, 2, 3, 4, 5)))

# #ex2
# def maximum_element(my_tuple):
#     my_max = my_tuple[0]
#     for item in my_tuple:
#         if item > my_max:
#             my_max = item
#     return my_max

# print(maximum_element( (3, 7, 2, 8, 5)))

# #ex3
# def count_occurrences(my_tuple,value):
#     count = 0
#     for item in my_tuple:
#         if item == value:
#             count+=1
#     return count

# print(count_occurrences((1, 2, 3, 2, 4, 2),2))

# #ex4
# def reverse_a_tuple(my_tuple):
#     new_tuple = []
#     for item in my_tuple:
#         new_tuple.insert(0,item)
#     return tuple(new_tuple)

# print(reverse_a_tuple((1, 2, 3, 4)))

# #ex5
# def swap_pairs(my_tuple):
#     new_tuple = []
#     for index in range(0,len(my_tuple),2):
#         new_tuple.append(my_tuple[index+1] )
#         new_tuple.append(my_tuple[index])
#     return tuple(new_tuple)

# print(swap_pairs( (1, 2, 3, 4, 5, 6)))

# #ex6
# def min_and_max(my_tuple):
#     my_max = my_tuple[0]
#     my_min = my_tuple[0]
#     for item in my_tuple:
#         if my_max < item:
#             my_max = item
#         elif my_min > item:
#             my_min = item

#     return my_max , my_min

# print(min_and_max((4, 1, 7, 3, 5)))

# #ex7
# def distance_between_points(point1,point2):
#     return (((point1[0]-point2[0])**2) + ((point1[1]-point2[1])**2))**0.5

# print(distance_between_points((0, 0), (3, 4)))

# #ex8
# def merge_and_sort(my_tuple1,my_tuple2):
#     new_tuple = []
#     new_tuple.extend(list(my_tuple1))
#     new_tuple.extend(list(my_tuple2))
#     new_tuple.sort()
#     return tuple(new_tuple)

# print(merge_and_sort( (3, 1, 4), (1, 5, 9)))

# #ex9 
# def  frequency_table(my_tuple):
#     check_list = []
#     new_tuple =[]
#     for item in my_tuple:
#         if item not in check_list:
#             new_tuple.append((item , my_tuple.count(item)))
#             check_list.append(item)
#     return tuple(new_tuple)

# print(frequency_table( ("a", "b", "a", "c", "b", "a")))

# #ex10
# def rotate_a_tuple(my_tuple , k):
#     k = k % len(my_tuple)
#     new_tuple = []
#     new_tuple = my_tuple[-(k):] + my_tuple[:-(k)]
#     return tuple(new_tuple)

# print(rotate_a_tuple((1, 2, 3, 4, 5),0))
# print(rotate_a_tuple((1, 2, 3, 4, 5),1))
# print(rotate_a_tuple((1, 2, 3, 4, 5),2))
# print(rotate_a_tuple((1, 2, 3, 4, 5),3))
# print(rotate_a_tuple((1, 2, 3, 4, 5),4))
# print(rotate_a_tuple((1, 2, 3, 4, 5),5))
# print(rotate_a_tuple((1, 2, 3, 4, 5),6))
# print(rotate_a_tuple((1, 2, 3, 4, 5),7))
# print(rotate_a_tuple((1, 2, 3, 4, 5),8))
# print(rotate_a_tuple((1, 2, 3, 4, 5),9))
# print(rotate_a_tuple((1, 2, 3, 4, 5),10))