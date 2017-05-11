# Generating Code

## Run the Parser

Next we need to run the parser, this looks at the downloaded sources and generates several .raw files
```
Tools\parser.py all
```

## Running the Generator

Next we need to run the generator, this looks at the output from the parser and generates the .Net code and glue C files.
Then copies these files across to the Source directory
```
Tools\generator.py all
```

