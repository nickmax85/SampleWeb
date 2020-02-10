//let storage = sessionStorage;
let storage = localStorage;
if (storage == undefined)
    alert('Storage not supported');

function calculate() {
    var liter = parseFloat(document.getElementById('liter').value);
    var kilometer = parseFloat(document.getElementById('kilometer').value);

    if (isNaN(liter) || isNaN(kilometer)) {
        //alert('Please enter valid numbers');
        document.getElementById('errorMessage').innerHTML = 'Oida, a nummer!';
        $('#myModal').modal();
        return;
    }


    var result = liter / kilometer * 100;

    let data = { liter: liter, kilometer: kilometer };
    saveData(data);

    document.getElementById('result').value = result.toFixed(2);
    document.getElementById('resultSpan1').innerHTML = '<strong>' + result.toFixed(2) + '</strong>';
    document.getElementById('resultSpan2').innerText = '<strong>' + result.toFixed(2) + '</strong>';
}

function saveData(data) {
    //storage.liter = liter;
    //storage['kilometer'] = kilometer;
    debugger;
    alert(data);

}

function loadData() {

    if (storage.liter != undefined || storage.kilometer != undefined) {
        document.getElementById('liter').value = storage.liter;
        document.getElementById('kilometer').value = storage.kilometer;

    }

}
