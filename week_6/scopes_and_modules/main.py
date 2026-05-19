import mathutils
from mathutils import square , cube
import tools
from datetime import datetime as dt
import math

#ex5
print(mathutils.square(5))
print(mathutils.cube(3))
print(square(5))
print(cube(3))

#ex6
print(tools.add(5,3))

#ex7
print(dt.now())

#ex8
names = dir(math)
public = []
for name in names:
    if not name.startswith('_'):
        public.append(name)
public = sorted(public)
print(public)

#ex9
def add_item(item, bag=None):
    if bag == None:
        bag = []
    bag.append(item)
    return bag
my_bag = ["book"]
print(add_item("pen", my_bag))
print(add_item("pencil", my_bag))

#ex10
from geometry import circle
from geometry import rectangle

print(circle.area(5))
print(rectangle.area(4,6))