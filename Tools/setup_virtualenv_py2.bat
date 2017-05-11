@echo off
SETLOCAL

IF EXIST "..\Build\PythonVirtual\gtksharp_build_py2" (
    echo "Entering virtual environment gtksharp_build_py2"
    cmd /k "..\Build\PythonVirtual\gtksharp_build_py2\Scripts\activate.bat"
    FOR /F %%i IN ("..\Build\PythonVirtual\gtksharp_build_py2\Lib\site-packages") DO set PYTHONPATH=%%~fi

) ELSE (
    echo "Creating virtual environment gtksharp_build_py2"
    SET WORKON_HOME=..\Build\PythonVirtual
    mkvirtualenv --python=C:\Python27\python.exe gtksharp_build_py2
    cmd /k "..\Build\PythonVirtual\gtksharp_build_py2\Scripts\activate.bat & pip install -r virtualenv\requirements_py2.txt"
    FOR /F %%i IN ("..\Build\PythonVirtual\gtksharp_build_py2\Lib\site-packages") DO set PYTHONPATH=%%~fi
)

ENDLOCAL