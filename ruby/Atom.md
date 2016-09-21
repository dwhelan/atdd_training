# Atom

## Running features
You can install the `ruby-test` package. It provides syntax highlighting
for your `.feature` files and shortcuts to run tests.

By default it will provide you with
the following shortcuts:
 * `ctrl-cmd-t` will run all features
 * `ctrl-cmd-r` will run the selected feature
 * `ctrl-cmd-t` will run the selected scenario  
 * `ctrl-cmd-x` will toggle the cucumber runner on or off

You may want to adjust the command line arguments to cucumber to exclude tests that are in progress (i.e. are marked with a `@wip`tag):

Cucumber command: Run all features
```
cucumber --color features -t ~@wip
```
Cucumber command: Run features file
```
cucumber --color {relative_path} -t ~@wip
```

## Autocomplete
Installing the `gherkin-autocomplete` package provides some autocomplete support when adding new steps to scenarios.

## Viewing markdown files
Viewing mark down is built-in. All you need to do is enter `ctrl-shift-M`.
