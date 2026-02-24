var r1 = require("readline").createInterface({
    output:process.stdout,
    input:process.stdin
});

r1.question("Enter the number to check: ",(num)=>{
    num = Number(num);
    if(num%2==0) console.log(num, "is even.");
    else console.log(num,"is odd.");
    r1.close();
})