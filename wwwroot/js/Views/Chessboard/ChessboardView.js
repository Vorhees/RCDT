
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
        //Code for audio chat and recording.  Needs deployed to a server before testing and implementing peer to peer connections for the audio chat and to verify saving.
        var constraints = {audio: true, video: false};
        var stat = 0;
        var mRecorder;
        function audioConnDisconn(ev) {
            if(stat == 0) {
                console.log("Status is disconnected. Now connecting.");
                stat = 1;
                document.getElementById('phone').src = '/images/connected.png';
                navigator.getUserMedia(constraints, mediaSuccess, medError);
                //For audio playback, commented out becuase peer to peer connections are needed which requires server deployment in order to test and handle the connection and audio stream between multiple users.
                //navigator.mediaDevices.getUserMedia(constraints).then(function(mediaStream){
                    //const userAudio = document.querySelector('audio');
                    //userAudio.srcObject = mediaStream;
                    //userAudio.onloadedmetadata = function(ev){
                        //userAudio.play();
                    //}
                    //console.log("it got here");
                //});
            } else {
                console.log("Status is connected.  Now disconnecting");
                stat = 0;
                document.getElementById('phone').src = "/images/disconnected.png";
                mRecorder.stop();
                //userAudio.stop();
            }
        }
        function mediaSuccess(stream){
            mRecorder = new MediaStreamRecorder(stream);
            mRecorder.mimeType = 'audio/wav';
            mRecorder.ondataavailable = function (blob) {
                var blobURL = URL.createObjectURL(blob);
                console.log(blobURL);
            };
            mRecorder.start(2000);
        }
        function medError(e){
            console.error('media error', e);
        } 
