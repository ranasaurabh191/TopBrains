var r1 = require("readline").createInterface({
    input:process.stdin,
    output:process.stdout
});

r1.question("Enter number to check: ",(num)=>{
    if(num>0) console.log("Number is positive.");
    else if(num<0) console.log("Number is negative");
    else console.log("NUmber is Zero.");
    r1.close();
});