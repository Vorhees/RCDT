using System;

namespace RCDT.Models
{
    //This class will handle all user accounts who are IRB Reviewers. This class extends the user class and sets the 
    //permissions and account information in the constructor.
    class IRBReviewer : User
    {
        
        public IRBReviewer(string userName, string password) : base(userName, password)
        {
            //this group of variables focuses on the user's own account and its edit permissions.
            base.userName = userName;
            base.password = password;
            base.changeAccPassPermission = true;
            base.changeAccEmailPermission = true;
            base.removeAccPermission = true;
            //------------------------------------------------------------------------------------------------------------------------------
            //this group of variables focuses on the user's ability to affect the session and experiments.
            base.editSessionKeyPermission = true;
            base.makeMovePermission = true;
            //------------------------------------------------------------------------------------------------------------------------------
            //this group of variables focues on the users ability to use and access data.
            base.IRBPermission = true;
            base.accessDataPermission = true;
        }
    }
}
