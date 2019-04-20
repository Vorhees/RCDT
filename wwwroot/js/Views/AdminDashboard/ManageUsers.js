    function toggleUserTable()
    {
        var ut = document.getElementById("userTable");
        var pt = document.getElementById("participantTable");

        ut.style.display = (ut.style.display == "table") ? "none" : "table";
        pt.style.display = "none";
    }
    function toggleParticipantTable()
    {
        var pt = document.getElementById("participantTable");
        var ut = document.getElementById("userTable");

        pt.style.display = (pt.style.display == "table") ? "none" : "table";
        ut.style.display = "none";
    }

