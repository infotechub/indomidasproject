/// <reference path="jquery-1.9.1.intellisense.js" />
//Load Data in Table when documents is ready
$(document).ready(function () {
    loadData();
});

//Load Data function
function loadData() {
    $.ajax({
        url: "https://localhost:44393/api/complaint",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + item.username + '</td>';
                html += '<td>' + item.subject + '</td>';
                html += '<td>' + item.priority + '</td>';
                html += '<td>' + item.isCompleted + '</td>';
                html += '<td>' + item.createdOn + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.id + ')">View</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert("fail to load");
        }
    });
}

//Add Data Function 
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        MeasurementType: $('#measurementtype').val(),
        From: $('#convfrom').val(),
        To: $('#convto').val(),
        MeasurementValue: $('#measurementvalue').val()
    };
    $.ajax({
        url: "Home/MeasurementConversion",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID
function getbyID(Id) {
    $('#username').css('border-color', 'lightgrey');
    $('#subject').css('border-color', 'lightgrey');
    $('#content').css('border-color', 'lightgrey');
    $('#response').css('border-color', 'lightgrey');
    $.ajax({
        url: "https://localhost:44393/api/complaint/" + Id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.id);
            $('#username').val(result.username);
            $('#Subject').val(result.subject);
            $('#Content').val(result.content);
            $('#Response').val(result.response);
            $('#Priority').val(result.priority);
            $('#IsCompleted').val(result.isCompleted);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        Id: $('#id').val(),
        Username: $('#username').val(),
        Subject: $('#subject').val(),
        Content: $('#content').val(),
        Priority: $('#priority').val(),
        Response: $('#response').val(),
        IsCompleted: $('#iscompleted').val()
    };
    $.ajax({
        url: "https://localhost:44393/api/complaint",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#Id').val("");
            $('#Username').val("");
            $('#Subject').val("");
            $('#Content').val("");
            $('#Response').val("");
            $('#IsCompleted').val("");
            $('#Priority').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "https://localhost:44393/api/complaint/" + Id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes
function clearTextBox() {
    $('#Id').val("");
    $('#Username').val("");
    $('#Subject').val("");
    $('#Content').val("");
    $('#Response').val("");
    $('#Priority').val("");
    $('#IsCompleted').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#username').css('border-color', 'lightgrey');
    $('#subject').css('border-color', 'lightgrey');
    $('#content').css('border-color', 'lightgrey');
    $('#response').css('border-color', 'lightgrey');
}
//Valdidation using jquery
function validate() {
    var isValid = true;
    if ($('#Subject').val().trim() == "") {
        $('#Subject').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Subject').css('border-color', 'lightgrey');
    }
    if ($('#Content').val().trim() == "") {
        $('#Content').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Content').css('border-color', 'lightgrey');
    }
    
    return isValid;
}