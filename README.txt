In order to run the program:

Download VeeamAssignment folder, Source folder, logFile text
Open VeeamAssignment.sln in Visual studio
Notice that program has args to except so you should pass the arguments :
sourceFolder - except path argument : the path of the source folder that you want to synchronize. This is the folder that you want to use as the "master" copy.
replicaFolder - except path argument : the path of the replica folder that you want to synchronize. This is the folder that you want to maintain as an identical copy of the source folder.
interval - except an integer synchronization interval: the amount of time (in seconds) between each synchronization.
logFile - except path argument : the path of the log file where the program will write the log of the synchronization operations (file creation, copying, and removal).
To add argument you should do the following steps:
In Source Explorer right click on VeeamAssignment folder and then choose Properties
Go to Debug category
Click on "Open debug launch profiles UI"
On Command line arguments enter the path of your Source folder then on new line enter the second argument of Replica path, then the seconds and then the logfile.txt path For example :
"C:\Users\yarde\source\repos\VeeamAssignment\Source"

"C:\Users\yarde\source\repos\VeeamAssignment\Replica"

15

"C:\Users\yarde\source\repos\VeeamAssignment\logFile.txt"

Run the program