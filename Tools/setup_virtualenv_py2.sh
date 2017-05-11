#! /bin/bash

if [ ! -d "../Build/PythonVirtual/gtksharp_build_py2" ]; then
  echo "Creating virtual environment gtksharp_build_py2"
  virtualenv --python=/usr/bin/python2.7 ../Build/PythonVirtual/gtksharp_build_py2
  source ../Build/PythonVirtual/gtksharp_build_py2/bin/activate
  pip install -r virtualenv/requirements_py2.txt
fi

# Enter the python virtual enviro on the current shell
echo "Entering virtual environment gtksharp_build_py2"
bash --rcfile <(echo '. ../Build/PythonVirtual/gtksharp_build_py2/bin/activate')

# use echo $BASHPID to check the bash prompt process id

