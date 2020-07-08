const now = require("performance-now")
const lineReader = require("line-reader");

const problem11 = () => {
    const start = now();
    const grid = []

    lineReader.eachLine("problem_11.txt", function(line,last){
        const row = line.split(" ");
        for (var i = 0; i < row.length; i++){ row[i] = parseInt(row[i]) }
        grid.push(row);

        if(last){
            max_product = 0;

            for (const row of grid){  // horizontal
                for (var i = 0; i < 17; i++){
                    product = row[i] * row[i+1] * row[i+2] * row[i+3];
                    product > max_product ? max_product = product: max_product;
                }
            }
            for (var i = 0; i < 17; i++){  // vertical
                for (var j = 0; j < 20; j++){
                    product = grid[i][j] * grid[i+1][j] * grid[i+2][j] * grid[i+3][j];
                    product > max_product ? max_product = product: max_product;
                }
            }
            for (var i = 0; i < 17; i++){  // diagonal right
                for (var j = 0; j < 17; j++){
                    product = grid[i][j] * grid[i+1][j+1] * grid[i+2][j+2] * grid[i+3][j+3];
                    product > max_product ? max_product = product: max_product;
                }
            }
            for (var i = 0; i < 17; i++){  // diagonal left
                for (var j = 0; j < 17; j++){
                    product = grid[i+3][j] * grid[i+2][j+1] * grid[i+1][j+2] * grid[i][j+3];
                    product > max_product ? max_product = product: max_product;
                }
            }
            console.log(`${max_product} found in ${(now() - start) / 1000} seconds.`);
        }
    })
}
problem11();
// 70600674 found in 0.006128407000000003 seconds.
