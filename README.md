# Coding Sample
Coding Test - Crowe Horwath

**Objective:** Write a Hello World program

**Requirements:**

**a.**  The program has 1 current business requirement a write "Hello World" to the console/screen.

**b.**  The program should have an API that is separated from the program logic to eventually support mobile applications,
    web applications, console applications or windows services.

**c.**  The program should support future enhancements for writing to a database, console application, etc.

    - Use common design patterns (inheritance, e.g.) to account for these future concerns.
    - Use configuration files or another industry standard mechanism for determining where to write the 
        information to.
**d.** Write unit tests to support the API.


This Application consists of:
- CodingSample.Core - A class library of reusable code (ConsoleService, DatabaseService e.g.)
- CodingSample.API - REST Web API
- CodingSample.MainProgram - Main program for demo purpose
- CodingSample.Tests - Unit test for the API


**How to Run:**
1. Build the solution
2. If there are missing packages errors then right click on the solution and click 'Restore NuGet Packages'
3. Set CodingSample.API and CodingSample.MainProgram as the "Startup Project"
4. Run

**Setting to change** in CodingSample.MainProgram/App.config
1.  Choose Console or Database option (Database option is not inplemented). Following example is for console
    key="Output_Method" value="Console"
2.  API Url- Modify the port number
    key="Api_Url" value="http://localhost:53665/api/HelloWorld" 
