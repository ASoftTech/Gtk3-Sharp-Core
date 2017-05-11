@echo off
SETLOCAL

IF EXIST "virtualenv\gtksharp_build_py3" (
    echo "Entering virtual environment gtksharp_build_py3"
    FOR /F %%i IN ("virtualenv\gtksharp_build_py3\Lib\site-packages") DO set PYTHONPATH=%%~fi
    cmd /k "virtualenv\gtksharp_build_py3\Scripts\activate.bat"

) ELSE (
    echo "Creating virtual environment gtksharp_build_py3"
    SET WORKON_HOME=.\virtualenv
    mkvirtualenv --python=C:\Python35\python.exe gtksharp_build_py3
    cmd /k "virtualenv\gtksharp_build_py3\Scripts\activate.bat & pip install -r virtualenv\requirements_py3.txt"
    FOR /F %%i IN ("virtualenv\gtksharp_build_py3\Lib\site-packages") DO set PYTHONPATH=%%~fi
)

ENDLOCAL