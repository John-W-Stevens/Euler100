// # 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
// # What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

const now = require("performance-now");

const isPrime = n => {
    if (n <= 1){ return false; }
    if (n == 2 || n == 3){ return true; }
    if (n % 2 === 0 || n % 3 === 0){ return false; }

    let i = 5, w = 2;
    while (i * i <= n){
        if (n % i === 0){ return false; }
        i += w;
        w = 6 - w;
    }
    return true;
}

const primeFactorization = n => {
    // Assumes n >= 2
    // Returns a dict mapping the prime factors of n and their respective powers 
    if (isPrime(n)){ 
        let primeFactors = {}
        primeFactors[n] = 1;
        return primeFactors;
    }
    let primeFactors = { 2:0, 3:0 }
    while (n % 2 === 0){
        primeFactors[2] += 1;
        n /= 2;
    }
    while (n % 3 === 0){
        primeFactors[3] += 1;
        n /= 3;
    }
    for (var i = 5; i < parseInt(Math.sqrt(n) + 1, 10); i+= 2){
        if (!isPrime(i)){ continue }
        while (n % i === 0){
            if (!primeFactors[i]){ primeFactors[i] = 1; }
            else { primeFactors[i] += 1; }
            n /= i;
        }
    }
    return primeFactors;
}

const problem_5 = n => {
    //  Returns the smallest number divisible by every number <= n 
    let output = 1;
    let primeFactorMap = {};

    for (var i = 2; i < n + 1; i++){
        let primeFactors = primeFactorization(i);
        for (const [p,e] of Object.entries(primeFactors)){
            if (!primeFactorMap[p]){ primeFactorMap[p] = e; }
            else if (primeFactorMap[p] < e){ primeFactorMap[p] = e; }
        }
    }
    for (const [p,e] of Object.entries(primeFactorMap)){
        output *= parseInt(p, 10) ** e;
    }
    return output
}

let start = now();
let solution = problem_5(20)
console.log(`${solution} found in ${(now() - start) / 1000} seconds.`)
// 232792560 found in 0.00023718999999999824 seconds.