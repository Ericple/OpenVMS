# OpenVMS<sup>2</sup> - Community
![Licence](https://img.shields.io/github/license/Ericple/OpenVMS?style=flat-square)
![Release](https://img.shields.io/github/v/release/Ericple/OpenVMS?style=flat-square)
![GitHub issues](https://img.shields.io/github/issues/Ericple/OpenVMS?logo=github&style=flat-square)
![Database](https://img.shields.io/github/commit-activity/m/Ericple/OpenVMS?style=flat-square)
![author](https://img.shields.io/badge/OpenVMS-Peercat-blue?style=flat-square)
![star](https://img.shields.io/github/stars/Ericple/OpenVMS?logo=github&style=flat-square)
![Github Build](https://img.shields.io/github/workflow/status/Ericple/OpenVMS/.NET?style=flat-square)

OpenVMS是一个开放源代码的虚拟航空公司管理后端，它继承了NODEVMS的基础结构，并
使用.NET进行了完全的重构。当前仍在开发中。文档将在beta-release发布后发布于
Github Wiki与Gitee Wiki中。

OpenVMS诞生的本意是为每一个想要创建虚拟航空公司的玩家提供一个高效的后端系统。
OpenVMS提供所有的基础API，并支持插件开发。我们推荐使用Nodejs进行客户端
开发，并使用electron进行跨平台支持。与NodeVMS不同，OpenVMS的可拓展性是无与
伦比的，只要你拥有.NET开发经验，你就可以任意拓展它。

# 最低要求

- [ASP.NET 6.0 Core](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) 或更高
- [MongoDB Community Server 6.0.2](https://www.mongodb.com/try/download/community) 或更高版本

# 安装

## 1.从源代码安装

从OPENVMS任意仓库（[Github](https://github.com/Ericple/OpenVMS)/[Gitee](https://gitee.com/ericple/open-vms))直接下载OPENVMS源代码目录，并使用本地.NET
编译器进行编译。在执行以下操作前，确保你的本地机器具备了.NET 6.0环境。

```
git clone https://github.com/Ericple/OpenVMS.git
```

```
cd OpenVMS
```

```
dotnet build --configuration Release
```

默认情况下，生成文件将会位于./bin下的目录中。找到OpenVMS对应可执行文件运行即可
进入OpenVMS CLI。

```
cd ./bin/Release/net6.0
```

```
./OpenVMS
```

## 2.从Github Release安装

发布于Github Release中的包是已编译的，下载后解压，单击或双击可执行文件即可运行
OpenVMS CLI。

# 开发

## 基本概念

- ### 服务端

服务端提供操作数据库需要使用的Api，在OpenVMS自带Api中，为了避免意外请求，对每一
个非GET请求都添加了ApiKey访问验证。维护者可以在后端自行添加ApiKey。要新增Apikey
请使用apikey命令
``apikey add``。请注意，若要添加新的apikey，必须把当前运行的app进程结束（按一次
controll/command+c)

- ### 插件

插件提供OpenVMS的功能扩展，比如[OpenVMS航空邮箱插件]()。要编写插件，请参考[Open
VMS插件开发指南](##插件开发指南)。

- ### 验证

OpenVMS使用apikey进行操作验证，apikey会以明文保存在本地，请确保该运行目录的安全。

- ### 客户端

客户端直接面向用户。OpenVMS设计理念中不包含网页端，所有功能均应包含在客户端中。但我
不反对使用webassembly打包基于web的客户端。要编写OpenVMS客户端，请遵守以下几点约定：

    1. 客户端必须支持macOS/Linux/Windows三平台

    2. 客户端必须有GUI

    3. 客户端必须能操作服务端所有可用Api

    4. 客户端不能包含广告

    5. 客户端不能存在恶意引导

    6. 客户端必须以用户体验为第一要务

