// 1
let sumSalaries = (salaries) => {
    
    let sum = Object.values(salaries).reduce(
        (prev, curr) => prev + curr,
        0
    );
    console.log("Sum salaries. Sum is: ", sum);
    return sum;
}
// 2
let multiplyNumeric = (obj) => {
    console.log("Multiply Numeric");
    console.log("Original object is : " + JSON.stringify(obj));
    Object.keys(obj).map(key => {
        if (!Number.isNaN(Number.parseFloat(obj[key]))) {
            obj[key] = obj[key] * 2
        }
    });
    console.log("Modified object is: " + JSON.stringify(obj));
}
// 3
let checkEmailId = (email) => {
    
    const regex = new RegExp(/.+@.+\./);
    let result = regex.test(email);
    console.log("Check email ID. Email is valid? :" + result);
    return result;
}
// 4
let truncate = (str, maxLength) => {
    // check length of string, truncate and put ...
    let answer = "";
    if (str.length <= maxLength) {
        answer = str;
    } else {
        answer = str.substring(0,maxLength) + "...";
    }
    console.log("Truncate str: ", str, "to max length: ", maxLength, ". Result is: ", answer);
    return answer;
}
// 5 - array operations
let arrayOperations = () => {
    console.log("Array Operations");
    let styles = ["James", "Brennie"];
    console.log("Styles array starts as: ", styles);
    styles.push("Robert");
    console.log("After pushing robert, styles array is: ", styles);
    styles[Math.floor(styles.length/2)] = "Calvin";
    console.log("After modifying the middle value, styles array is: ", styles);
    
    let firstValue = styles.shift();
    console.log("First value of the array is: ", firstValue);
    console.log("After removing the first value, styles array is: ", styles);

    styles.unshift("Rose", "Regal");
    console.log("After prepending Rose and Regal, styles array is: ", styles);
}

let salaries = {
    John: 100,
    Ann: 160,
    Pete: 130
};
sumSalaries(salaries);

let menu = {
    width: 200,
    height: 300,
    title: "My menu"
};
multiplyNumeric(menu);

checkEmailId("t@.c");

truncate("Hello, world!", 50);

arrayOperations();
