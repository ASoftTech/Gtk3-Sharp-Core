# Generating Sources

## Overview

When moving between different versions of GTK, one of the steps we need to perform is an update to the sources.
If all you want to do is build Gtk#, then you can ignore what's in this section.

This section is not part of the normal build process for Gtk#.
But is instead used by people wishing to update an existing .NET binding

The original GTKSharp scripts were a combination of C# and perl and make files.

  * <http://www.mono-project.com/GAPI>


## Differences to the original GtkSharp

  * The main difference is that the .Net code is compiled to use .Net Core which is the next generation of the .Net framework <br>
    Once .Net 2.0 is released fully we should be able to move the library from just .Net Core only to .Net Standard. <br>
    This should allow the compiled libraries to be used on all the different frameworks such as: <br>
    .Net Original framework (mono), .Net Core (no mono) <br>
    <https://docs.microsoft.com/en-us/dotnet/articles/standard/library>

  * Most of the build scripts have been transitioned from Makefiles and perl to python. <br>
    The general idea is to allow for compiling on different platforms without the need for MSYS under windows. <br>
    Also python is generally easier to debug / step through with something like PyCharm or Visual Studio with python tools.

  * The scripts which handle parsing have been left as perl due to the speed benifits (and complexity of the scripts) <br>
    However for the sake of convienience they have also been pre-compiled to windows exe's to make the source easier to generate on a windows platform.

  * The generation of code is now a lot easier to follow and run in terms of automation.


## Notes

  * At the time of writing any .Net Core CS code is handled via a Visual Studio 2017 Solution / Project. <br>
  * The python scripts can be optionally debugged with Visual Studio 2015 with python tools via the solutions within the **vspython** directory. <br>
    Once VS2017 has python tools support we can move across to that.
  * Due to the increased number of API's I'm currently using a unreleased version of .Net Core 2.0, although the official preview may be released by the time
    I've finished writing these docs


## General build process

There are several steps as part of the update process

  * Setup the virtual environment for python
  * Download / Extract / Patch the sources to extract the api information
  * Run the parser to generate various '*-api.raw' XML files
  * Run the generator to turn the raw files into C# code
  * Use the Build process to:
    * Turn the C# code into compiled .Net Core dll libraries
    * Build the glue libraries for the specific platform
    * Generate the NuGet packages
