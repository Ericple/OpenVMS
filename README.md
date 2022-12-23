> The newest version of OpenVMSys is now transported to https://github.com/OpenVMSys/OpenVMSys
# OpenVMS<sup>2</sup> - Community
![Licence](https://img.shields.io/github/license/Ericple/OpenVMS?style=flat-square)
![Release](https://img.shields.io/github/v/release/Ericple/OpenVMS?style=flat-square)
![GitHub issues](https://img.shields.io/github/issues/Ericple/OpenVMS?logo=github&style=flat-square)
![Database](https://img.shields.io/github/commit-activity/m/Ericple/OpenVMS?style=flat-square)
![author](https://img.shields.io/badge/OpenVMS-Peercat-blue?style=flat-square)
![star](https://img.shields.io/github/stars/Ericple/OpenVMS?logo=github&style=flat-square)
![Github Build](https://img.shields.io/github/workflow/status/Ericple/OpenVMS/.NET?style=flat-square)

OpenVMS is an open source virtual airline management backend that inherits the NODEVMS infrastructure and provides
Completely refactored to use .NET. Currently still in development. Documentation will be published in beta-release
Github Wiki and Gitee Wiki.

The original intention of OpenVMS is to provide an efficient backend system for every player who wants to create a virtual airline.
OpenVMS provides all basic APIs and supports plug-in development. We recommend using Nodejs for client side
Develop and use electron for cross-platform support. Unlike NodeVMS, the scalability of OpenVMS is unmatched
Amazingly, as long as you have experience with .NET development, you can extend it at will.

# Minimum requirements

- [ASP.NET 6.0 Core](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or higher
- [MongoDB Community Server 6.0.2](https://www.mongodb.com/try/download/community) or later

# Install

## 1. Install from source

Download the OPENVMS source code directory directly from any OPENVMS repository ([Github](https://github.com/Ericple/OpenVMS)/[Gitee](https://gitee.com/ericple/open-vms)), and use Native .NET
The compiler compiles. Before doing the following, make sure your local machine has a .NET 6.0 environment.

````
git clone https://github.com/Ericple/OpenVMS.git
````

````
cd OpenVMS
````

````
dotnet build --configuration Release
````

By default, the generated files will be located in the directory under ./bin. Find the executable file corresponding to OpenVMS and run it
Enter the OpenVMS CLI.

````
cd ./bin/Release/net6.0
````

````
./OpenVMS
````

## 2. Install from Github Release

The package published in Github Release is compiled, unzip it after downloading, click or double-click the executable file to run
OpenVMS CLI.

# develop

## basic concept

- ### Server

The server provides the APIs needed to operate the database. In OpenVMS's own APIs, in order to avoid accidental requests, each
ApiKey access verification is added for all non-GET requests. Maintainers can add ApiKeys by themselves in the backend. To add Apikey
Please use the apikey command
``apikey add``. Please note that to add a new apikey, the currently running app process must be terminated (press once
controll/command+c)

- ### Plugins

Plug-ins provide functional extensions of OpenVMS, such as [OpenVMS Airmail Plug-in](). To write plugins, refer to [Open
VMS Plugin Development Guide](##Plugin Development Guide).

- ### verify

OpenVMS uses apikey for operation verification. The apikey will be saved locally in plain text. Please ensure the security of the running directory.

- ### Client

The client is directly facing the user. The web side is not included in the OpenVMS design philosophy, all functions should be included in the client side. but I
There is no objection to packaging web-based clients with webassembly. To write an OpenVMS client, follow these few conventions:

    1. The client must support macOS/Linux/Windows platforms

    2. The client must have a GUI

    3. The client must be able to operate all available APIs on the server

    4. Clients cannot contain advertisements

    5. The client cannot be maliciously booted

    6. Clients must put user experience first
