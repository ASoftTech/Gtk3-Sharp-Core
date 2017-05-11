# Todo

## glib-sharp.dll.config.in

From what I can tell this file is ignored by windows, but taken notice of via mono
it substitutes the dll names under linux with .so / .a etc
Need to look at how this works under core

  * https://github.com/dotnet/corefx/issues/7683

## Makefile.am

Original Linux build system script
