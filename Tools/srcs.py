#! python3
import os, sys, json, wget, tarfile, glob, patch, logging
import os.path as path
from lib.common import Common

# Script to download API Sources
class Srcs(object):

    # Class Init
    def __init__(self):
        self.Sources = "srcs/sources.json"
        self.Patches = "srcs/patches"
        self.BuildDir = "../Build/Sources/"

        self.BaseDir = path.dirname(path.abspath(__file__))
        self.Sources = path.abspath(path.join(self.BaseDir, self.Sources))
        self.Patches = path.abspath(path.join(self.BaseDir, self.Patches))
        self.BuildDir = path.abspath(path.join(self.BaseDir, self.BuildDir))

    # Clean the Build directory
    def clean(self):
        Common.clean(self.BuildDir)

    # Download the sources for extracting the api information
    def download(self):
        if not path.exists(self.BuildDir):
            os.makedirs(self.BuildDir)

        print("Reading download sources: " + self.Sources)
        with open(self.Sources) as data_file:    
            data = json.load(data_file)
            for item in data["downloads"]:
                print("Downloading sources for: " + item)
                print(data["downloads"][item])
                wget.download(data["downloads"][item], self.BuildDir)
                print('\n')

    # Extract the sources
    def extract(self):
        for file in glob.glob(path.join(self.BuildDir, "*.xz")):
            print("Extracting: " + path.basename(file))
            with tarfile.open(file) as f:
                f.extractall(self.BuildDir)

    # Patch the sources
    def patch(self):
        gtkdir = glob.glob(path.join(self.BuildDir, "gtk+-*"))[0]
        glibdir = glob.glob(path.join(self.BuildDir, "glib-*"))[0]

        patch.logger.setLevel(logging.DEBUG)
        streamhandler = logging.StreamHandler()
        if streamhandler not in patch.logger.handlers:
            patch.logger.addHandler(streamhandler)

        patch1 = patch.fromfile(path.join(self.Patches, "gtk_tree_model_signal_fix.patch"))
        patch1.apply(1, gtkdir)
        patch2 = patch.fromfile(path.join(self.Patches, "gtktextattributes-gi-scanner.patch"))
        patch2.apply(1, gtkdir)
        patch3 = patch.fromfile(path.join(self.Patches, "gwin32registrykey-little-endian.patch"))
        patch3.apply(1, glibdir)

        with open(path.join(gtkdir, "gtk/gtkclipboard.h"), "a") as f:
            f.write('\n')
            f.write("typedef struct _GtkClipboard GtkClipboard;\n")
            f.write("typedef struct _GtkClipboardClass GtkClipboardClass;")

        print ("Patch finished")

    # Print Usage
    def usage(self):
        print ("Please use download_api_srcs.py <target> where <target> is one of")
        print ("  clean          clean the sources directory")
        print ("  download       download the sources")
        print ("  extract        extract the sources")
        print ("  patch          patch the sources")
        print ("  all            clean, download, extract, patch the sources")

    def main(self):
        if len(sys.argv) != 2:
            self.usage()
            return
        if sys.argv[1] == "clean":
            self.clean()
        if sys.argv[1] == "download":
            self.download()
        if sys.argv[1] == "extract":
            self.extract()
        if sys.argv[1] == "all":
            self.clean()
            self.download()
            self.extract()
            self.patch()

if __name__ == "__main__":
    Srcs().main()
