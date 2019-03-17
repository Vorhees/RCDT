using System;
using SessionManagement;
using RCDT.Models;

namespace TaskList
{
    //This class will handle the director matcher task. It will have multiple participants, one of which will be a director.
    //The director will be able to issue verbal and text-based commands to the other participants, directing them to manipulate
    //the board and its objects. The board will be a standard 8x8 board, with 64 squares, similar to a chess board.
    //the objects will just be redom shapes, animals, and colors.
    class DirectorMatcherTask : Tasks
    {
        private Participant director;
        
        public DirectorMatcherTask(SessionKey key)
        {
            base.sessionkey = key;
            base.maxParticipantCount = 6;
        }
        public DirectorMatcherTask(SessionKey key, Participant director)
        {
            //DirectorMatcherTask(sessionKey key);
            this.director = director;
        }
        public Participant getDirector()
        {
            return this.director;
        }
        public SessionKey getSessionKey()
        {
            return base.sessionkey;
        }
        public void setDirector(Participant director)
        {
            this.director = director;
        }
        public void setSessionKey(SessionKey key)
        {
            base.sessionkey = key;
        }
        public int getMaxParticipantCount()
        {
            return base.maxParticipantCount;
        }
    }
}