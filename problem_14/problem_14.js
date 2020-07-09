const now = require("performance-now");

const checkChainLength = n => {
    var length;
    if (n === 1){
        return 1;
    }
    if (chainTable[n]){
        return chainTable[n]
    }
    if (n % 2 === 0){
        length = checkChainLength( Math.floor(n / 2) ) + 1
    }
    else {
        length = checkChainLength( Math.floor( (3*n + 1) / 2 )) + 2
    }
    if ( n < 1000000){
        chainTable[n] = length
    }
    return length
}

const problem14 = () => {
    var longestChain = 1;
    var number = 1;
    var chainLength;
    for (var n = 500000; n < 1000000; n++){
        chainLength = checkChainLength(n);
        if (chainLength > longestChain){
            longestChain = chainLength;
            number = n;
        }
    }
    return number;
}

let start = now();
const chainTable = {};
let solution = problem14()
console.log(`${solution} found in ${(now()-start) / 1000} seconds.`)
// 837799 found in 0.214156243 seconds.