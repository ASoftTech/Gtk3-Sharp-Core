#! python3

import re

# Generates a C# Key enum from the Gdk headers (gdkkeysyms.h)
class Gen_Keysyms(object):

    # Class Init
    def __init__(self, src, dest):
        self.Source = src
        self.Destination = dest

    # Parse gdkkeysyms.h into a C# Enum
    def parse(self):
        print ("Generating C# enum for Gdk")
        output = "// Generated File.  Do not modify.\n\n"
        output += "namespace Gdk\n"
        output += "{\n"
        output += "\tpublic enum Key {\n"

        re_srch = re.compile(r'^\W*#define\W+GDK_(\w+)\W+(\w+)\W*$')
        with open(self.Source, "r") as f:
            for line in f:
                line = line.rstrip("\n\r")
                mo = re_srch.search(line)
                if mo:
                    x1 = mo.groups()
                    enumkey, enumval = mo.groups()
                    enumkey = enumkey.replace("KEY_","",1)

                    # keys can't start with a digit
                    if re.match('^\d.*$', enumkey):
                        enumkey = "Key_" + enumkey
                    output += "\t\t" + enumkey + " = " + enumval + ",\n";

        output += "\t}\n"
        output += "}\n"

        with open(self.Destination, "w") as text_file:
            text_file.write(output)
