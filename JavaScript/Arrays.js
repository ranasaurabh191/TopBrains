console.log("======Array Programs======");
console.log("1 Creating Arrays\n");

var colors = ["Red","Green","Yellow"];
var fruits = ["Apple","Banana","Mango"];
var cities = ["London","Paris","New York"];

console.log("colors:",colors);
console.log("fruits:",fruits);
console.log("cities:",cities);

console.log("First fruit:",fruits[0],"\n");

console.log("Length of cities:",fruits.length,"\n")

for(var fruit of fruits){
    console.log("Fruit:",fruit);
}

fruits.splice(1, 0 ,"Litchi"); //start, deleteCount, item1,2,3

console.log(fruits.slice(0,2)); // start,end(not included)

console.log(fruits);

//adding and removing at last/end
let nums = [10, 20, 30];
nums.push(40);//add
console.log("After push:", nums);
nums.pop();//remove
console.log("After pop:", nums);

//adding and removing from first/start
let color = ["Red", "Green"];
color.unshift("Blue");//add
console.log("After unshift:", color);
color.shift();//remove
console.log("After shift:", color);

console.log("Index of Mango:", fruits.indexOf("Mango"));
console.log("Has Banana?", fruits.includes("Banana"));

console.log(cities.join(", "));

nums.reverse();
console.log(nums);

color.reverse();
console.log(color);


// let marks = [45, 10, 78, 22];

// marks.sort((a, b) => a - b);//asc
// console.log("Ascending:", marks);

// marks.sort((a, b) => b - a);//desc
// console.log("Descending:", marks);

fruits.forEach((fruit, index) => {
    console.log(index, fruit);
});

let prices = [100, 200, 300];
let discounted = prices.map(p => p - 20);
console.log(discounted);

let ages = [12, 18, 25, 10, 30];
let adults = ages.filter(age => age >= 18);
console.log(adults);

let cart = [123,42134,1341];
let total = cart.reduce((sum, price) => sum + price,0);
console.log("Total:", total);

let a = [1, 2];
let b = [3, 4];
let merged = [...a,... b];
console.log(merged);


let matrix = [
  [1, 2, 3],
  [4, 5, 6],
  [7, 8, 9]
];

console.log(matrix[1][0]); // 4
console.log(matrix[0][0]); // 1
console.log(matrix[1][2]); // 6
console.log(matrix[2][1]); // 8

for (let i = 0; i < matrix.length; i++) {      // rows
    for (let j = 0; j < matrix[i].length; j++) { // columns
        console.log(matrix[i][j]);
    }
}


for (let i = 0; i < matrix.length; i++) {
    console.log("Row", i, ":", matrix[i]);
}

for (let row of matrix) {
    for (let value of row) {
        console.log(value);
    }
}

for (let i = 0; i < matrix.length; i++) {
    let rowSum = 0;
    for (let j = 0; j < matrix[i].length; j++) {
        rowSum += matrix[i][j];
    }
    console.log("Sum of row", i, ":", rowSum);
}

for (let col = 0; col < matrix[0].length; col++) {
    let colSum = 0;
    for (let row = 0; row < matrix.length; row++) {
        colSum += matrix[row][col];
    }
    console.log("Sum of column", col, ":", colSum);
}

for (let i = 0; i < matrix.length; i++) {
    console.log(matrix[i][i]);
}



let marks = [
  ["Rahul", 80, 70, 90],
  ["Amit", 60, 75, 85],
  ["Neha", 90, 95, 88]
];

for (let student of marks) {
    let name = student[0];
    let total = 0;

    for (let i = 1; i < student.length; i++) {
        total += student[i];
    }
    console.log(name, "Total:", total);
}


console.log(matrix.flat());


let jagged = [
  [1, 2, 3],
  [4, 5],
  [6, 7, 8, 9]
];
for (let i = 0; i < jagged.length; i++) {
    for (let j = 0; j < jagged[i].length; j++) {
        console.log(jagged[i][j]);
    }
}


let matrix1 = [
  [1, 2, 3],
  [4, 5, 6]
];
let transpose = [];
for (let i = 0; i < matrix1[0].length; i++) {
    transpose[i] = [];
    for (let j = 0; j < matrix1.length; j++) {
        transpose[i][j] = matrix1[j][i];
    }
}
console.log(transpose);


let pattern = "";
for (let i = 0; i < 4; i++) {
    for (let j = 0; j <= i; j++) {
        pattern += "* ";
    }
    pattern += "\n";
}

console.log(pattern);


let students = [
  { name: "Rahul", marks: [80, 70, 90] },
  { name: "Amit", marks: [60, 75, 85] },
  { name: "Neha", marks: [90, 95, 88] }
];
students.forEach(student => {
    let total = student.marks.reduce((a, b) => a + b, 0);
    console.log(student.name, "Total:", total);
});

// Filter Students Who Passed
let passed = students.filter(student => {
    let total = student.marks.reduce((a, b) => a + b, 0);
    return total >= 200;
});
console.log(passed);

// Sort Students by Total Marks
students.sort((a, b) => {
    let totalA = a.marks.reduce((x, y) => x + y, 0);
    let totalB = b.marks.reduce((x, y) => x + y, 0);
    return totalB - totalA;
});
console.log(students);