using System;

namespace Users
{
    //This class will handle all user accounts who are participants. This class extends the user class and sets the 
    //permissions and account information in the constructor.
    public class Participant : User
    {
        public Participant(string userName, string password)
        {
            //this group of variables focuses on the user's own account and its edit permissions.
            base.userName = userName;
            base.password = password;
            base.changeAccPassPermission = true;
            base.changeAccEmailPermission = true;
            //------------------------------------------------------------------------------------------------------------------------------
            //this group of variables focuses on the user's ability to affect the session and experiments.
            base.makeMovePermission = true;
            
        }
    }
}