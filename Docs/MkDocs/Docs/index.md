# QtSharp

Mono/.NET bindings for Qt

This project aims to create Mono/.NET libraries that wrap Qt (<https://qt-project.org/>) thus enabling its usage through C#. <br>
It relies on the excellent CppSharp (<https://github.com/mono/CppSharp>). <br>
CppSharp is a generator that expects the include and library directories of a Qt set-up and then generates and compiles the wrappers. <br>
While still in development, it should work with any Qt version when complete.

There is no Qt included in the repository, users have to download and install Qt themselves. <br>
For now, Qt MinGW for Windows has been the only tested version. <br>
Qt for OS X and Linux are planned, Qt for VC++ has not been planned for now.

The source code is separated into a library that contains the settings and passes the generator needs, and a command-line client. <br>
In the future, a GUI client, constructed with Qt# itself, is planned as well.

## Getting started

You need to deploy Qt itself by following <http://doc.qt.io/qt-5/windows-deployment.html#application-dependencies>. <br>
In addition, for each Qt module you use you also need Qt<module>-inlines.dll deployed alongside your executable. <br>
You can use QtSharp with any C# IDE, including Visual Studio, but make sure your executable is 32-bit by either using the
x86 configuration or AnyCPU with "Prefer 32-bit" checked.

## Examples

You can find examples at

  * <https://github.com/dsoronda/QtSharpDemos>
  * <https://github.com/grbd/QtSharp.TestApps>

Thanks to <https://github.com/dsoronda> and <https://github.com/grbd>

## Development

If you plan on getting involved with the development of QtSharp <br>
there's some notes associated with development included below.

  * [Development Notes](https://github.com/grbd/QtSharp/tree/master/Docs/Development)

## Coverage

QtSharp has been tested only with Qt for MinGW, and with Qt's built-in MinGW set-up, so far.

## Funding

In order to speed up the development of the project, I've been looking for funding.
There are two ways for that.

  * The first one is sponsoring Qt# itself.
  * The second way would be paid assignments related to CppSharp <br>
    For example bindings for other C++ libraries.

Either way is going to immensely benefit Qt#.

