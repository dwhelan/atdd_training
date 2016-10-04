# Running the tests
The 'cukes', or cucumber features, can be run from the command line:

```sh
cucumber
```
The above will execute **all** the features.

If you are working on the `calculator` you can focus on
just those features with the `-t @calculator` option:

```sh
cucumber -t @calculator
```

This will prevent the browser from popping up and your features will
execute very quickly.

See the [cucumber wiki](https://github.com/cucumber/cucumber/wiki/Running-Features)
for more command line options or use the command line help:

```sh
cucumber -h
```
## Handling Work In Progress
By default the cucumber set up will run all the `cukes`.
A cucumber convention is to use a `@wip` tag to mark scenarios or features that are under construction.

To run all `cukes` that **are** under construction:
```sh
cucumber -t @wip
```

To run all `cukes` that **are not** under construction:
```sh
cucumber -t ~@wip
```

To run the calculator `cukes` that **are** under construction:
```sh
cucumber -t @wip -t @calculator
```

To run the web `cukes` that **are** under construction:
```sh
cucumber -t @wip -t @web
```

Once the scenario or feature works, you should remove the `@wip` tag.
