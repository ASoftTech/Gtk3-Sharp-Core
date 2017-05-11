#! python3
import os, sys, subprocess, shutil, json
import wget, tarfile, glob, patch, logging
import os.path as path

# TODO
# Move this into Scons

# GtkSharp Build Script
class Build(object):

    # Class Init
    def __init__(self):
        self.BuildDir = "../../Build/LibBuild/"
        self.SourcesDir = '../../Source/'

        self.BaseDir = path.dirname(path.abspath(__file__))
        self.BuildDir = path.abspath(path.join(self.BaseDir, self.BuildDir))
        self.SourcesDir = path.abspath(path.join(self.BaseDir, self.SourcesDir))

    # Empty a directory
    def emptydir(self, top):
        if(top == '/' or top == "\\"): return
        else:
            for root, dirs, files in os.walk(top, topdown=False):
                for name in files:
                    os.remove(path.join(root, name))
                for name in dirs:
                    os.rmdir(path.join(root, name))

    # Run a command
    def run_cmd(self, cmdarray, workingdir):
        proc = subprocess.Popen(cmdarray, cwd=workingdir, stdout=subprocess.PIPE, stderr=subprocess.PIPE, universal_newlines=True)
        proc_out, proc_err = proc.communicate()
        print(proc_out)
        print(proc_err)
        if proc.returncode != 0:
            raise RuntimeError("Failure to run command")
        return

    # Clean the Build directory
    def clean(self):
        print("Cleaning: " + self.BuildDir)
        self.emptydir(self.BuildDir)
        print ("Clean finished")

    def build_dotnet(self):
        print("Building .Net Core Sources for GtkSharp")
        cmdargs = ['dotnet', 'restore', 'Libs.sln']
        self.run_cmd(cmdargs, path.join(self.SourcesDir))
        cmdargs = ['dotnet', 'build', 'Libs.sln']
        self.run_cmd(cmdargs, path.join(self.SourcesDir))
        print("Build Finished")


    # Print Usage
    def usage(self):
        print ("Please use build.py <target> where <target> is one of")
        print ("  build_dotnet   use dotnet to build the cs sources")
        print ("  clean          clean the libs build directory")
        print ("  all            clean, ")

    def main(self):
        if len(sys.argv) != 2:
            self.usage()
            return
        if sys.argv[1] == "clean":
            self.clean()
        if sys.argv[1] == "build_dotnet":
            self.build_dotnet()
        if sys.argv[1] == "all":
            self.clean()
            self.build_dotnet()

if __name__ == "__main__":
    Build().main()
