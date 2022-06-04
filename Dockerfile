# # Dockerfile is like instruction manual for the computer to follow to let it create an image
# # from instruction this image will tell this sdk to run
# #daker hub is like github and we pulling image version of our skd to put this imahe 
# from mcr.microsoft.com/dotnet/sdk:6.0 as build 

# #workdir docker 
# workdir /app 

# # copy dk instruction will let us copy files from this computer to put inside of the docker image
# # * wildcard that lets the computer scan any files that ends with .sln in this case 
# copy *.sln ./ 
# copy storeApi/*.csproj storeApi/
# copy storeBL/*.csproj storeBL/
# copy storeDL/*.csproj storeDL/
# copy storeModel/*.csproj storeModel/
# copy storeTest/*.csproj storeTest/

# # now we will copy after seting csproj files / project structore

# copy . ./

# # need bin and obj back after ignoring for they are different (restore them)
# # run docker instruction will run cli command in the image
# run dotnet build 

# #new dotnet command (this creates a file caslled publish )
# run dotnet publish -c Release -o publish

# #multi-stage build in Docker

# #skd put lot of gabage in your computer so we have a run time to just run it and not download it


#runnig stage => how to run an application 
#Another stage that is all about running the application or how to run
from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

workdir /app
#Remove the copy instruction here

#Copy the publish folder into the image
copy /publish ./

#Change from CMD to entrypoint
entrypoint ["dotnet", "storeApi.dll"]

#Change port to 5000
expose 5000

#Add new environment to change ASP.NET app to listen to 5000 port
env ASPNETCORE_URLS=http://+:5000