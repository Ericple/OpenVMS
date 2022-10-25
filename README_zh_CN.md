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

打开本地目录，运行：

`dotnet build`

默认情况下，生成文件将会位于./bin下的目录中。找到OpenVMS对应可执行文件运行即可
进入OpenVMS CLI。

## 2.从Github Release安装

发布于Github Release中的包是已编译的，下载后解压，单击或双击可执行文件即可运行
OpenVMS CLI。

# 开发

## 基本概念

- ### 服务端

服务端提供操作数据库需要使用的Api，在OpenVMS自带Api中，为了避免意外请求，对每一
个非GET请求都添加了ApiKey访问验证。维护者可以在后端自行添加ApiKey