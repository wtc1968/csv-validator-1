# CSV Validator

[![](https://img.shields.io/github/release/barry-jones/csv-validator.svg)](https://github.com/barry-jones/csv-validator/releases/tag/v0.2.2)

.NET Core CSV text file validator. Enables the quick verification of column separated data files. Columns can be checked against multiple requirements for correctness.

## Usage

The application is command line based, and has two arguments:

``` bash
validate --file "input-datafile.csv" --with "configuration.json"
```

## Configuration

To configure the verification a JSON file is used with the following format:

``` json
{
	"rowSeperator": "\r\n",
	"columnSeperator": ",",
	"columns": {
		"1": {
			"name": "ID",
			"isRequired": true,
			"isUnique": true
		},
		"2": {
			"name": "DOB",
			"pattern": "^\\d\\d\\d\\d-\\d\\d-\\d\\d$"
		},
		"3": {
			"name": "NOTES",
			"maxLength": "250"
		}
	}
}
```

The `pattern` property uses regular expressions but it is important to escape the characters else the application will fail when reading the configuration file.

`rowSeperator` can be any number of characters, rows can also be separated by characters and do not need the new line characters to be available in the input file.

`columnSeperator` can be one or more characters.

The columns require the number, which is the ordinal of the column in the input file, you do not need to specify all columns, only those that are to be validated.

### Supported validation

```
{
    // validates the column has content
    "isRequired": true|false,
    // validates the content is unique in this column across the full file
    "isUnique": true|false,
    // validates a string against a regular expression
    "pattern": "regular expression string",
    // Maximum allowable length for a column
    "maxLength": "int",
    // Check if content is numerical
    "isNumeric": true|false
}
```

