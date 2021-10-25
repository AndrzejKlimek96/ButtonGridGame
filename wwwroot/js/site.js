// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    console.log("its load");

    $(document).on("click",".game-button",function (event) {
        event.preventDefault();

        var buttonNumber = $(this).val();
        console.log("button clickded" + buttonNumber);
        doButtonUpdate(buttonNumber);
        checkIfAllMatch();
    })

    function doButtonUpdate(buttonNumber) {
        $.ajax({
            datatype: "html",
            method: 'POST',
            url: '/button/ShowOneButton',
            data: {
                "buttonNumber": buttonNumber
            },
            success: function (data) {
                console.log(data);
                $("#" + buttonNumber).html(data);
            }
        })
    }

    function checkIfAllMatch() {
        $.ajax({

            datatype: "html",
            type: "POST",
            url: '/Button/CheckIfWin',
            data: $("form").serialize(),
            success: function (data) {
                console.log(data);
                $("#AreYouWinningSon").html(data);
            }

        });

    }
        

    




})