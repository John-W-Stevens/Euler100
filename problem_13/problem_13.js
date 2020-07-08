const now = require("performance-now")
const lineReader = require("line-reader");

const add = (n1, n2) => {
    if (n1.length < n2.length){
        [n1, n2] = [n2, n1];
    }
    let header = new Array( Math.max(0, n1.length - n2.length)).fill("0");    
    n1 = n1.split("");
    n2 = header.concat(n2.split(""))
    let output = new Array(n1.length+1).fill(0);
    let carryOver = 0;

    for (var i = n1.length-1; i >= 0; i--){
        let s = parseInt(n1[i]) + parseInt(n2[i]) + carryOver;
        carryOver = 0;
        if (s > 9){
            s = s.toString();
            carryOver = parseInt(s[0]);
            output[i+1] = s[1];
        }
        else {
            output[i+1] = s.toString();
        }
    }
    if (carryOver !== 0){
        output[0] = carryOver.toString();
    }
    let j = 0;
    while (output[j] === 0){
        j += 1;
    }
    output = output.slice(j,);
    return output.join("")
}

const problem13 = () => {
    const start = now();
    const numbers = []

    lineReader.eachLine("problem_13.txt", function(line,last){
        numbers.push(line);
        if(last){
            const solution = numbers.reduce( (a,b)=>add(a,b)).slice(0, 10);
            console.log(`${solution} found in ${(now() - start) / 1000} seconds.`);
        }
    })
}
problem13();
// 5537376230 found in 0.017385314000000002 seconds.
