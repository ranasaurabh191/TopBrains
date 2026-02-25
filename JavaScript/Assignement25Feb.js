// Scenario 1: Simple Calculator
var a = 10;
var b = 20;

const addition = (a,b)=> a+b;
const subtraction = (a,b)=> a-b;
const multiplication = (a,b)=> a*b;
const division = (a,b)=> a/b;

console.log("Addition:",addition(a,b));
console.log("Subtraction:", subtraction(a,b));
console.log("Subtraction:",multiplication(a,b));
console.log("Division:",division(a,b));

// Scenario 2: Square and Cube
const square = x => x*x;
console.log("Square:",square(12));

const cube = x => x*x*x;
console.log("Cube:",cube(2));

// Scenario 3: Student Marks Evaluation
let marks = [45,78,54,64,73];
let updatedMarks = marks.map(x=>x+5);
console.log("Grace Marks:",updatedMarks);
let Above60 = marks.filter(x=>x>60);
console.log("Above 60:",Above60);
let totalMarks = marks.reduce((a,b)=>a+b);
console.log("Total:",totalMarks);

// Scenario 4: Employee Salary Increment
let employees = [
    { name: "Ravi", salary: 30000 },
    { name: "Priya", salary: 40000 },
    { name: "Amit", salary: 35000 }
];

const updatedEmployees = employees.map(emp => ({
    name: emp.name,
    salary: emp.salary + emp.salary * 0.10
}));
console.log(updatedEmployees);

const employeeNames = employees.map(emp => emp.name);
console.log(employeeNames);

const highSalaryEmployees = employees.filter(emp => emp.salary > 35000);
console.log(highSalaryEmployees);

// Scenario 5: Online Shopping Cart
let cart = [
    { product: "Laptop", price: 50000, qty: 1 },
    { product: "Mouse", price: 500, qty: 2 },
    { product: "Keyboard", price: 1500, qty: 1 }
];

const totalbill = cart.reduce((total,item)=>total+item.price*item.qty,0);
console.log("Total Bill:",totalbill);

const prodNames = cart.map(prod=>prod.product);
console.log("Products:",prodNames);

const updatedPrice = cart.map(item=>({
    ...item,
    price: item.price + item.price*0.05
}));

console.log("Updated Cart:",updatedPrice);

// Scenario 6: Find Topper Student

let students = [
    { name: "Ravi", marks: 88 },
    { name: "Priya", marks: 95 },
    { name: "Amit", marks: 78 }
];

const highest = students.reduce(
    (max, student)=> student.marks > max? student.marks:max, 0
);

console.log("Highest Marks:", highest);

const topper = students.reduce(
    (top, student) => student.marks > top.marks ? student : top
);
console.log("Topper:", topper.name);
const upperCaseNames = students.map(student => student.name.toUpperCase());
console.log("Uppercase Names:", upperCaseNames);

// Scenario 7: User Search (Case Insensitive)
let users = ["Ravi", "Priya", "Amit", "Rahul"];
const searchUser = (arr, searchName) => arr.some(user => user.toLowerCase() === searchName.toLowerCase());
let result = searchUser(users, "ravi");

if (result) {
    console.log("Found");
} else {
    console.log("Not Found");
}

// Scenario 8: Custom Sorting

let numbers = [45, 12, 89, 32, 67];
const asc = [...numbers].sort((a, b) => a - b);
console.log("Ascending:", asc);