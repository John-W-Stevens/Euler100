import time

def problem_16():
    return sum([int(n) for n in f"{pow(2,1000)}"])

start = time.time()
solution = problem_16()
print(f"{solution} found in {time.time() - start} seconds.")
# 1366 found in 8.988380432128906e-05 seconds.