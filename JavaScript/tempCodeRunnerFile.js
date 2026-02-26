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
