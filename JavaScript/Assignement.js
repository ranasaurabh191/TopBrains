const readline = require("readline").createInterface({
  input: process.stdin,
  output: process.stdout
});

const correctPin = 1234;
let balance = 10000;

readline.question("Enter PIN: ", pin => {
  if (Number(pin) === correctPin) {
    readline.question("Enter withdrawal amount: ", amount => {
      amount = Number(amount);
      if (amount >= 0) {
        if (balance >= amount) {
          balance -= amount;
          console.log("Withdrawal successful");
          console.log("Remaining balance:", balance);
        } else {
          console.log("Insufficient balance");
        }
      }
      readline.close();
    });
  } else {
    console.log("Incorrect PIN");
    readline.close();
  }
});

// -----------------------

readline.question("Enter units consumed: ", units => {
  units = Number(units);
  let bill = 0;

  if (units <= 100) {
    bill = units * 5;
  } else if (units <= 200) {
    bill = units * 7;
  } else {
    bill = units * 10;
  }

  console.log("Total Bill: ₹", bill);
  readline.close();
});

// -----------------------------

console.log("1. Pizza - ₹200");
console.log("2. Burger - ₹150");
console.log("3. Pasta - ₹180");

readline.question("Select item number: ", choice => {
  switch (Number(choice)) {
    case 1:
      console.log("Pizza - ₹200");
      break;
    case 2:
      console.log("Burger - ₹150");
      break;
    case 3:
      console.log("Pasta - ₹180");
      break;
    default:
      console.log("Invalid choice");
  }
  readline.close();
});

// ----------------------------------
const number = 7;

readline.question("Guess the number: ", input => {
    if (Number(input) !== number) {
      console.log("Wrong guess, try again");
      guess();
    } else {
      console.log("Correct! 🎉");
      readline.close();
    }
  });

//   ----------------------------------------

const password = "admin123";
let attempts = 0;

function askPassword() {
  readline.question("Enter password: ", input => {
    attempts++;

    if (input === password) {
      console.log("Access Granted");
      readline.close();
    } else if (attempts < 3) {
      console.log("Wrong password, try again");
      askPassword();
    } else {
      console.log("Account locked");
      readline.close();
    }
  });
}

askPassword();

// ----------------------------------------

readline.question("Enter number: ", num => {
  num = Number(num);
  for (let i = 1; i <= 10; i++) {
    console.log(`${num} x ${i} = ${num * i}`);
  }
  readline.close();
});

// -----------------------------------------

let salaries = [25000, 30000, 40000, 28000];
let total = 0;

for (let salary of salaries) {
  console.log("Salary:", salary);
  total += salary;
}

console.log("Total Salary:", total);

// -------------------------------

let student = {
  name: "Ravi",
  math: 80,
  science: 75,
  english: 90
};

for (let key in student) {
  if (key !== "name") {
    console.log(`${key}: ${student[key]}`);
  }
}

// -----------------------------------------

let cart = [
  { item: "Laptop", price: 50000 },
  { item: "Mouse", price: 500 },
  { item: "Keyboard", price: 1500 }
];

let total1 = 0;

for (let product of cart) {
  console.log(product.item, "-", product.price);
  total1 += product.price;
}

let gst = total1 * 0.18;
console.log("Total:", total1);
console.log("GST (18%):", gst);
console.log("Final Amount:", total1 + gst);

// ---------------------------------------------

readline.question("Enter age: ", age => {
  readline.question("Are you a citizen? (yes/no): ", citizen => {
    if (Number(age) >= 18) {
      if (citizen.toLowerCase() === "yes") {
        console.log("Eligible to vote");
      } else {
        console.log("Not eligible (citizenship required)");
      }
    } else {
      console.log("Not eligible (age below 18)");
    }
    readline.close();
  });
});

// --------------------------------------------------

let marks = [95, 82, 74, 60, 88];

for (let i = 0; i < marks.length; i++) {
  let m = marks[i];

  switch (true) {
    case m >= 90:
      console.log(`Student ${i + 1}: Grade A`);
      break;
    case m >= 80:
      console.log(`Student ${i + 1}: Grade B`);
      break;
    case m >= 70:
      console.log(`Student ${i + 1}: Grade C`);
      break;
    default:
      console.log(`Student ${i + 1}: Fail`);
  }
}

// -------------------------------------------------


let balance1 = 5000;

function menu() {
  console.log("\n1. Deposit");
  console.log("2. Withdraw");
  console.log("3. Check Balance");
  console.log("4. Exit");

  readline.question("Choose option: ", choice => {
    switch (Number(choice)) {
      case 1:
        readline.question("Enter amount: ", amt => {
          balance1 += Number(amt);
          console.log("Deposited successfully");
          menu();
        });
        break;

      case 2:
        readline.question("Enter amount: ", amt => {
          if (balance1 >= amt) {
            balance1 -= Number(amt);
            console.log("Withdrawal successful");
          } else {
            console.log("Insufficient balance");
          }
          menu();
        });
        break;

      case 3:
        console.log("Balance:", balance1);
        menu();
        break;

      case 4:
        console.log("Thank you!");
        readline.close();
        break;

      default:
        console.log("Invalid choice");
        menu();
    }
  });
}

menu();

// ------------------------------------------

let books = [
  { id: 1, name: "JS Basics", available: true },
  { id: 2, name: "Node Guide", available: false }
];


function menu1() {
  console.log("\n1. Display Books");
  console.log("2. Issue Book");
  console.log("3. Return Book");
  console.log("4. Exit");

  readline.question("Choose: ", choice => {
    switch (Number(choice)) {
      case 1:
        for (let book of books) {
          console.log(book);
        }
        menu1();
        break;

      case 2:
        readline.question("Enter book id: ", id => {
          for (let book of books) {
            if (book.id == id && book.available) {
              book.available = false;
              console.log("Book issued");
            }
          }
          menu1();
        });
        break;

      case 3:
        readline.question("Enter book id: ", id => {
          for (let book of books) {
            if (book.id == id) {
              book.available = true;
              console.log("Book returned");
            }
          }
          menu1();
        });
        break;

      case 4:
        readline.close();
        break;
    }
  });
}

menu1();