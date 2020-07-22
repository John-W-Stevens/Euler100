const now = require("performance-now")
const lineReader = require("line-reader");

const compareChildrenAndAddLargestChild = (triangle, i, j) => {
    if (triangle[i+1][j] > triangle[i+1][j+1]){
        add_left_child(triangle,i,j)
    }
    else {
        add_right_child(triangle,i,j)
    }
}

const add_left_child = (triangle, i, j) => triangle[i][j] += triangle[i+1][j]
const add_right_child = (triangle, i, j) => triangle[i][j] += triangle[i+1][j+1]

const problem18 = () => {
    const start = now();
    const triangle = []

    lineReader.eachLine("problem_18.txt", function(line,last){
        triangle.push(line.split(" ").map(e => parseInt(e)));
        if(last){
            for (var i = triangle.length - 2; i >= 0; i--){
                for (var j = 0; j <= i+1; j++){
                    compareChildrenAndAddLargestChild(triangle,i,j)
                }
            }
            const solution = triangle[0][0]
            console.log(`${solution} found in ${(now() - start) / 1000} seconds.`);
        }
    })
}
problem18();
// 1074 found in 0.004795382999999994 seconds.