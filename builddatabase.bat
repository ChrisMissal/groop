@echo If you receive an error running this step please verify that you have an instance of sql server 2005 running at "localhost" (this is the default).
@echo If you do not have this instace, but instead has another instance, edit the file 'config/local-properties.xml' and set the the property "database.server" to match the instance you have installed.
@echo If you do not have this file, run firsttimeconfig.bat which will create it for you.

go.bat builddatabase & pause