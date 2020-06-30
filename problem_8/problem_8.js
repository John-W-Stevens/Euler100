const now = require("performance-now")
fs = require("fs");

const problem8 = () => {
    fs.readFile("./problem_8.txt", "utf8", (err, data) => {
        if (err){ throw err; }
        const start = now();
        const number = [];
        for (const char of data){ 
            if (char !== "\n"){
                number.push(parseInt(char, 10))
            }
        }
        let max_product = 0;
        for (var i = 0; i < number.length - 13; i ++){
            let product = number.slice(i,i+13).reduce((a,b)=>a*b,1)
            if (product > max_product){ 
                max_product = product;
            }
        }
        console.log(`${max_product} found in ${(now() - start) / 1000} seconds.`);
    })
}

problem8()
// 23514624000 found in 0.0029508629999999984 seconds.