-set "OauthGoogleEnabled": "true" in appSetting.json file else by default JWT token
will be enabled. See startup.cs for authentication configuration.
Call https://localhost:5001/Account to redirect on google login
-set "OauthGoogleEnabled": "false" in appSetting.json file to use JWT token
-Call https://localhost:5001/Product to call product service, if JWT is enabled then nee to pass
bearer token with requestHeader. call https://localhost:5001/Token to get bearer token
-Call https://localhost:5001/Session to look how session management work
-Call https://localhost:5001/swagger to look swagger page
-Call https://localhost:5001/TestException to look how centralize exception works
-Look tech1234\Logs folder to see logs, aslo look Serilog configuration in appsetting.json file
-Look Pms.Bdd to look Specflow BDD development, exceute "dotnet test" command in Pms.Core folder
 To execute test cases, run "$env:VSTEST_HOST_DEBUG=1" command on terminal and then run "dotnet test"
 which will give testhost processId. Press ctrl+shift+D to open "Run & Debug"  panel rather than 
 using .Net Core Launch, use .net Core Attch and select testhost.exe with same processid which got
 in dotnet test command


