// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $('#sbCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
    });

    $('#navbar').on('mouseover', function () {
        setVisible();
    });

    $('#navbar').on('mouseleave', function () {
        setHidden();
    });
});

function setVisible()
  {
    document.getElementById("navbarcontainer").style.visibility="visible";
  }

function setHidden()
  {
    document.getElementById("navbarcontainer").style.visibility="hidden";
  }