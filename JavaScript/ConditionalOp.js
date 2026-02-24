
const rl = require("readline").createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Enter first number: ", (a) => {
    rl.question("Enter second number: ", (b) => {
        rl.question("Enter third number: ", (c) => {
            a = Number(a);
            b = Number(b);
            c = Number(c);

            let max = (a > b) ? (a > c ? a : c) : (b > c ? b : c);
            console.log("Greatest number:", max);

            rl.close();
        });
    });
});