const now = require("performance-now");

const problem8 = () => {
    const limit = parseInt(Math.sqrt(500)) + 1;
    for (var m = 1; m <= limit; m++){
        for (var n = 1; n < m; n++){
            if (parseInt(m**2 + m * n) === 500){
                return (m**2 - n**2) * 2*m*n * (m**2 + n**2)
            }
        }
    }
}

let start = now();
let solution = problem8();
console.log(`${solution} found in ${(now() - start) / 1000} seconds.`)
// 31875000 found in 0.000053920000000005074 seconds.