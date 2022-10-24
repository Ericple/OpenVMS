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

- .NET 6.0 Core 或更高
- MongoDB Community Server 6.0.2 或更高版本

# 安装

## 1.从源代码安装

从OPENVMS任意仓库（Github/Gitee)直接下载OPENVMS源代码目录，并使用本地.NET
编译器进行编译。在执行以下操作前，确保你的本地机器具备了.NET 6.0环境。

打开本地目录，运行：

    dotnet run

在开发模式下，将会打开一个页面以显示swagger调试界面。此时，api将运行于本地机器的
对应端口及路由下。

## 2.从Github Release安装

发布于Github Release中的包是已编译的，下载后解压，单击或双击可执行文件即可运行。