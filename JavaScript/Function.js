//=========Function in JavaScript=====
console.log("Defining and calling a function")
function sayHello(){
    console.log("Hello, Welcome to this Website")
}
sayHello()

// default Parameter
function greet(name="Abhi"){
    console.log("hello "+name);
}
greet()
greet("Rohan")

// returning value
function getSum(num1,num2){
    var total=num1+num2
    return total
}
console.log(getSum(20,40))
console.log(getSum(40,40))

// returning multiple value
function divideNumber(dividend,divisor){
    var quotient=dividend/divisor
    var arr=[dividend,divisor,quotient]
    return arr
}
var all=divideNumber(10,2)
console.log("Dividend: "+all[0])
console.log("Divisor: "+all[1])
console.log("Quotient: "+all[2])

// return multiple value using object
function getValue(){
    return{
        x:10,
        y:20
    };
}
let res=getValue()
console.log("x: "+res.x)
console.log("y: "+res.y)

// with output parameter
function modifyObject(obj){
    obj.a=100
    obj.b=200
};
let obres={};
modifyObject(obres)
console.log("A: "+obres.a)
console.log("B: "+obres.b)