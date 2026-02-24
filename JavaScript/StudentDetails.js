
const rl = require("readline").createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Enter roll number: ", (roll) => {
    rl.question("Enter name: ", (name) => {
        rl.question("Enter marks 1: ", (m1) => {
            rl.question("Enter marks 2: ", (m2) => {
                rl.question("Enter marks 3: ", (m3) => {

                    m1 = Number(m1);
                    m2 = Number(m2);
                    m3 = Number(m3);

                    let total = m1 + m2 + m3;
                    let avg = total / 3;

                    console.log("Roll No:", roll);
                    console.log("Name:", name);
                    console.log("Total:", total);
                    console.log("Average:", avg);

                    if (avg >= 60) console.log("Division: First");
                    else if (avg >= 50) console.log("Division: Second");
                    else if (avg >= 40) console.log("Division: Third");
                    else console.log("Result: Fail");

                    rl.close();
                });
            });
        });
    });
});