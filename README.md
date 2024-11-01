# DatingApp
dotnet new sln -n DatingApp : solution gom nhieu project nho ben trong
dotnet new webapi -n DatingApp.API -o DatingApp.API
dotnet sln add DatingApp.API
dotnet ef migrations add InitialDB -p DatingApp.API -o Database/Migrations