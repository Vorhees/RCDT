using System;

namespace Users
{
    //This class will handle all user accounts who are Admins. This class extends the user class and sets the permissions and 
    //account information in the constructor.
    class Admin : User
    {
        public Admin(string userName, string password) : base(userName, password)
        {
            //this group of variables focuses on the user's own account and its edit permissions.
            base.userName = userName;
            base.password = password;
            base.changeAccPassPermission = true;
            base.changeAccEmailPermission = true;
            base.removeAccPermission = true;
            //------------------------------------------------------------------------------------------------------------------------------
            //this group of variables focuses on the user's ability to change other accounts.
            base.changeOtherPassPermission = true;
            base.changeOtherEmailPermission = true;
            base.inviteNewAccPermission = true;
            base.removeOtherPermission = true;
            base.changeAccTypePermission = true;
            base.changeUserPermissionsPermission = true;
            base.createAccPermission = true;
            base.destroyAccPermission = true;
            //------------------------------------------------------------------------------------------------------------------------------
            //this group of variables focuses on the user's ability to affect the session and experiments.
            base.editSessionKeyPermission = true;
            base.makeMovePermission = true;
            base.changeImageThemePermission = true;
            base.changeBoardThemePermission = true;
            base.taskEditPermission = true;
            base.taskDisposalPermission = true;
            base.createTaskPermission = true;
            base.removeTaskPermission = true;
            base.experimentCreatePermission = true;
            base.experimentEditPermission = true;
            base.experimentDisposalPermission = true;
            //------------------------------------------------------------------------------------------------------------------------------
            //this group of variables focues on the users ability to use and access data.
            base.archiveTaskDataPermission = true;
            base.manageDataBasePermission = true;
            base.accessDataBasePermission = true;
        }
    }
}
