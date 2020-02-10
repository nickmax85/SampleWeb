testabc = 'Berndt';

if (1 == 1) {
}

debugger;


let employee = { salary: 2500, kids: 2 }; //new Object();
employee.firstName = 'Berndt';
employee["lastName"] = 'Hamböck';

console.table(employee);

let employee2 = {
    firstName: 'Bettina',
    lastName: 'Hamböck',
    salary: 2500,
    kids: 2,
    'for': 'Support',
    'is married': true
}; //new Object();

employee2.lastaNme = 'Kriebernegg';

console.table(employee2);

//get keys
for (var key in employee2) {
    console.log(key);
}
