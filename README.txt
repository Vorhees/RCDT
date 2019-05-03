README FOR RCDT

==========================================================================
==========================================================================
==========================================================================
                         WELCOME TO THE RCDT
--------------------------------------------------------------------------
This application is designed as a human linguistics research application.
The application captures audio and text feed from the participants during
participation in a task. Currently the only implemented task is the DMT:
Director Matcher Task.


The DMT involves a chessboard with various colored sprites. The goal of
this task is for participants to match the boardstate of their task with
the board state of a director. The participants will not be permitted to 
view any boardstate aside from their own. The participants must cooperate
using voice and text to match the boardstate. This cooperation will allow
researcher to study linguistics and code switching through the analysis of
the captured voice and text interactions of participants.

To begin a research group must use the initially seeded Admin to register
researcher and admin accounts as neccessary. The initially seeded Admin is
accessed through interacting with the website logo. When prompted, please
enter the following credentials for the seeded Admin:

                         Email: TestAdmin1@test.com
                         Password: Testpw1!

Once successfully logged in, the seeded Admin account can be used to build
the required Researcher and ResearcherAssistant accounts. These accounts
will need to be email verified, to confirm that the correct user has been
granted access to the account. The seeded Admin can also be used to create
a new admin account. This is considered good practice as once a new admin
account has been created the seeded Admin can be removed from the system,
preventing unwanted access using default credentials. Researcher accounts
can be used to create new task sessions, register participants, view task
data, manage and delete task data, manage and delete participant data, and
interact and communicate with participants during task sessions.


Participant accounts are the most limited of accounts. The participant is
a willing member of an active research study which uses this application.
Participants are able to enter an assigned task session, interact with the
assigned task session, interact with fellow participants, and choose to
connect or disconnect from voice chat at any point during participation.
These accounts are anonymized as no identifying data is requested by the
application during the participant registration process. If a research
group requires non-anonymized participant accounts the researchers should
record this data separately outside of the application.


To view the communication data, boardstate data, or task metadata any user
with the proper permissions may log in, access the dashboard through the
navigation menu on the LeftHand side of the screen, and select the desired
task. From this view, a qualified user is able to view separate tables for
the task moveLog, task chatlog, and the task metadata. In a future update
a voice communication log will also be available to researchers from this
area of the application.

--------------------------------------------------------------------------
DEPENDANCIES THAT MUST BE INSTALLED BEFORE ATTEMPTING TO USE THE RCDT
* dotnet CORE version 2.2.104
* JQuery Javascript Library version 3.3.1
* jQuery Validation Plugin version 1.17.0
* JQuery Validation Unobtrusive Plugin version 3.2.11
* Bootstrap v4.1.3 (https://getbootstrap.com/) 
* SignalR latest version
* EntityFramework Core - included in the full install of dotnet CORE
==========================================================================
==========================================================================
==========================================================================
