import time

def is_leap_year(year):
    if year % 400 == 0:
        return True
    elif year % 100 == 0:
        return False
    return year % 4 == 0

def get_months(year):
    months = {
        "jan": 31, "feb": 28, "mar": 31,
        "apr": 30, "may": 31, "jun": 30,
        "jul": 31, "aug": 31, "sep": 30,
        "oct": 31, "nov": 30, "dec": 31
    }
    if is_leap_year(year):
        months["feb"] = 29
    return months

def get_last_day(first_day_of_month, days_in_month):
    days = ["sun","mon","tue","wed","thur","fri","sat"]
    start = days.index(first_day_of_month)

    x = days_in_month % 7 + start - 1
    try:
        return days[x]
    except IndexError:
        return days[x - 7]

def next_first_day(first_day, days_in_month):
    last_day_of_prev_month = get_last_day(first_day, days_in_month)
    next_day = {
        "sun":"mon",
        "mon":"tue",
        "tue":"wed",
        "wed":"thur",
        "thur":"fri",
        "fri":"sat",
        "sat":"sun"
    }
    return next_day[last_day_of_prev_month]

def get_first_day_of_1901():
    months = get_months(1900)
    first_day = "mon"
    for days_in_month in months.values():
        first_day = next_first_day(first_day, days_in_month)
    return first_day

def is_sunday(day):
    return day == "sun"

def problem_19():
    num_sundays = 0
    first_day = get_first_day_of_1901()
    if is_sunday(first_day):
        num_sundays += 1

    for year in range(1901, 2001):
        months = get_months(year)
        for days_in_month in months.values():
            first_day = next_first_day(first_day, days_in_month)
            if is_sunday(first_day):
                num_sundays += 1

    return num_sundays

print(problem_19())
# 171