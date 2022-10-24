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

- .NET 6.0 Core or higher
- MongoDB Community Server 6.0.2 or later

# Install

## 1. Install from source

Download the OPENVMS source code directory directly from any OPENVMS repository (Github/Gitee) and use the local .NET
The compiler compiles. Before doing the following, make sure your local machine has a .NET 6.0 environment.

Open the local directory and run:

    dotnet run

In development mode, a page will open to display the swagger debugging interface. At this point, the api will run on the local machine's
Under the corresponding port and route.

## 2. Install from Github Release

Packages published in Github Release are compiled, and after downloading, unzip, click or double-click the executable file to run.

# For Developer

## Basic concepts

- Controller

    Controller provides the accessibility for
Api
- Service

    Provides basic service of each instance model
- Model

    Defines different kinds of instance model
- Auth

    Auth provides software auth connection service.
- Security

## Client Authorization

OpenVMS provides a 

# ApiChart

