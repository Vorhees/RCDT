// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $('#sbCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
    });

    /*$('#dummy').on('mouseover', function () {
        setVisible();
    });

    $('#navbar').on('mouseleave', function () {
        setHidden();
    });*/
});

/*function setVisible()
  {
    document.getElementById("navbar").style="margin-top:0px";
    document.getElementById("navbar").style.height="100px";
    document.getElementById("navbar").style.visibility="visible";
    document.getElementById("dummy").style="margin-top:0px";
    document.getElementById("dummy").style.visibility="hidden";
  }

function setHidden()
  {
    document.getElementById("navbar").style="margin-top:-100px";
    document.getElementById("navbar").style.visibility="hidden";
    document.getElementById("navbar").style.height="50px";
    document.getElementById("dummy").style="margin-top:100px";
    document.getElementById("dummy").style.visibility="visible";
  }*/