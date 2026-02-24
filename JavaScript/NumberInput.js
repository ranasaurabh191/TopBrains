var r1 = require("readline").createInterface({
    input:process.stdin,
    output:process.stdout
});

r1.question("Enter number : ",function(num){
    console.log("Entered number is", Number(num));
    r1.close();
});