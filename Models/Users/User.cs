using System;

namespace Users
{
    public class User 
    {
    // This class is the base class for all user types for the RCDT application. This class will be the primary location for the
    //storage of user permissions and user account details.
    //------------------------------------------------------------------------------------------------------------------------------
    //this group of variables focuses on the user's own account and its edit permissions.
    public string userName;
    public string password;
    public bool changeAccPassPermission = false;
    public bool changeAccEmailPermission = false;
    public bool removeAccPermission = false;
    //------------------------------------------------------------------------------------------------------------------------------
    //this group of variables focuses on the user's ability to change other accounts.
    public bool changeOtherPassPermission = false;
    public bool changeOtherEmailPermission = false;
    public bool inviteNewAccPermission = false;
    public bool removeOtherPermission = false;
    public bool changeAccTypePermission = false;
    public bool changeUserPermissionsPermission = false;
    public bool createAccPermission = false;
    public bool destroyAccPermission = false;
    //------------------------------------------------------------------------------------------------------------------------------
    //this group of variables focuses on the user's ability to affect the session and experiments.
    public bool editSessionKeyPermission = false;
    public bool makeMovePermission = false;
    public bool changeImageThemePermission = false;
    public bool changeBoardThemePermission = false;
    public bool taskEditPermission = false;
    public bool taskDisposalPermission = false;
    public bool createTaskPermission = false;
    public bool removeTaskPermission = false;
    public bool experimentCreatePermission = false;
    public bool experimentEditPermission = false;
    public bool experimentDisposalPermission = false;
    //------------------------------------------------------------------------------------------------------------------------------
    //this group of variables focues on the users ability to use and access data.
    public bool accessDataPermission = false;
    public bool IRBPermission = false;
    public bool archiveTaskDataPermission = false;
    public bool manageDataBasePermission = false;
    public bool accessDataBasePermission = false;
    //------------------------------------------------------------------------------------------------------------------------------
    
    
        public User()
        {
            /* Add constructor details here */
        }
        public string getUserName()
        {
            return this.userName;
        }
        public string getPassword()
        {
            return this.password;
        }
        public void setUserName(string userName)
        {
            this.userName = userName;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }
    }
}