window.onbeforeunload = confirmExit;

function confirmExit()
{
    return "Are you sure you want to exit the task?";
}