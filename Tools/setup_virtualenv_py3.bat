@echo off
SETLOCAL

IF EXIST "..\Build\PythonVirtual\gtksharp_build_py3" (
    echo "Entering virtual environment gtksharp_build_py3"
    cmd /k "..\Build\PythonVirtual\gtksharp_build_py3\Scripts\activate.bat"
    FOR /F %%i IN ("..\Build\PythonVirtual\gtksharp_build_py3\Lib\site-packages") DO set PYTHONPATH=%%~fi

) ELSE (
    echo "Creating virtual environment gtksharp_build_py3"
    SET WORKON_HOME=..\Build\PythonVirtual
    mkvirtualenv --python=C:\Python35\python.exe gtksharp_build_py3
    cmd /k "..\Build\PythonVirtual\gtksharp_build_py3\Scripts\activate.bat & pip install -r virtualenv\requirements_py3.txt"
    FOR /F %%i IN ("..\Build\PythonVirtual\gtksharp_build_py3\Lib\site-packages") DO set PYTHONPATH=%%~fi
)

ENDLOCAL