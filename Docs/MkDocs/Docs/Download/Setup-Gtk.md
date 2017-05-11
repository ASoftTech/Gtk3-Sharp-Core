# Downloading Gtk

## Overview

In order to use the GtkSharp C# Bindings we first need to install Gtk itself.


## Linux

For linux usually GTK3 is installed by default
For Ubuntu one approach to get the dev tools / libs / headers is to use
```
sudo apt-get install glade
sudo apt-get install libgtk-3-dev
```


## Windows

Under Windows there are several different approaches to installing Gtk.


### Windows Installer

The first approach is to install Gtk via an msi installer
There's an unoffical one located here

  * https://github.com/tschoonj/GTK-for-Windows-Runtime-Environment-Installer/releases

This includes GTK2 and GTK3 however it's x64 / 64bit only.
This is probably the easiest way to install GTK
However you'll need to make sure the directory it installs to is included within your system path.
GTKSharp will try to find the GTK dll's via the system path or it's local directory.


### NuGet

There are some Nuget packages for the GTK dll's under windows
However these seem largley out of date at the moment.

  * https://www.nuget.org/packages/GtkSharp.Win32/


### Manual Install of GTK via MSYS2

Another approach to get GTK for windows is the use of MSYS2 / MinGW
From what I can tell the dll's bundled with the msi installer above are the same ones from MSYS2

#### Installing MSYS2

  * First install MSYS2 - https://msys2.github.io/
  * Next open up a MSYS2 shell prompt

Run the following to update the package database
```
pacman -Syuu
```

To search for a package
```
pacman -Ss gtk3
```

#### Install of GTK under MSYS2

To install the 64bit dll's / packages
```
pacman -S mingw-w64-x86_64-gcc mingw-w64-x86_64-glib2
pacman -S mingw-w64-x86_64-pango mingw-w64-x86_64-atk mingw-w64-x86_64-gtk3
pacman -S mingw-w64-x86_64-zlib mingw-w64-x86_64-libiconv
```

To install the 32bit dll's / packages
```
pacman -S mingw-w64-i686-gcc mingw-w64-i686-glib2
pacman -S mingw-w64-i686-pango mingw-w64-i686-atk mingw-w64-i686-gtk3
pacman -S mingw-w64-i686-zlib mingw-w64-i686-libiconv
```

#### Dll List

Typically the list of gtk dll's will be something like
```
libatk-1.0-0.dll
libcairo-2.dll
libcairo-gobject-2.dll
libgdk_pixbuf-2.0-0.dll
libgdk-3-0.dll
libgio-2.0-0.dll
libglib-2.0-0.dll
libgmodule-2.0-0.dll
libgobject-2.0-0.dll
libgtk-3-0.dll
libpango-1.0-0.dll
libpangocairo-1.0-0.dll
libpangoft2-1.0-0.dll
libpangowin32-1.0-0.dll
```

The list of depends for the above will be something like
```
libbz2-1.dll
libepoxy-0.dll
libexpat-1.dll
libffi-6.dll
libfontconfig-1.dll
libfreetype-6.dll
libgcc_s_dw2-1.dll
libgraphite2.dll
libharfbuzz-0.dll
libiconv-2.dll
libintl-8.dll
liblzma-5.dll
libpcre-1.dll
libpixman-1-0.dll
libpng16-16.dll
libstdc++-6.dll
libwinpthread-1.dll
libxml2-2.dll
zlib1.dll
```

#### Copy Dll's

At this point you can ether

  * Add to your path the directory where the dll's have been installed into
  * Copy the dll's to another directory on the path (same as the msi installer)
  * Copy the dll's to the build directory of your C# Project (same as a NuGet package)
