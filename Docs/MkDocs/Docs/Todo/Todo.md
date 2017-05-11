# TODO

## Glue Libs

  * we need to seperate the build for the cs and glue libs
    scons all, scons gluelibs, scons cs

  * Build Glue Libs via Scons
    generated code contains dll references to the glue dll's
    check msys build for gcc options etc
  * Double check the output from the generator for missing glue libs that are needed


  * SCons will hopefully move to python3 soon, once that happens we need to move to just a python3 only setup

## Python Scripts

  * Script to build libs via dotnet cli app
  * Script to setup virtual python environment under linux
  * Script to generate nuget packages as part of the build script

## Libs

  * Tidy up old files
  * Look at todo apps

## Docs

  * python3 used for updating srcs, since py2 doesnt support decompressing xz files
  * python2 used for building sources since SCons currently only supports python2

  * Add Blog entry on setting up .Net Core 2.0 prior to release
  * Blog entry on GtkSharp

## .Net Core 2.0

  * Once .Net Core 2.0 preview is out properly, try transitioning the libs from netcoreapp2.0 to netstandard2.0
  * Also remove the following from all .csproj files including the generator under Tools once .Net Core 2.0 is out
    <RuntimeFrameworkVersion>2.0.0-preview2-002093-00</RuntimeFrameworkVersion>

## Linux

  * Try setting up a Vagrant VM Image for testing
  * Try testing the .Net Core libs on the Rpi
