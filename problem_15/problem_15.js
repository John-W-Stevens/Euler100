const now = require("performance-now");

const problem15 = (m, n, memo={}) => {
    if (m === 1 || n === 1) { return 1 }
    const key = `${m},${n}`;
    if (memo.hasOwnProperty(key)){
        return memo[key];
    }
    else {
        let result = problem15(m-1, n, memo) + problem15(m, n-1, memo);
        memo[key] = result;
        return result;
    }   
}

let start = now()
let solution = problem15(21,21)
console.log(`${solution} found in ${(now()-start) / 1000} seconds.`)
// 137846528820 found in 0.000742721000000003 seconds.