using System;
using Users;

namespace SessionManagement
{
    //This class generates sessionID either from a provided ID or randomly. This class will also keep track of the participants and
    //researchers involved in each session. The goal of this system is to provide clarity and security to participants and
    //and researchers alike.
    public class SessionKey
    {
        public string sessionID;
        public string taskType;
        public string headResearcher;
        public int participantNumber;
        public int researcherNumber;
        private Participant[] participantList;
        private Researcher[] researcherList;
        
        //Constructor that takes head researcher and the taskType of the session
        public SessionKey(string headResearcher, string taskType)
        {
            this.headResearcher = headResearcher;
            this.taskType = taskType;
        }
        //constructor that takes head researcher, tasktype and number of participants in the session.
        public SessionKey(string headResearcher, string taskType, int participantNumber)
        {
            this.headResearcher = headResearcher;
            this.taskType = taskType;
            this.participantNumber = participantNumber;
            this.participantList = new Participant[participantNumber];
        }
        /*
        //constructor that takes head researcher, tasktype, and the number of researchers in the session.
        public SessionKey(string headResearcher, string taskType, int researcherNumber)
        {
            this.headResearcher = headResearcher;
            this.taskType = taskType;
            this.researcherNumber = researcherNumber;
            this.researcherList = new Researcher[researcherNumber];
        }
        */

        //constructor that takes head researcher, tasktype, the number of participants and the number of researchers in the session.
        public SessionKey(string headResearcher, string taskType, int participantNumber, int researcherNumber)
        {
            this.headResearcher = headResearcher;
            this.taskType = taskType;
            this.researcherNumber = researcherNumber;
            this.participantNumber = participantNumber;
            this.researcherList = new Researcher[researcherNumber];
            this.participantList = new Participant[participantNumber];
        }
        //returns sessionID
        public string getSessionID()
        {
            return this.sessionID;
        }
        //returns headResearcher
        public string getHeadResearcher()
        {
            return this.headResearcher;
        }
        //returns session task type
        public string getTaskType()
        {
            return this.taskType;
        }
        //returns the number of participants with access to the session
        public int getParticipantNumber()
        {
            return this.participantNumber;
        }
        //returns the number of researchers with access to the session
        public int getResearcherNumber()
        {
            return this.researcherNumber;
        }
        //returns the total number of all users in the session
        public int getUserNumber()
        {
            return this.researcherNumber + this.participantNumber;
        }
        //updates the task type for the session
        public void setTaskType(string taskType)
        {
            this.taskType = taskType;
        }
        //updates the head researcher for the session
        public void setHeadResearcher(string headResearcher)
        {
            this.headResearcher = headResearcher;
        }
        //adds a participant to the session
        public void addParticipant(Participant participant)
        {
            this.participantList[participantNumber] = participant;
            this.participantNumber++;
        }
        //removes a participant from the session
        public void removeParticipant(Participant participant)
        {
            for (int i = 0; i < participantNumber; i++)
            {
                if (participant.Equals(this.participantList[i]))
                {
                    for(int j = i; j < participantNumber-1; j++)
                    {
                        this.participantList[j] = this.participantList[j+1];
                    }
                    this.participantList[participantNumber-1] = null;
                    this.participantNumber--;
                    return;
                }
            }
        }
        //adds a researcher to the session
        public void addResearcher(Researcher researcher)
        {
            this.researcherList[researcherNumber] = researcher;
            this.researcherNumber++;
        }
        //removes a researcher from the session
        public void removeResearcher(Researcher researcher)
        {
            for (int i = 0; i < researcherNumber; i++)
            {
                if (researcher.Equals(this.researcherList[i]))
                {
                    for(int j = i; j < researcherNumber-1; j++)
                    {
                        this.researcherList[j] = this.researcherList[j+1];
                    }
                    this.researcherList[researcherNumber-1] = null;
                    this.researcherNumber--;
                    return;
                }
            }
        }
        //updates the number of researchers with access to the session
        public void setResearcherNumber(int researcherNumber)
        {
            this.researcherNumber = researcherNumber;
        }
        //updates the number of participants with access to the session
        public void setParticipantNumber(int participantNumber)
        {
            this.participantNumber = participantNumber;
        }
    }
}