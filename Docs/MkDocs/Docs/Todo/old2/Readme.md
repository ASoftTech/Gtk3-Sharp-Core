# Readme

## Overview

This directory contains a series of python build scripts to help generating the source code of GtkSharp

## Scripts

### Source Code upgrade scripts

Scripts associated with upgrading the sources to a later version of gtk3

  * download_api_srcs/download_api_srcs.py - download / extract / patch the sources

### Build Scripts

TODO

### Misc directories

  * vs - contains Visual Studio solution and project files for debugging the python scripts
  * virtualenv - all files needed for the creation of a virtual environment


## Setup of Python Virtual Environment

First we need to setup a virtual python environment.
All this does is copy the base python install to a subdirectory, and install needed modules without poluting the global install
If the virtual environment has already been created, then it just enters that already setup env
The required packages are pulled from virtualenv\requirements.txt

Under Windows
```
pip install virtualenvwrapper-win
setup_virtualenv.bat
```

Under Linux
```
pip install virtualenv
setup_virtualenv.sh
```

## TODO

Build scripts
