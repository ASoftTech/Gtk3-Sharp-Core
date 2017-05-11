#! /bin/bash

if [ ! -d "../Build/PythonVirtual/gtksharp_build_py3" ]; then
  echo "Creating virtual environment gtksharp_build_py3"
  virtualenv --python=/usr/bin/python3.5 ../Build/PythonVirtual/gtksharp_build_py3
  source ../Build/PythonVirtual/gtksharp_build_py3/bin/activate
  pip install -r virtualenv/requirements_py3.txt
fi

# Enter the python virtual enviro on the current shell
echo "Entering virtual environment gtksharp_build_py3"
bash --rcfile <(echo '. ../Build/PythonVirtual/gtksharp_build_py3/bin/activate')

# use echo $BASHPID to check the bash prompt process id

