
import time

def problem_8():
    limit = int(500**0.5) + 1
    for m in range(1, limit + 1):
        for n in range(1, m):
            if m**2 + m*n == 500:
                return (m**2 - n**2) * 2*m*n * (m**2 + n**2)

start = time.time()
solution = problem_8()
print(f"{solution} found in {time.time() - start} seconds.")
# 31875000 found in 6.985664367675781e-05 seconds.