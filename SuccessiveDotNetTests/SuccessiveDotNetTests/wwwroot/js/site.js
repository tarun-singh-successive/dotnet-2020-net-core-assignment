// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("document").ready(function () {                           //for getting the firstname lastname and email together in the dropdown 

    $("#candidates").on('click', function () {              

        $.ajax({
            type: 'GET',
            url: " https://localhost:44359/InterviewSchedules/GetAll",


            success: function (result) {

                var s;
                for (var i = 0; i < result.length; i++) {
                    s += '<option  >' + result[i].name + " " + result[i].last + "(" + result[i].email + ")" + '</option>';

                }
                $('#candidates').html(s);
            }

        });

    });


});

function Check() {                                     // for checking the checkbox for new employee is created or not 
    var checkBox = document.getElementById("myCheck");

    if (checkBox.checked == true) {
        document.getElementById("candidates").disabled = true;
    }
    else { document.getElementById("candidates").disabled = false; }

}


$("document").ready(function () {        //for getting the values for following textbxes from the candidates dropdown list value if selected 
           
    $("#candidates").on('change', function () {
        var name = $('#candidates option:selected').val();
        
        $.ajax({
            type: 'GET',
            url: " https://localhost:44359/InterviewSchedules/GetDetail/" + name,

            
            success: function (result) {
                
                $('#FirstName').html(result.name);
                $('#LastName').html(result.last);
                $('#Email').html(result.emial); 
                $('#Mobile').html(result.mobile); 
                $('#Experience').html(result.experience); 


            }

        });

    });


});
