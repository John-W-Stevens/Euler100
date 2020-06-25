// The sum of the squares of the first ten natural numbers is,
// 1^2 + 2^2 + ... + 10^2 = 385
// The square of the sum of the first ten natural numbers is,
// (1 + 2 + ... + 10)^2 = 55^2 = 3025
// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

const now = require("performance-now");

// iterative method
const problem6a = n => {
    let sumOfSquares = 0;
    let squareOfSum = 0;
    
    for (var i = 1; i <= n; i++){
        sumOfSquares += i**2;
        squareOfSum += i;
    }
    return squareOfSum**2 - sumOfSquares;
}
// mathematical method
const problem6b = n => {
    let sumOfSquares = n * (n + 1) * (2*n + 1) * (1 / 6);
    let squareOfSum = (n * (n + 1) / 2) ** 2;
    return squareOfSum - sumOfSquares;
}

let start1 = now();
let solution1 = problem6a(100)
console.log(`${solution1} found in ${(now() - start1) / 1000} seconds.`)
// 25164150 found in 0.00003263299999999702 seconds.

let start2 = now();
let solution2 = problem6b(100)
console.log(`${solution2} found in ${(now() - start2) / 1000} seconds.`)
// 25164150 found in 0.00006033100000000502 seconds.