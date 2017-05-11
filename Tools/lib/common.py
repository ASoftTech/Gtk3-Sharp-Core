import os, subprocess
import os.path as path

# Script to download API Sources
class Common(object):

    # Empty a directory
    @staticmethod
    def emptydir(top):
        if(top == '/' or top == "\\"): return
        else:
            for root, dirs, files in os.walk(top, topdown=False):
                for name in files:
                    os.remove(path.join(root, name))
                for name in dirs:
                    os.rmdir(path.join(root, name))

    # Clean the Build/Generator directory
    @staticmethod
    def clean(cleandir):
        print("Cleaning: " + cleandir)
        Common.emptydir(cleandir)
        print ("Clean finished")

    # Run a command
    @staticmethod
    def run_cmd(cmdarray, workingdir, stdout=subprocess.PIPE, stderr=subprocess.PIPE, stdin=None, printresult=True):
        proc = subprocess.Popen(cmdarray, cwd=workingdir, stdout=stdout, stderr=stderr, stdin=stdin, universal_newlines=True)
        proc_out, proc_err = proc.communicate()
        if printresult:
            print(proc_out)
            print(proc_err)
        if proc.returncode != 0:
            raise RuntimeError("Failure to run command")
        return proc_out, proc_err
