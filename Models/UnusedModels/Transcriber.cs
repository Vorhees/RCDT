using System;

namespace RCDT.Models
{
    //This class will handle all user accounts who are transcribers.  It extends the user class and sets the permissions
    //and account information in the constructor.
    class Transcriber : User
    {
        public Transcriber(string userName, string password) : base(userName, password)
        {
            //This group of variables focuses on the users own account and its edit permissions
            base.userName = userName;
            base.password = password;
            base.changeAccPassPermission = true;
            base.changeAccEmailPermission = true;
            //------------------------------------------------------------------------------------------------------------------------------
            //this group of variables focuses on the users ability to use and access data.
            base.accessDataPermission = true;
            base.IRBPermission = true;
            base.accessDataBasePermission = true;
            base.archiveTaskDataPermission = true;
            
            
        }
    }
}