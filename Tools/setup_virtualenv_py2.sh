#! /bin/bash

if [ ! -d "virtualenv/gtksharp_build_py2" ]; then
  echo "Creating virtual environment gtksharp_build_py2"
  virtualenv --python=/usr/bin/python2.7 virtualenv/gtksharp_build_py2
  source virtualenv/gtksharp_build_py2/bin/activate
  pip install -r virtualenv/requirements_py2.txt
fi

# Enter the python virtual enviro on the current shell
echo "Entering virtual environment gtksharp_build_py2"
bash --rcfile <(echo '. ./virtualenv/gtksharp_build_py2/bin/activate')

# TODO set PYTHONPATH

# use echo $BASHPID to check the bash prompt process id

