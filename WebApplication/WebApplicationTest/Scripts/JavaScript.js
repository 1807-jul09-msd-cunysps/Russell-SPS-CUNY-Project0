/*function nameCheck()
{
    var firstName = document.querySelector("#first_name").value;
    var lastName = document.querySelector("#last_name").value;
    if (firstName === lastName)
    {
        alert("Can't have same first and last name");

   }
}
function ageChecker()
{
    var age = document.querySelector("#age").value;
    if (age < 15 || age > 100)
    {
        alert("Age must be in between 15 and 100!");
    }
}

function addressCheck()
{
    var check = document.querySelector("#checkAddress").value;          
    if (check == 0) {
        var address2 = document.querySelector("#address2");
        var treeEl = document.createElement("treeEl");
        treeEl.innerText = "Permanent Address: ";
        var add1 = document.createElement("input");
        add1.setAttribute("type", "text");
        address2.appendChild(treeEl);
        address2.appendChild(add1);
    }
}*/
function locationPopulate(json) {
    // var json = { "zip_code": "10017", "lat": 0.711263, "lng": -1.29106, "city": "New York", "state": "NY", "timezone": { "timezone_identifier": "America\/New_York", "timezone_abbr": "EDT", "utc_offset_sec": -14400, "is_dst": "T" }, "acceptable_city_names": [{ "city": "Grand Central", "state": "NY" }, { "city": "Manhattan", "state": "NY" }, { "city": "Nyc", "state": "NY" }] };
    json = JSON.parse(json);
    var state = document.getElementById("State");
    var city = document.getElementById("City");
    state.value = json.state;
    city.value = json.city;
}

function checkZipcode() {
    var zipcode = document.getElementById("zipcode").value;
    var clientKey = 'js-fgDyrGxYtmf9BdVUpdShouyb6iBNoDneAaojCK6YKnkmNDTGOe46AG9QaKKZ0ca7';
    var url = "https://www.zipcodeapi.com/rest/" + clientKey + "/info.json/" + zipcode + "/radians";
    //1. create XHR object
    var xhr = new XMLHttpRequest();
    xhr.open('GET', url);
    xhr.onreadystatechange = function (e) {    //Call a function when the state changes.
        if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
            var result = xhr.responseText;
            if (result !== null || result !== "" || result !== undefined) {
                if (result.charAt(0) === '"' && result.charAt(result.length - 1) === '"') {
                    result = result.substr(1, result.length - 2);
                }
                locationPopulate(result);
            }
        }
    };
    xhr.send();
}




