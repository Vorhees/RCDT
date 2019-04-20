        const audio = document.querySelector('audio');
        const constraints = window.constraints = {
            audio: true,
            video: false
        };
        function streamAudio(stream) {
            console.log('in streamAudio');
            const audioTracks = stream.getAudioTracks();
            stream.oninactive = function() {
                console.log('Stream ended');
            };
            window.stream = stream;
            audio.srcObject = stream;
        }
        function handleError(error) {
            console.log('navigator.MediaDevices.getUserMedia error: ', error.message, error.name);
        }
        console.log('before navigator line');
        navigator.mediaDevices.getUserMedia(constraints).then(streamAudio).catch(handleError);
        console.log('after navigator line');
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
 