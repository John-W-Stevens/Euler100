// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
// What is the 10 001st prime number?

const now = require("performance-now");
const { primeSieve } = require("./prime_sieve")

const problem_7 = (n, limit) => primeSieve(limit)[n];

let start = now();
let solution = problem_7(10001, 150000)
console.log(`${solution} primes found in ${(now() - start) / 1000} seconds.`)
// 104759 primes found in 0.027530324999999998 seconds.