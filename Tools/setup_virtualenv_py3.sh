#! /bin/bash

if [ ! -d "virtualenv/gtksharp_build_py3" ]; then
  echo "Creating virtual environment gtksharp_build_py3"
  virtualenv --python=/usr/bin/python3.5 virtualenv/gtksharp_build_py3
  source virtualenv/gtksharp_build_py3/bin/activate
  pip install -r virtualenv/requirements_py3.txt
fi

# Enter the python virtual enviro on the current shell
echo "Entering virtual environment gtksharp_build_py3"
bash --rcfile <(echo '. ./virtualenv/gtksharp_build_py3/bin/activate')
# TODO set PYTHONPATH

# use echo $BASHPID to check the bash prompt process id

