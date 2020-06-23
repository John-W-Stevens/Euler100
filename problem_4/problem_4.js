// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
// Find the largest palindrome made from the product of two 3-digit numbers.

const now = require("performance-now")

const reverseString = astring => astring.split("").reverse().join("");
const isPal = aString => aString == reverseString(aString)

const problem4 = () => {
    let largest_pal = 0;
    for (var i = 999; i > 100; i--){
        for (var j = i; j > 100; j--){
            let number = i * j;
            if (number < largest_pal) { break } // first optimization
            if (number % 11 != 0){ continue } // second optimization
            if (isPal(number.toString())){
                largest_pal = number;
            }
        }
    }
    return largest_pal;
}

let start = now();
let solution = problem4()
console.log(`${solution} found in ${(now() - start) / 1000} seconds.`)
// 906609 found in 0.000939267000000001 seconds.