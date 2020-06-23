

const now = require("performance-now")

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

const problem3 = n => {
    let lpf = 0; // largest prime factor
    var lower;
    var step;
    if (n % 2 != 0){ // if n is odd then we don't need to look at even numbers
        lower = 3;
        step = 2;
    }
    else { // if n is even then we need to look at odd & even numbers
        lower = 2;
        step = 1;
    }
    for (var num = lower; num < parseInt(n**0.5 + 1, 10); num += step){
        if (n % num === 0){
            if (isPrime(n / num)){  // the first value that satisfies this condition is the answer
                return n / num;
            }
            if (isPrime(num)){
                lpf = num;
            }
            n /= num; // reduce the size of the problem at each step
        }
    }
    return lpf;
}

let start = now();
let solution = problem3(600851475143)
console.log(`${solution} found in ${(now() - start) / 1000} seconds.`)
// 6857 found in 0.00020845400000000326 seconds.
