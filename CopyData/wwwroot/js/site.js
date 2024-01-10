// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    LoadtData();
});

function LoadtData() {
    $.ajax({
        type: "get",
        url: "/Home/TableData/",
        datatype: "json",
        success: function (data) {
            $("#table").empty();
            $.each(data.getEmployees, function (key, item) {
                var row = "<tr>"
                    + "<td>" + item.employee1 + "</td>"
                    + "<td>" + item.empName + "</td>"
                    + "<td>" + item.govid + "</td>"
                    + "<td>" + item.department + "</td>"
                    + "<td>" + item.dob + "</td>"
                    + "<td>" + item.gender + "</td>"
                    + "</tr>";
                $("#table").append(row);
            });
            var links = '';
            for (var i = 1; i <= data.pageCount; i++) {
                if (i != data.CurrentPageIndex) {

                    links += '  <a class="list" id="value" data-id="' + i + '">' + i + '</a >';
                } else {
                    '<span>' + i + '</span>';
                }
            }
            $('#pagination').html(links);
        },
        error: function (error) {
            console.error('Error loading data:', error);
        }
    });  
}


$(document).on('click', '.list', function (e) {
    e.preventDefault();
    var no = $(this).attr('data-id');
    $.ajax({
        url: '/Home/TableData/',
        type: 'GET',
        datatype: "html",
        data: { 'currentPageIndex': no },
        success: function (result) {
            $("#table").empty();
            $.each(result.getEmployees, function (key, item) {
                var row = "<tr>"
                    + "<td>" + item.employee1 + "</td>"
                    + "<td>" + item.empName + "</td>"
                    + "<td>" + item.govid + "</td>"
                    + "<td>" + item.department + "</td>"
                    + "<td>" + item.dob + "</td>"
                    + "<td>" + item.gender + "</td>"
                    + "</tr>";
                $("#table").append(row);
            });
        },
        error: function (error) {
            console.error('Error loading data:', error);
        }
    });
});

$(document).keyup("#search", function () {
    var searchdata = $("#search").val();
    $.ajax({
        url: '/Home/TableData/',
        type: 'GET',
        data: {"Searchdata": searchdata },
        success: function (result) {
            $("#table").empty();
            $.each(result.getEmployees, function (key, item) {
                var row = "<tr>"
                    + "<td>" + item.employee1 + "</td>"
                    + "<td>" + item.empName + "</td>"
                    + "<td>" + item.govid + "</td>"
                    + "<td>" + item.department + "</td>"
                    + "<td>" + item.dob + "</td>"
                    + "<td>" + item.gender + "</td>"
                    + "</tr>";
                $("#table").append(row);
            });
        },
        error: function (error) {
            console.error('Error loading data:', error);
        }
    });
})