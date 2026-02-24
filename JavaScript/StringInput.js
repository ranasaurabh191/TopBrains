var r1 = require("readline").createInterface({
    input:process.stdin,
    output:process.stdout
});

r1.question("Enter string input: ",(str)=>{
    console.log("Entered string is",str);
    r1.close();
})