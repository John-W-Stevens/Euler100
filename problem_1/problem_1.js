// Problem:
// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.
// The sum of these multiples is 23. Find the sum of all the multiples of 3 or 5 below 1000.

const now = require("performance-now");

// The iterative approach:
const Problem1a = n => {
    let total = 0;
    for (var i=3; i<n; i++){
        if (i % 3 === 0 || i % 5 === 0){
            total += i;
        }
    }
    return total;
}
var start1 = now();
let solution1 = Problem1a(1000);
console.log(`${solution1} found in ${(now() - start1) / 1000} seconds.`)
// 233168 found in 0.00006294600000000372 seconds.

const SumAS = (a,d,n) => {
    // Returns the sum of an arithmetic sequence
    // a: first term in series,
    // d: difference between each term
    // n: number of terms we want to sum 
    return n/2 * (2*a + (n-1) * d)
}

const Problem1b = n => {
    let x = SumAs(3,3,Math.floor(n-1,3));
    let y = SumAs(5,5,Math.floor(n-1,5));
    let z = SumAs(15,15,Math.floor(n-1,15));
    return x + y - z;
}

var start2 = now();
let solution2 = Problem1a(1000);
console.log(`${solution2} found in ${(now() - start2) / 1000} seconds.`)
// 233168 found in 0.000038717000000005444 seconds.233168 found in 0.000038717000000005444 seconds.