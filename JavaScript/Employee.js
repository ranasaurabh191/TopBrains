
const rl = require("readline").createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Enter employee number: ", (eno) => {
    rl.question("Enter employee name: ", (ename) => {
        rl.question("Enter basic salary: ", (basic) => {

            basic = Number(basic);

            let pf = basic * 0.12;
            let hra = basic * 0.20;
            let da = basic * 0.15;

            let gross = basic + pf + hra + da;
            let net = gross - pf;

            console.log("Employee No:", eno);
            console.log("Employee Name:", ename);
            console.log("Basic Salary:", basic);
            console.log("Gross Salary:", gross);
            console.log("Net Salary:", net);

            rl.close();
        });
    });
});