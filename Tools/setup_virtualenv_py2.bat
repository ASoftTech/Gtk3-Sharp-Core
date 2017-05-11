@echo off
SETLOCAL

IF EXIST "virtualenv\gtksharp_build_py2" (
    echo "Entering virtual environment gtksharp_build_py2"
    FOR /F %%i IN ("virtualenv\gtksharp_build_py2\Lib\site-packages") DO set PYTHONPATH=%%~fi
    cmd /k "virtualenv\gtksharp_build_py2\Scripts\activate.bat"

) ELSE (
    echo "Creating virtual environment gtksharp_build_py2"
    SET WORKON_HOME=.\virtualenv
    mkvirtualenv --python=C:\Python27\python.exe gtksharp_build_py2
    cmd /k "virtualenv\gtksharp_build_py2\Scripts\activate.bat & pip install -r virtualenv\requirements_py2.txt"
    FOR /F %%i IN ("virtualenv\gtksharp_build_py2\Lib\site-packages") DO set PYTHONPATH=%%~fi
)

ENDLOCAL