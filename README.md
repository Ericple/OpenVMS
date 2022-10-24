# OpenVMS<sup>2</sup> - Community
![Licence](https://img.shields.io/github/license/Ericple/OpenVMS?style=flat-square) 
![Release](https://img.shields.io/github/v/release/Ericple/OpenVMS?style=flat-square) 
![GitHub issues](https://img.shields.io/github/issues/Ericple/OpenVMS?logo=github&style=flat-square) 
![Database](https://img.shields.io/github/commit-activity/m/Ericple/OpenVMS?style=flat-square) 
![author](https://img.shields.io/badge/OpenVMS-Peercat-blue?style=flat-square)
![star](https://img.shields.io/github/stars/Ericple/OpenVMS?logo=github&style=flat-square)
![Github Build](https://img.shields.io/github/workflow/status/Ericple/OpenVMS/.NET?style=flat-square)

Virtual airline management system, written with .NET, based on the structure of NodeVMS.
Work in progress. Documentations and installation instructions will be available on github
page once its beta release was out.

The original intention of OpenVMS is to provide an efficient backend system for every player who wants to create a virtual airline. OpenVMS provides all basic APIs and supports plug-in development. We recommend javascript for client-side development and electron for cross-platform support. Unlike NodeVMS, the scalability of OpenVMS is unparalleled, as long as you have .NET development experience, you can extend it arbitrarily.

# Installation Guide

## 1. From source code

Download source code directly from this repo, and compile it
using a .NET compiler

## 2. From packed archive

A full distribution will be available in github pages with the initial release.

# Requirements

- Nodejs 16.17.1 LTS or higher
- MongoDB Community Server 6.0.2 or higher

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

# ApiChart

