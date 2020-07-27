const now = require("performance-now");

const isLeapYear = year => {
    if (year % 400 === 0 ){ return true }
    else if (year % 100 === 0){ return false }
    else { return year % 4 === 0 };
}
const getMonths = year => {
    const months = {
        "jan": 31, "feb": 28, "mar": 31,
        "apr": 30, "may": 31, "jun": 30,
        "jul": 31, "aug": 31, "sep": 30,
        "oct": 31, "nov": 30, "dec": 31
    };
    if (isLeapYear(year)){
        months["feb"] = 29
    }
    return months;
}
const getLastDayOfMonth = (firstDayOfMonth, daysInMonth) => {
    const days = ["sun","mon","tue","wed","thur","fri","sat"]
    const start = days.indexOf(firstDayOfMonth)
    const indexOfLastDay = daysInMonth % 7 + start

    if (indexOfLastDay >= 0 && indexOfLastDay < days.length) {
        return days[indexOfLastDay]
    }
    else {
        return days[indexOfLastDay - 7]
    }
}
const nextFirstDayOfMonth = (prevFirstDay, daysInMonth) => {
    const LastDayOfMonth = getLastDayOfMonth(prevFirstDay, daysInMonth);
    const nextDay = {
        "sun":"mon",
        "mon":"tue",
        "tue":"wed",
        "wed":"thur",
        "thur":"fri",
        "fri":"sat",
        "sat":"sun"
    }
    return nextDay[LastDayOfMonth]
}

const getFirstDayOf1901 = () => {
    const months = getMonths(1900)
    var firstDay = "mon";
    for (const daysInMonth of Object.values(months)){
        firstDay = nextFirstDayOfMonth(firstDay, daysInMonth)
    }
    return firstDay;
}

const isSunday = day => day === "sun";

const problem19 = () => {
    let numSundays = 0;
    var firstDay = getFirstDayOf1901();
    if (isSunday(firstDay)){ numSundays += 1 }

    for (var year = 1901; year <= 2000; year ++){
        let months = getMonths(year)
        for (const daysInMonth of Object.values(months)){
            firstDay = nextFirstDayOfMonth(firstDay, daysInMonth)
            if (isSunday(firstDay)){ numSundays += 1 }
        }
    }
    return numSundays;
}

let start = now()
let solution = problem19()
console.log(`${solution} found in ${(now()-start) / 1000} seconds.`)
// 171 found in 0.0009509399999999957 seconds.