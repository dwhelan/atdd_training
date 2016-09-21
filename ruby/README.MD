[![Build Status](https://travis-ci.org/dwhelan/atdd_training.png?branch=master)](https://travis-ci.org/dwhelan/atdd_training)

# Ruby
ATDD training exercises in ruby.

Acceptance tests use [Cucumber](https://cucumber.io/) with
[RSpec](http://rspec.info/). Web tests use the [page-object](https://github.com/cheezy/page-object) gem.

## Getting started
You will need a Ruby installed. The following ruby versions are supported:
  - 1.9.3
  - 2.0.0
  - 2.1.0
  - 2.2.0  
  - 2.2.1
  - 2.2.2
  - 2.2.3
  - 2.3.1

See the [Ruby installation page](https://www.ruby-lang.org/en/documentation/installation/) for installation instructions.

Update dependencies using `bundler`:

```sh
$ cd <local "training" folder>/ruby
$ bundle install
```

The 'cukes', or cucumber features, can be run from the command line:

```sh
$ cucumber
```
The above will execute **all** the features.

If you are working on the `calculator` you can focus on
just those features with the `-t @calculator` option:

```sh
$ cucumber -t @calculator
```

This will prevent the browser from popping up and your features will
execute very quickly.

See the [cucumber wiki](https://github.com/cucumber/cucumber/wiki/Running-Features)
for more command line options or use the command line help:

```sh
$ cucumber -h
```
## Handling Work In Progress
By default the cucumber set up will run all the `cukes`.
A cucumber convention is to use a `@wip` tag to mark scenarios or features that are under construction.

To run all `cukes` that **are** under construction:
```sh
$ cucumber -t @wip
```

To run all `cukes` that **are not** under construction:
```sh
$ cucumber -t ~@wip
```

To run the calculator `cukes` that **are** under construction:
```sh
$ cucumber -t @wip -t @calculator
```

To run the web `cukes` that **are** under construction:
```sh
$ cucumber -t @wip -t @web
```

Once the scenario or feature works, you should remove the `@wip` tag.

# IDE suggestions
For some tips on using some popular IDEs you might to check out:
* [RubyMine](RubyMine.md)
* [Atom](Atom.md)
