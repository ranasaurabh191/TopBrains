const r1 = require("readline").createInterface({
    input:process.stdin,
    output:process.stdout
});

r1.question("Enter first number: ",(num1)=>{
    r1.question("Enter second number: ",(num2)=>{
        a = Number(num1);
        b = Number(num2);
        console.log();
        console.log("Addition:", a+b);
        console.log("Subtraction:", a-b);
        console.log("Product:", a*b);
        console.log("Division:", a/b);
        console.log("Modulus:", a%b);
        r1.close();
    });
});