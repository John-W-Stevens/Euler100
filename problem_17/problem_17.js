const now = require("performance-now");

const problem17 = () => {

    const sum = arr => arr.reduce((a,b)=>(a+b));

    const ones = [
        "one","two","three",
        "four","five","six",
        "seven","eight","nine"
    ].map(e => e.length);
    
    const teens = [
        "eleven","twelve","thirteen",
        "fourteen","fifteen","sixteen",
        "seventeen","eighteen","nineteen"
    ].map(e => e.length);
    
    const tens = [
        "ten","twenty","thirty",
        "forty","fifty","sixty",
        "seventy","eighty","ninety"
    ].map(e => e.length);
    
    const hundreds = [
        "onehundred","twohundred","threehundred",
        "fourhundred","fivehundred","sixhundred",
        "sevenhundred","eighthundred","ninehundred"
    ].map(e => e.length);
    
    let letters = 0;
    
    letters += sum(ones) + sum(teens) + sum(tens) + sum(hundreds)

    for (const ten of tens.slice(1,)){
        for (const one of ones){
            letters += ten + one;
        }
    }
    for (const hundred of hundreds){
        for (const one of ones){
            letters += hundred + 3 + one;
        }
        letters += hundred + 3 + tens[0];
        for (const teen of teens){
            letters += hundred + 3 + teen
        }
        for (const ten of tens.slice(1,)){
            letters += hundred + 3 + ten
            for (const one of ones){
                letters += hundred + 3 + ten + one;
            }
        }
    }
    letters += 11; // onethousand
    return letters;
}

let start = now()
let solution = problem17()
console.log(`${solution} found in ${(now()-start) / 1000} seconds.`)
// 21124 found in 0.0003209489999999953 seconds.