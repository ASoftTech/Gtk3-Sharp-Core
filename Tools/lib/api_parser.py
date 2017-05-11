#! python3

import glob, os, subprocess, sys
import os.path as path
from lxml import etree
from lib.common import Common

# Generates raw file for parsing the API
class Api_Parser(object):

    # Class Init
    def __init__(self, srcxmlfile, srcsdir, parserdir):
        self.SrcXmlFile = srcxmlfile
        self.SrcsDir = srcsdir
        self.ParserDir = parserdir
        self.ApiList = []

        self.Gapi_PP = "../parser/perl/gapi_pp"
        self.Gapi2_XML = "../parser/perl/gapi2xml"
        self.BaseDir = path.dirname(path.abspath(__file__))
        self.Gapi_PP = path.abspath(path.join(self.BaseDir, self.Gapi_PP))
        self.Gapi2_XML = path.abspath(path.join(self.BaseDir, self.Gapi2_XML))

    # Read in the list of API's we need to process from the sources.xml file
    def readxml(self):
        self.ApiList = []
        with open(self.SrcXmlFile, 'r') as f:
            xmlstr = f.read()
        xml_root = etree.fromstring(xmlstr)
        if not (xml_root.tag == 'gapi-parser-input'):
            raise ValueError('root tag shoul be gapi-parser-input')

        for xml_api in xml_root:
            if xml_api.tag != 'api':
                continue
            api_item = Api_Instance(xml_api, self.SrcsDir)
            self.ApiList.append(api_item)

    def process_ns(self):
        for api_item in self.ApiList:
            for api_lib in api_item.ApiLibs:
                for api_ns in api_lib.Namespaces:
                    self.generate_pp(api_item, api_lib, api_ns)
                    self.generate_raw(api_item, api_lib, api_ns)

    def generate_pp(self, api_item, api_lib, api_ns):
        filelist = api_ns.getfiles()
        plsuffix = '.pl'
        if sys.platform == "win32": plsuffix = '.exe'

        # Run gapi_pp.pl
        print("Running gapi_pp for " + api_lib.Name)
        cmdargs = [self.Gapi_PP + plsuffix]
        pp_out = path.join(self.ParserDir, api_item.OutFile)
        with open(pp_out + ".gapi_pp.in", "w") as out:
            for item in filelist:
                out.write(item + '\n')
        cmdargs.append(pp_out + ".gapi_pp.in")
        with open(pp_out + ".gapi_pp.out", "wb") as out, open(pp_out + ".gapi_pp.err" ,"wb") as err:
            Common.run_cmd(cmdargs, self.SrcsDir, out, err, None, False)

    def generate_raw(self, api_item, api_lib, api_ns):
        rawout = path.join(self.ParserDir, api_item.OutFile)
        plsuffix = '.pl'
        if sys.platform == "win32": plsuffix = '.exe'

        # Run gapi2xml.pl
        # gapi2xml.pl appends but doesn't replace the rawout file
        cmdargs = [self.Gapi2_XML + plsuffix]
        cmdargs.append(api_ns.Name)
        cmdargs.append(rawout)
        cmdargs.append(api_lib.Name)

        out = open(rawout + ".gapi_raw.out", "wb")
        err = open(rawout + ".gapi_raw.err" ,"wb")
        inp = open(rawout + ".gapi_pp.out" ,"rb")
        Common.run_cmd(cmdargs, self.SrcsDir, out, err, inp, False)
        inp.close()
        err.close()
        out.close()

        # Cleanup temp files
        os.remove(rawout + ".gapi_raw.out")
        os.remove(rawout + ".gapi_raw.err")
        os.remove(rawout + ".gapi_pp.out")
        os.remove(rawout + ".gapi_pp.err")
        os.remove(rawout + ".gapi_pp.in")

        # Format the XML
        with open(rawout, 'r') as f:
            xmlstr = f.read()
        root = etree.fromstring(xmlstr)
        with open(rawout, 'wb') as f:
            et = etree.ElementTree(root)
            et.write(f, pretty_print=True)

# Represents a single API instance within the sources.xml file
class Api_Instance(object):

    # Class Init
    def __init__(self, xml_api, srcsdir):
        self.OutFile = xml_api.get("filename")
        self.PreFile = self.OutFile + ".pre"
        self.ApiLibs = []
        for xml_lib in xml_api:
            if xml_lib.tag != 'library':
                continue
            lib_item = Api_Lib(xml_lib, srcsdir)             
            self.ApiLibs.append(lib_item)

## Represents a single API lib within Api_Instance
class Api_Lib(object):

    # Class Init
    def __init__(self, xml_lib, srcsdir):
        self.Name = xml_lib.get("name")
        self.Namespaces = []
        for xml_ns in xml_lib:
            if xml_ns.tag != 'namespace':
                continue
            ns_item = Api_Namespace(xml_ns, srcsdir)             
            self.Namespaces.append(ns_item)

## Represents a single API lib within Api_Instance
class Api_Namespace(object):

    # Class Init
    def __init__(self, xml_ns, srcsdir):
        self.Name = xml_ns.get("name")
        self.SrcsDir = srcsdir
        self.Files = []
        self.Excludes = []
        self.readxml(xml_ns)

    def getfiles(self):
        ret = []
        for item in self.Files:
            if item in self.Excludes:
                continue
            ret.append(item)
        return ret

    def readxml(self, xml_ns):
        for section in xml_ns:

            if section.tag == 'dir':
                dir = section.text
                print("<dir {0}>".format(dir))
                glob1 = glob.glob(path.join(self.SrcsDir, dir, '*.c'))
                for item in glob1:
                    self.Files.append(item)
                glob1 = glob.glob(path.join(self.SrcsDir, dir, '*.h'))
                for item in glob1:
                    self.Files.append(item)
                continue

            if section.tag == 'file':
                incfile = section.text
                print("<file {0}>".format(incfile))
                self.Files.append(path.join(self.SrcsDir, incfile))
                continue

            if section.tag == 'exclude':
                exfile = section.text
                print("<exclude {0}>".format(exfile))
                self.Excludes.append(path.join(self.SrcsDir, exfile))
                continue

            if section.tag == 'directory':
                dir_path = section.get("path")
                dir_path = dir_path.replace('/', os.path.sep)
                print("<directory {0}: excluding ".format(dir_path))

                excludes = []
                for excl_xml in section:
                    if excl_xml.tag != 'exclude':
                        continue
                    print("   " + excl_xml.text)
                    excludes.append(excl_xml.text)

                glob1 = glob.glob(path.join(self.SrcsDir, dir_path, '*.c'))
                for item in glob1:
                    filename = path.basename(item)
                    if filename in excludes:
                        continue
                    self.Files.append(item)

                glob1 = glob.glob(path.join(self.SrcsDir, dir_path, '*.h'))
                for item in glob1:
                    filename = path.basename(item)
                    if filename in excludes:
                        continue
                    self.Files.append(item)

                print("> ")
                continue

            print('Invalid source: ' + section.tag)
