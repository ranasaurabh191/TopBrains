
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

            if (a > b && a > c) console.log(a + " is greatest");
            else if (b > c) console.log(b + " is greatest");
            else console.log(c + " is greatest");

            rl.close();
        });
    });
});