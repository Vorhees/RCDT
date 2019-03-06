using System;
using SessionManagement;

namespace TaskList
{
    //this class will be the base class for all tasks in the RCDT. The class will contain various variables, holding important
    //information. Finally the class will allow for many different classes to have as much in common as possible, while still being
    //unique to their own purpose.
    class Tasks
    {
        public SessionKey sessionkey;
        public int maxParticipantCount;
    }
}