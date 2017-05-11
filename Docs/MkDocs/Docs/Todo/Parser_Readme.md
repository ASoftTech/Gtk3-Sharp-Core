# Readme

## TODO


### Parser build

The original parser build was
```
./autogen.sh --prefix=/tmp/install
cd parser
make clean
make
```

### Update sources.xml

we may need to create a script to update the directory locations within sources.xml


### Run Parser

The main entry point is to call the csharp code with sources.xml as a parameter

The end result should be

  * gdk/gdk-api.raw
  * gio/gio-api.raw
  * gtk/gtk-api.raw
  * pango/pango-api.raw



### Generate the API Code from the XML Files

TODO the next step after the parser is to use
generator/gapi_codegen.exe on each of the xml files to generate the .cs code within the generated sub directories
