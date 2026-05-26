#EX1
class Dog:
    """
    class dog
    """
    def __init__(self, name):
        """
        init dog
        """
        self.name = name

    def bark(self):
        """
        dog make sound
        """
        print(f"{self.name} says woof")
# rexi = Dog("rexi")
# rexi.bark()

#EX2
class Rectangle:
    """
    class rectangle
    """
    def __init__(self,width,height):
        """
        rectangle init
        """
        self.width = width
        self.height = height

    def area(self):
        """
        clac area of rectangle
        """
        return self.width * self .height
# x75 = Rectangle(3,7)
# print(x75.area())

#EX3
class Counter:
    """
    class Counter
    """
    
    def __init__(self, count = 0):
        """
        Counter init
        """
        self.count = count
    
    def increment(self):
        """
        increment counter
        """
        self.count += 1

    def value(self):
        """
        return Counter count
        """
        return self.count
# c = Counter()
# c.increment()
# c.increment()
# print(c.value()) 

#EX4
class Point:
    """
    point class
    """
    def __init__(self ,x ,y):
        """
        point init
        """
        self.x = x
        self.y = y

    def __str__(self):
        """
        print for my point
        """
        return f"({self.y}, {self.x})"
# p = Point(1,2)
# print(p)

#EX5
class BankAccount:
    """
    BankAccount class
    """
    def __init__(self, balance = 0):
        """
        BankAccount init
        """
        self.balance = balance

    def deposit(self,amount):
        """
        Deposit function from account
        """
        self.balance += amount

    def withdraw(self,amount):
        """
        Account withdrawal function
        """
        if self.balance - amount >= 0:
            self.balance -= amount
# my_acount = BankAccount()
# print(my_acount.balance)
# my_acount.deposit(1000)
# print(my_acount.balance)
# my_acount.withdraw(500)
# print(my_acount.balance)
# my_acount.withdraw(501)
# print(my_acount.balance)

#EX6
class Temperature:
    """
    Temperature class
    """
    def __init__(self,Celsius):
        """
        Temperature init
        """
        self.celsius = Celsius
    def to_fahrenheit(self):
        """
        Temperature conversion function to Fahrenheit
        """
        return self.celsius * 9 / 5 + 32
# my_temp = Temperature(100)
# print(my_temp.to_fahrenheit())

#EX7
class Student:
    """
    student class
    """
    school = "Kodcode"
    def __init__(self, name):
        """
        Student init
        """
        self.name = name
# a = Student("moshe")
# b = Student("levi")
# print(a.name)
# print(a.school)
# print(b.name)
# print(b.school)
# a.school = "JCT"
# print(a.name)
# print(a.school)
# print(b.name)
# print(b.school)

#EX8
class Player:
    """
    Player class
    """
    count = 0
    def __init__(self, name):
        """
        Player init
        """
        self.name = name
        Player.count += 1
# a = Player("a")
# b = Player("b")
# c = Player("c")
# print(Player.count)

#EX9
class Money:
    """
    Money class
    """
    def __init__(self,amount):
        """
        Money init
        """
        self.amount = amount
    
    def is_more_than(self, other):
        """
        Value comparison function
        """
        return self.amount > other.amount
# a = Money(50)
# b = Money(100)
# print(a.is_more_than(b))
# print(b.is_more_than(a))

#ex10
class Playlist:
    """
    Playlist class
    """
    def __init__(self):
        """
        Playlist init
        """
        self. songs = []
    
    def add(self, title):
        """
        Add a song to the list
        """
        self.songs.append(title)

    def remove(self, title):
        """
        Remove a song from a list
        """
        self.songs.remove(title)

    def count(self):
        """
        How many songs are on the list?
        """
        return len(self.songs)
    
    def __str__ (self):
        """
        Defines how to print the song list.
        """
        my_songs = ""
        for song in self.songs:
            my_songs += f"{song}\n" 
        return my_songs
# p = Playlist()
# p.add("Song One")
# p.add("Song Two")
# p.add("Song Three")
# print(p.count())
# print(p)
# p.remove("Song Two")
# print(p.count())
# print(p)
