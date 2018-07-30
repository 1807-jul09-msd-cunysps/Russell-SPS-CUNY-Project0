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
}
