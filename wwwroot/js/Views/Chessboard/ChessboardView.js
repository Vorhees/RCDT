var constraints = {audio: true, video: false};
var conStatus = document.getElementById('phone');
var stat = 0;
function audioConnDisconn(ev){
    if(stat == 0){//document.getElementById('disconnected')){
        //var conStatus = document.getElementById('disconnected').value;
        console.log("Status is disconnected. Now connecting.");
        stat = 1;
        conStatus.src = "~/images/disconnected.png";
    } else{
        //var conStatus = document.getElementById('connected').value;
        console.log("Status is connected.  Now disconnecting");
        stat = 0;
        //document.getElementById('phone').src = "~/images/disconnected.png";
    }
    
    //console.log(conStatus);}
    console.log("Connect button clicked");}
//function audioConnDisconn(){
    //navigator.mediaDevices.getUserMedia(constraints).then(function(mediaStream){
    //var audio = document.querySelector('audio');
    //if (conStatus == 'disconnected'){
    //audio.srcObject = mediaStream;
    //audio.onloadedmetadata = function(e){
      //  audio.play();

  //  };
//} else{
  //  audio.onloadedmetadata = function(e){
    //    audio.pause();
    //}

//}).catch(function(err){console.log(err.name + err.message);});//};

//record
//function recordAudio(stream){
 //   var audioRecorder = new MediaStreamRecorder(stream);
   // audioRecorder.mimeType = 'Audio';
    //audioRecorder.ondataavailable = function (blob){
      //  var blobUrl = URL.createObjectURL(blob);
        //document.write('<a href="' + blobURL + '">' + blobUrl + '</a>');
    //};
    //audioRecorder.start(3000);

//}

        var moveNumber = 0;
        var count = 0;
        var letter = ["a","b","c","d","e","f","g","h"];
        function saveBoard()
        {
        var taskSess = document.getElementById('sess').value;
        var userName = document.getElementById('UID').value;
        var saverString = "";
            for (i = 8; i > 0; i--)
            {
                var data = "";
                for (j = 0; j < 7; j++)
                {
                    data = i + letter[j];
                    if (document.getElementById(data).children.length != 0)
                    {
                        console.log(data);
                        saverString += data + " : ";
                        saverString += document.getElementById(data).children[0].src;
                        saverString += "\n";
                    }
                }
            }
            console.log(saverString);
            if(saverString === "")
            {
                saverString = "board Empty";
            }
            $.ajax({
                type: 'POST',
                url: '/Chessboard/AddMoveToLog',
                dataType: 'json',
                data: {
                    'MoveID': moveNumber,
                    'TaskSessionID': taskSess,
                    'UserName': userName,
                    'BoardState': saverString,
                }
            });
        }
        function removeItem(data)
        {
            var child = document.getElementById(data);
            child.parentNode.removeChild(child);
            count--;
        }
        function allowDrop(ev)
        {
            ev.preventDefault();
        }
        function drag(ev)
        {
            ev.dataTransfer.setData("text", ev.target.id); 
            console.log("I am dragged");
        }
        function drop_board(ev)
        {
            ev.preventDefault();
            var data = ev.dataTransfer.getData("text");
            if(ev.target.isEqualNode(document.getElementById("itemBank")) || ev.target.parentNode.isEqualNode(document.getElementById("itemBank")))
            {
                removeItem(data);
            }
            if(ev.target.children.length == 0 && ev.target.nodeName != "IMG" && !ev.target.isEqualNode(document.getElementById("itemBank")))
            {
                ev.target.appendChild(document.getElementById(data));
                console.log("I am dropped as original");
            }
        }
        function drop(ev) 
        {
            ev.preventDefault();
            var data = ev.dataTransfer.getData("text");

            if (!document.getElementById(data).parentNode.isEqualNode(document.getElementById("itemBank")))
            {
            drop_board(ev);
            }
            else
            {
                if (!ev.target.isEqualNode(document.getElementById("itemBank")))
                {
                    if(ev.target.children.length == 0 && ev.target.nodeName != "IMG")
                    {
                        var nodeCopy = document.getElementById(data).cloneNode(true);
                        nodeCopy.id = "draggable" + count;
                        count++;
                        ev.target.appendChild(nodeCopy);
                        console.log("I am dropped");
                    }
                }
            }
            saveBoard();
        }
 
