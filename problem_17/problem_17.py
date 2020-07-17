import time

def problem_17():
    ones = [len(n) for n in [
        "one","two","three","four","five",
        "six","seven","eight","nine",
    ]]
    teens = [len(n) for n in [
        "eleven","twelve","thirteen","fourteen","fifteen",
        "sixteen","seventeen","eighteen","nineteen",
    ]]
    tens = [len(n) for n in [
        "ten","twenty","thirty","forty","fifty",
        "sixty","seventy","eighty","ninety",
    ]]
    hundreds = [7+n for n in ones]

    letters = 0

    letters += sum(ones) + sum(teens) + sum(tens) + sum(hundreds)
    letters += sum([ten + one for one in ones for ten in tens[1::]])
    letters += sum([h + 3 + one for one in ones for h in hundreds])
    letters += sum([h + 3 + t for t in teens for h in hundreds])
    letters += sum([h + 3 + t for t in tens for h in hundreds])
    letters += sum([h + 3 + t + one for one in ones for t in tens[1::] for h in hundreds])
    letters += 11 # one thousand
    
    return letters

start = time.time()
solution = problem_17()
print(f"{solution} found in {time.time() - start} seconds.")
# 21124 found in 0.00010371208190917969 seconds.