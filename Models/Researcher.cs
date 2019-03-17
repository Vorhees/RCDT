using System;

namespace RCDT.Models
{
    //This class will handle all user accounts who are researchers. This class extends the user class and sets the permissions 
    //and account information in the constructor.
    public class Researcher : User
    {
        public Researcher(string userName, string password) : base(userName, password)
        {
            //this group of variables focuses on the user's own account and its edit permissions.
            base.userName = userName;
            base.password = password;
            base.removeAccPermission = true;
            base.changeAccPassPermission = true;
            base.changeAccEmailPermission = true;
            //------------------------------------------------------------------------------------------------------------------------------
            //this group of variables focuses on the user's ability to change other accounts.
            base.inviteNewAccPermission = true;
            base.createAccPermission = true;
            //------------------------------------------------------------------------------------------------------------------------------
            //this group of variables focuses on the user's ability to affect the session and experiments.
            base.changeImageThemePermission = true;
            base.changeBoardThemePermission = true;
            base.editSessionKeyPermission = true;
            base.makeMovePermission = true;
            base.taskEditPermission = true;
            base.taskDisposalPermission = true;
            base.experimentCreatePermission = true;
            base.experimentEditPermission = true;
            base.experimentDisposalPermission = true;
            //------------------------------------------------------------------------------------------------------------------------------
            //this group of variables focues on the users ability to use and access data.
            base.accessDataPermission = true;
            base.archiveTaskDataPermission = true;
            base.IRBPermission = true;
        }
    }
    
}