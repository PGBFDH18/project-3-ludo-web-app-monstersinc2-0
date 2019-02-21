# Logging Implementation

## Serilog

We chose to implement at 3rd party Middleware through adding a Nuget packages<br><br> ![Nuget](img/NugetPackages.jpg)<br><br> 
and configuring it in our source code, Startup.cs and Program.cs. 

Link to the service:
[https://blog.getseq.net/smart-logging-middleware-for-asp-net-core/](https://blog.getseq.net/smart-logging-middleware-for-asp-net-core/)   

## Seq

As any logging facility the logs should be written out to a destination, console, database. 
A third party log aggregation service provider that we chose was **Seq**.
We have download it locally and took a screen shot for it in action. 
![Serilog](img/SerilogMedSeq.jpg)

The configuration lays in the program.cs file. 