// SCENARIO: Smart Employee Management System (ES6 Version)
// Scenario 1: Block Scope Variables
const companyName = "Tech Solutions";
let employeeCount=4;
employeeCount++;

console.log(`Company: ${companyName}`);
console.log(`Total Employees: ${employeeCount}`);

// Scenario 2: Arrow Function Calculator

var addSalaryBonus = x => x+5000;
const calculateTax = x=>salary*0.1;

var salary = 100000;

var updatedSalary = addSalaryBonus(salary);
var tax = calculateTax(salary);
console.log(`Salary: ${updatedSalary}`);
console.log(`Tax: ${tax}`);

// var addSalaryBonus = x => x+5000;

let employees = [
    { id: 1, name: "Ravi", salary: 40000 },
    { id: 2, name: "Priya", salary: 55000 },
    { id: 3, name: "Amit", salary: 30000 }
];
//map
var updatedSalary = employees.map(item=>({
    id : item.id,
    name : item.name,
    salary : item.salary + item.salary * 0.10
}));
console.log(updatedSalary);
//filter
var updatedEmployee = employees.filter(emp=> emp.salary>40000);
console.log(updatedEmployee)
// reeduce

var totalSalary = employees.reduce((total,emp)=>total+emp.salary,0);
console.log(`Total Salary: ${totalSalary}`)


// Scenario 4: Destructuring
let employee = { id: 101, name: "Ravi", department: "IT", salary: 50000 };
const { name, salary } = employee;

console.log(`Employee Name: ${name}`);
console.log(`Salary: ${salary}`);

// Scenario 5: Spread Operator
let employees = [
    { id: 1, name: "Ravi", salary: 40000 },
    { id: 2, name: "Priya", salary: 55000 },
    { id: 3, name: "Amit", salary: 30000 }
];
const newEmployees = [...employees];

const updatedEmployees = [
    ...newEmployees,
    { id: 4, name: "Rahul", salary: 45000 }
];

console.log(updatedEmployees);

// Scenario 6: Create Employee Class
class Employee{
    constructor(id,name,salary){
        this.id=id;
        this.name=name;
        this.salary=salary;
    }
    display(){
        console.log(`ID: ${this.id}, Name: ${this.name}, Salary: ${this.salary}`);
    }
    getAnnualSalary(){
        return this.salary * 12;
    }
}
const emp1 = new Employee(1,"Ravi",30000);
const emp2 = new Employee(2,"Dev",43000);
emp1.display();
console.log("Annual Salary:", emp1.getAnnualSalary());

emp2.display();
console.log("Annual Salary:", emp2.getAnnualSalary());

// Scenario 7: Highest Paid Employee
const highestPaid = employee.reduce((max,emp)=>emp.salary>max.salary? emp : max);
console.log(`Highest Paid Employee: ${highestPaid.name} (${highestPaid.salary})`);

// Scenario 8: Default Parameters

function createEmployee(name = "Unknown", salary = 30000) {
    return { name, salary };
}

console.log(createEmployee());
console.log(createEmployee("Ravi", 60000));

// Scenario 9: Department Wise Grouping + Salary Total
let employeesDept = [
    { name: "Ravi", dept: "IT", salary: 50000 },
    { name: "Priya", dept: "HR", salary: 40000 },
    { name: "Amit", dept: "IT", salary: 60000 }
];

const departmentSummary = employeesDept.reduce((acc, emp) => {
    if (!acc[emp.dept]) {
        acc[emp.dept] = { employees: [], totalSalary: 0 };
    }

    acc[emp.dept].employees.push(emp.name);
    acc[emp.dept].totalSalary += emp.salary;

    return acc;
}, {});

console.log(departmentSummary);