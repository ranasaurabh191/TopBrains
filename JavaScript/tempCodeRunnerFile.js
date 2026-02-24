let student = {
  name: "Ravi",
  math: 80,
  science: 75,
  english: 90
};

for (let key in student) {
//   if (key !== "name") {
    console.log(`${key}: ${student[key]}`);
//   }
}