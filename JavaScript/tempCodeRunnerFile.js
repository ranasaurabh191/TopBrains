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