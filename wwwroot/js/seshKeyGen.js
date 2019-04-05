function randSessionKey()
  {
    var rand = Math.floor(Math.random() * 9999) + 1
    document.getElementById("seshKey").value = rand;
  }