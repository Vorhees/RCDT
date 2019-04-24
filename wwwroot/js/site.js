// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $('#sbCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
    });

    //Change side menu icons when hover
    $('#dashboardItem').on('mouseover', function () {
      document.getElementById("dashboard").src="../images/dashboard_hover.png";
    });

    $('#registerUserItem').on('mouseover', function () {
      document.getElementById("registerUser").src="../images/add_user_hover.png";
    });

    $('#manageUserItem').on('mouseover', function () {
      document.getElementById("manageUser").src="../images/manage_user_hover.png";
    });

    $('#registerParticipantItem').on('mouseover', function () {
      document.getElementById("registerParticipant").src="../images/add_user_hover.png";
    });

    $('#createTaskItem').on('mouseover', function () {
      document.getElementById("createTask").src="../images/add_task_hover.png";
    });

    $('#settingsItem').on('mouseover', function () {
      document.getElementById("settings").src="../images/settings_hover.png";
    });

    //Change side menu icons back when leave
    $('#dashboardItem').on('mouseleave', function () {
      document.getElementById("dashboard").src="../images/dashboard.png";
    });

    $('#registerUserItem').on('mouseleave', function () {
      document.getElementById("registerUser").src="../images/add_user.png";
    });

    $('#manageUserItem').on('mouseleave', function () {
      document.getElementById("manageUser").src="../images/manage_user.png";
    });

    $('#registerParticipantItem').on('mouseleave', function () {
      document.getElementById("registerParticipant").src="../images/add_user.png";
    });

    $('#createTaskItem').on('mouseleave', function () {
      document.getElementById("createTask").src="../images/add_task.png";
    });

    $('#settingsItem').on('mouseleave', function () {
      document.getElementById("settings").src="../images/settings.png";
    });

    //For hidden navbar
    /*$('#dummy').on('mouseover', function () {
        setVisible();
    });

    $('#navbar').on('mouseleave', function () {
        setHidden();
    });*/
});


//for hidden navbar
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