var r1 = require("readline").createInterface({
    input:process.stdin,
    output:process.stdout
});

r1.question("Enter floating point number: ", (num)=> {
    console.log("Enterd FP number is", parseFloat(num));
    r1.close();
});