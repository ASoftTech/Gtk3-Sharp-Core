# Download of API Sources


## Setup of Python Virtual Environment

First we need to setup a virtual python environment.
All this does is copy the base python install to a subdirectory, and install needed modules without poluting the global install

Under Windows
```
pip install virtualenvwrapper-win
Tools\setup_virtualenv_py3.bat
```

Under Linux
```
pip install virtualenv
Tools/setup_virtualenv_py3.sh
```

Python 3 is being used for the generator scripts (due to support for xz files) <br>
The Scons build still uses python 2, but this should change hopefully fairly soon.


## Download of API Sources

Next we're going to download the gtk / other lib sources that we're going to extract the api information from


### Updating sources.json

One of the first steps you'll want to do is to update the file **Tools/srcs/sources.json** <br>
The versions of the source code here should match the version of gtk3 / other libs being used

For windows assuming if your using MSYS2 to install gtk3 / cairo etc <br>
It's possible to use pacman to determine which version is installed via pacman's search method
```
pacman -Ss gtk3
```

### Check Patches

It's possible that some of the patches might not work with newer versions of glib or gtk3. <br>
If not then you may need to create some new ones manually using diff / patch etc. <br>
The location for the patches is under **Tools/srcs/patches**


### Run download script

Finally we need to download the source code using the python script
```
Tools/srcs.py all
```

This should perform the following steps

  * Clean the directory Build\Sources
  * Download the source archive files
  * Extract the archives into Build\Sources
  * Patch the sources
