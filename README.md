# Test_Customer_API
Basic API for Customer Master
Post
Get
Put
Delete

What is  covered
Architecure for Customer product
Domain layer: 
Application layer: 

Validation 
Functionality : All features except Delete

Github: Added code to github
Docker: Failed with below error, Not able for pull the images for the nuget libraries. May be teh proxy issues .Googled for the soltuions.
C:\Program Files\dotnet\sdk\2.2.402\NuGet.targets(123,5): error : Unable to load the service index for source https://api.nuget.org/v3/index.json. [C:\src\CustomerService\CustomerService.csproj]
C:\Program Files\dotnet\sdk\2.2.402\NuGet.targets(123,5): error :   No such host is known [C:\src\CustomerService\CustomerService.csproj]
The command 'cmd /S /C dotnet restore "CustomerService/CustomerService.csproj"' returned a non-zero code: 1
https://improveandrepeat.com/2019/09/how-to-fix-network-errors-with-docker-and-windows-containers/

Could not cover the below area due to time limitation
Different Environment json supports  
Test implemntaion is not done. Domain level testing and service, integration 
Bsic utilities for DB
Documentation for swagger
Could not do the HR API call to verify the personal number verification . But I can explain the concept
Added the HTTPClient extension skeleton on the Contract level to call HR API to verify the Personalnumber

Logging and nencessary middlewears, Authentication 