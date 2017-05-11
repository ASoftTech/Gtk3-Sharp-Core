# Readme

This is basically a re-write of the GtkSharp Sources for .Net Core

Note this isn't ready yet, and is just a proof of concept

  * For this repo GtkSharp3 is used as a basis from https://github.com/openmedicus/gtk-sharp.git
  * Eventually the libs will target .Net Standard 2.0, for now I'm targeting .Net Core 2.0 just to get things working.
  * The build scripts for the C Glue code and for generating C# code for new versions of GTK have been replaced with python scripts
  * Directories re-arranged to seperate runtime sources, tests, samples, tools for code generation.
  * Docs placed / generated via markdown and mkdocs

Once the C# code is .NetStandard based, this should allow the libs to be also used from the original .Net Framework and the .Net Core framework
Also compilation of the C# code can be done via the dotnet cli tool from .Net core under linux or windows without the need for mono.

The solution and project files were originally created using Visual Studio 2017.
Unlike conventional msbuild project files, the .NetStandard / core ones allow for simpler xml project files where the C# code files don't need to be listed.

The original build scripts for building and upgrading the sources were a combination of Makefiles and perl scripts.
By replacing these with python scripts this makes it easier to run and debug on multiple platforms such as windows without the need for MSYS2
