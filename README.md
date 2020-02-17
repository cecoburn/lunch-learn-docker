# lunch-learn-docker
A simple demonstration of how to leverage Docker to create a container and run a .NET Core application.

#### Build the Dockerfile
Open a terminal session and cd to project root directory and run the following:
```sh
    > docker build -t docker-poc -f Dockerfile .

    Sending build context to Docker daemon  20.67MB
    Step 1/13 : FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
    ---> 4422e7fb740c
    Step 2/13 : WORKDIR /app
    ---> Using cache
    ---> b07e87567ca6
    Step 3/13 : COPY src/*.csproj ./src/
    ---> Using cache
    ---> 072099473b83
    Step 4/13 : WORKDIR /app/src
    ---> Using cache
    ---> ada328199917
    Step 5/13 : RUN dotnet restore
    ---> Using cache
    ---> a5672d1e7d7d
    Step 6/13 : WORKDIR /app/
    ---> Using cache
    ---> 1d6e1e470abd
    Step 7/13 : COPY src/. ./src/
    ---> Using cache
    ---> a02800d412e3
    Step 8/13 : WORKDIR /app/src
    ---> Using cache
    ---> 12666c9de797
    Step 9/13 : RUN dotnet publish -c Release -o out
    ---> Using cache
    ---> bc561adbe043
    Step 10/13 : FROM build AS testrunner
    ---> bc561adbe043
    Step 11/13 : WORKDIR /app/test
    ---> Using cache
    ---> 143962a19f7e
    Step 12/13 : COPY test/. .
    ---> Using cache
    ---> 7256ed4e07ff
    Step 13/13 : ENTRYPOINT ["dotnet", "test"]
    ---> Using cache
    ---> 15f2df96f821
    Successfully built 15f2df96f821
    Successfully tagged docker-poc:latest

```
#### Confirm image was created
```sh
    > docker images
    
    REPOSITORY                              TAG                 IMAGE ID            CREATED             SIZE
    docker-poc                              latest              15f2df96f821        22 minutes ago      710MB
    microsoft/dotnet                        latest              1717b99d2535        3 weeks ago         1.74GB

```
#### Create the Container
```sh
    > docker create docker-poc
    
    41489193d7c7e4d909f8949b3975d7855e850a84c5dc8daa770ea7f3433990ed
```
#### Confirm Container was created
```sh
    > docker ps -a

    CONTAINER ID        IMAGE               COMMAND                  CREATED             STATUS              PORTS                      NAMES
    41489193d7c7        docker-poc          "dotnet test"            21 seconds ago      Created                                        busy_meitner

```
#### Single Run of Container
```sh
    > docker run -it docker-poc

    Test run for /app/test/bin/Debug/netcoreapp3.0/test.dll(.NETCoreApp,Version=v3.0)
    Microsoft (R) Test Execution Command Line Tool Version 16.3.0
    Copyright (c) Microsoft Corporation.  All rights reserved.

    Starting test execution, please wait...

    A total of 1 test files matched the specified pattern.
                                                                                                                                                                                                                                    
    Test Run Successful.
    Total tests: 5
        Passed: 5
    Total time: 2.0211 Seconds
```


#### Run Interactively
```
> docker run -it -v ${PWD}:/code mcr.microsoft.com/dotnet/core/sdk

root@62d4b5b43342:/# 

> dotnet test code/test/test.csproj

Test run for /code/test/bin/Debug/netcoreapp3.0/test.dll(.NETCoreApp,Version=v3.0)
Microsoft (R) Test Execution Command Line Tool Version 16.3.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...

A total of 1 test files matched the specified pattern.
                                                                                                                                                                                   
Test Run Successful.
Total tests: 5
     Passed: 5
Total time: 1.5846 Seconds

> exit
```

#### Clean-up Containers
```sh
    > docker rm /d629847a5e50
```

#### Clean-up Images
```sh
    > docker image rm docker-poc
```