
import time

def read_from_file_and_build_triangle(file_path):
    return [ [int(n) for n in line.split(" ")] for line in open(file_path, "r")]

def compare_children_and_add_largest_child(triangle, i, j):
    if triangle[i+1][j] > triangle[i+1][j+1]:
        add_left_child(triangle,i,j)
    else:
        add_right_child(triangle,i,j)

def add_left_child(triangle,i,j):
    triangle[i][j] += triangle[i+1][j]

def add_right_child(triangle,i,j):
    triangle[i][j] += triangle[i+1][j+1]

def problem_18():
    triangle = read_from_file_and_build_triangle("./problem_18.txt")
    for i in range(len(triangle)-2,-1,-1):
        for j in range(i+1):
            compare_children_and_add_largest_child(triangle, i, j)
    return triangle[0][0]

start = time.time()
solution = problem_18()
print(f"{solution} found in {time.time() - start} seconds.")
# 1074 found in 0.0007259845733642578 seconds.