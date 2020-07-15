const now = require("performance-now");

const multiplyBy2 = n => {
    n = [0].concat(n.split("").map(e => parseInt(e)))
    let carryOver = 0
    let output = new Array(n.length).fill(0)
    
    for (var i = n.length-1; i>= 0; i--){
        let product = n[i] * 2 + carryOver
        carryOver = 0
        if (product > 9){ // it has 2 digits
            product = product.toString()
            carryOver = parseInt(product[0])
            output[i] = parseInt(product[1])
        }
        else {
            output[i] = product
        }
    }
    if (carryOver !== 0){
        output[0] = carryOver;
    }
    let j = 0
    while (output[j] === 0){
        j += 1
    }
    return output.slice(j,).map(e => e.toString()).join("")
}

const problem16 = () => {
    let number = "2";
    for (var i = 1; i < 1000; i++){
        number = multiplyBy2(number)
    }
    return number.split("").map(n => parseInt(n)).reduce( (a,b)=>a+b)    
}
let start = now()
let solution = problem16()
console.log(`${solution} found in ${(now()-start) / 1000} seconds.`)
// 1366 found in 0.05004892300000001 seconds.