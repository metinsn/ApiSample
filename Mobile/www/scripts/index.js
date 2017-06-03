
(function () {
    "use strict";

    document.addEventListener( 'deviceready', onDeviceReady, false );

    function onDeviceReady() {
        document.addEventListener( 'pause', onPause, false );
        document.addEventListener('resume', onResume, false);

        document.getElementById("btnGetir").addEventListener("click", BtnGetir);
        document.getElementById("btnEkle").addEventListener("click", Add);
    };

    function onPause() {
    };

    function onResume() {
    };

    function BtnGetir() {
        $("#list ul").empty();
        $.ajax({
            type: 'GET',
            url: 'https://bgapitest.azurewebsites.net/api/user',
            dataType: 'json',
            success: function (data) {
                $.each(data, function (i, item) {
                    $("#list ul").append("<li>"+ item.FirstName + " " + item.LastName + "</li>")
                })
            }
        })
    };

    function Add() {
        var fname = document.getElementById("fname").value;
        var lname = document.getElementById("lname").value;
        $.ajax({
            type: 'POST',
            url: 'https://bgapitest.azurewebsites.net/api/user',
            data: { "Id": null, "FirstName": fname, "LastName": lname },
            dataType: 'json',
        });
    };
} )();