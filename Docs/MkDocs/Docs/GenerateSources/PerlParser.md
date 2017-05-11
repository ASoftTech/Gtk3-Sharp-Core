# Perl Parser

## Overview

As part of the parsing process there are a couple of perl scripts used to parse the .c / .h source code into .raw files
These scripts are typically used as part of GAPI in the original GtkSharp.

Perl is fairly common on posix / linux / unix based operating systems.
However for windows it's typically only seen if installed as part of a full perl development setup.

For the sake of convenience **gapi_pp.pl** and **gapi2xml.pl** have been pre-compiled into self contained exe's.
The python build scripts will typically use the .pl files under linux and the .exe files under windows.


## Perl script modifications

The original gapi_pp.pl perl script used to take a series of arguments, where each argument would be a seperate file to parse.
This works fine under a posix environment, however under windows there's a limit to the number of command line arguments that can be passed.
To get around this the script has been modified to instead read a single text file and loop over each line as a file path to read in as the input.


## Re-compiling perl scripts

If for any reason there needs to be a change to the perl scripts then to re-compile these under windows to exe's

  * Download 64bit portable perl from <br>
    http://strawberryperl.com/releases.html <br>
    I'm using version 5.24.1.1
 
  * Run the batch file to start a perl prompt <br>
    portableshell.bat
    
  * install the **Par-Packer** and **xml** perl packages
```
cpan install PAR::Packer
cpan install XML::LibXML
```

  * run pp agaist the perl scripts from the perl command line
```
pp -o gapi_pp.exe gapi_pp.pl
pp -o gapi2xml.exe --link=libxml2-2__.dll --link=libiconv-2__.dll --link=liblzma-5__.dll --link=zlib1__.dll gapi2xml.pl
```
