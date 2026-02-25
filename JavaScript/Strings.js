console.log("Creating string")
var str1='hello world'
var str2="hello world"
console.log("Single Quotes: "+str1)
console.log("Double Quotes: "+str2)

// string in JavaScript
var str1="its 'okk...'"
var str2='She replied "calm" down please'
console.log(str1)
console.log(str2)


// Escaping Quotes
console.log("Escaping Quotes")
var str4='it\'s okay'
var str5="He said \"GoodByee\""
var str6='she replied \'Calm down, Please\''
console.log(str4)
console.log(str5)
console.log(str6)

// escape sequence
console.log("Escape sequence")
var escap1="The quick brown fox \n jumps over the lazy dog."
console.log(escap1)
var escap2="hello\t world"
console.log(escap2)
var escap3="c:\\users\\Downloads"
console.log(escap3)

// length in string
console.log("Length of string")
var str="This is a paragraph of text"
console.log("Length: "+str.length)

// indexof and lastindexof
console.log("Finding substring")
var str="if the facts dont't fit the theory, change the facts"
var pos1=str.indexOf("facts")
console.log("First Occurence: "+pos1)
var pos1=str.lastIndexOf("facts")
console.log("Last Occurence: "+pos1)

// slice method
console.log("Slice method")
var str="if the facts dont't fit the theory, change the facts"
var str1=str.slice(4,15)
console.log("Slice(4,15): "+str1)


// substring menthod
console.log("Substring method")
console.log(str.substring(4,15))