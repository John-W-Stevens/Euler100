const now = require("performance-now");
const { primeSieve } = require("./prime_sieve")

const problem_10 = () => primeSieve(2000000).reduce((a,b)=>a+b);

let start = now();
let solution = problem_10()
console.log(`${solution} found in ${(now() - start) / 1000} seconds.`)
// 142913828922 found in 0.22473554800000003 seconds.