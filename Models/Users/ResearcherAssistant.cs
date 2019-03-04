using System;

namespace Users
{
    //This class will handle all user accounts who are Researcher Assistants. This class extends the user class and sets the 
    //permissions and account information in the constructor.
    class ResearcherAssistant : User
    {
        public ResearcherAssistant(string userName, string password) : base(userName, password)
        {
            //this group of variables focuses on the user's own account and its edit permissions.
            base.userName = userName;
            base.password = password;
            base.changeAccPassPermission = true;
            base.changeAccEmailPermission = true;
            base.removeAccPermission = true;
            //------------------------------------------------------------------------------------------------------------------------------
            //this group of variables focuses on the user's ability to change other accounts.
            base.inviteNewAccPermission = true;
            base.createAccPermission = true;
            //------------------------------------------------------------------------------------------------------------------------------
            //this group of variables focuses on the user's ability to affect the session, make moves, and access data.
            base.makeMovePermission = true;
            base.editSessionKeyPermission = true;
            base.IRBPermission = true;
            base.archiveTaskDataPermission = true;
            base.accessDataPermission = true;
            base.experimentCreatePermission = true;
            base.experimentEditPermission = true;
            base.changeImageThemePermission = true;
            base.changeBoardThemePermission = true;
            base.taskEditPermission = true;
        }
    }
    
}