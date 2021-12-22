## Running the Program
To run the program in a production environment, the client should only need an installation of Docker and the Docker Daemon running. Running the program for the first time will also need an internet connection to download needed files to build the program. Extract the provided source code and related text files in a suitable location. Navigate to the base folder of the source code 'Trainor'. From here, run the following commands:

- docker swarm init
- docker compose up

This will first build all the necessary binaries to run the main application, and will afterward copy them to a container to be run in. After that, the database starts. When it is started, the main application will start. The first execution of this took 5 minutes to complete when measuring the start-up time.

Afterward, a user may use the program by opening a web browser and navigating to either localhost:7208 or localhost:7207. The port 7208 maps to http, while 7207 maps to https. The program allows only https connections from the end user, and as such visiting localhost:7208 will redirect to localhost:7207. Additionally, if a user specifies the wrong protocol in the URL, eg. by visiting https://localhost:7208 will not work.

To authorize and authenticate oneself in the program only the e-mail addresses at ITU of the group's members as well as that of the course supervisors are valid.

Known errors:
The mainpage search funtion only works on first page load, and then an exception is thrown.
As a result, the mainpage is not currently functional. 

## Running after cloning from GitHub
If cloning from GitHub, the client will need to generate a database password, connection string, and https certificate. Text-files with the connection string and database password must be placed next to the source code directory that Git creates. The https certifacate must be located at the relative path /aspnet/https/Trainor.Wasm.Server.pfx from here. For the 'correct' connection string and database password format see the included src zip file supplied with the exam handin
