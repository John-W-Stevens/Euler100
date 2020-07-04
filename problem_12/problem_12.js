const now = require("performance-now");
const { primeSieve } = require("./prime_sieve");
const { primeFactorization } = require("./prime_factorization");

const problem12 = () => {
    const primes = primeSieve(100);
    let n = 1;
    while (1){
        const triangleNumber = n*(n+1) / 2;
        if (primeFactorization(triangleNumber, primes, numDivisors=true) > 500) { return triangleNumber;}
        n += 1;
    }
    return
}
let start = now();
let solution = problem12()
console.log(`${solution} found in ${(now()-start) / 1000} seconds.`)
// 76576500 found in 0.025367662000000003 seconds.