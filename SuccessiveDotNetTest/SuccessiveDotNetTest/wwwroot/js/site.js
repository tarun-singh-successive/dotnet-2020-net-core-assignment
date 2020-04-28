// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $.getJSON("api/CandidateAPI/", function (d) {
        //document.getElementById("getIdforLoginGeneration").value = id;
        console.log(d);
        $("<option disabled selected>Select Candidate</option>").appendTo("#selectCandidate")
        for (i = 0; i < d.length; i++) {
            // if model city is same in all recieved cities it will not added again 
            //$("<option>" + d[i] + "</option>").appendTo(".getcity")
            var fname = d[i].firstName;
            var lname = d[i].lastName;
            var email = d[i].email;
            var result = fname + " " + lname + " (" + email + ")";
            $("<option value='" + d[i].id + "'>" + result + "</option>").appendTo("#selectCandidate")
        }
    });

});
function GetData(value) {
    var getIndex = document.getElementById("selectCandidate").selectedIndex;
    var id = document.getElementsByTagName("option")[getIndex].value;
    console.log(id);
    $.getJSON("api/CandidateAPI/" + id, function (d) {
        console.log("my data:" + d.dob);
        var getdatetime = d.dob;
        var newDob = "";
        for (i = 0; i < 10; i++) {
            newDob += getdatetime[i];
        }
        $("#firstName").val(d.firstName);
        $("#lastName").val(d.lastName);
        $("#dob").val(newDob);
        $("#exp").val(d.experience);
        $("#mobile").val(d.mobile);
        $("#email").val(d.email);

    });

}
function ClearAll() {
    var checkBox = document.getElementById("addNew");
    if (checkBox.checked == true) {

        $("#firstName").val("");
        $("#lastName").val("");
        $("#dob").val("");
        $("#exp").val("");
        $("#mobile").val("");
        $("#email").val("");
        document.getElementById("selectCandidate").disabled = true;
    }
    else {
        document.getElementById("selectCandidate").disabled = false;
    }

}

//Validations

function ValidateFirstName(value) {

        var regExp = /^[a-zA-Z]*$/;
        if (!regExp.test(value)) {
            value = '';
            $(".firstName").html("No Space and Special Character Allowed");

        }
        else {
            $(".firstName").html("");
        }
}
function ValidateLastName(value) {

    var regExp = /^[a-zA-Z]*$/;
    if (!regExp.test(value)) {
        value = '';
        $(".lastName").html("No Space and Special Character Allowed");

    }
    else {
        $(".lastName").html("");
    }
}