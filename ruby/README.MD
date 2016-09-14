# Ruby

ATDD training exercises in ruby. The exercises were written in Ruby 2.3.1 but should work with Ruby 2.0 or later.

Acceptance tests use [Cucumber](https://cucumber.io/) with
[RSpec](http://rspec.info/).

## Getting started
You will need a Ruby installed. See the [Ruby installation page](https://www.ruby-lang.org/en/documentation/installation/)for installation instructions.

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

If you want to run 
## Additional Tools
The following tools are not required but are recommended.

### RubyMine
[RubyMine](https://www.jetbrains.com/ruby/) is recommended due to its excellent refactoring and test support.
If you don't have RubyMine installed you can download a 30 day trial version [here](https://www.jetbrains.com/ruby/download/).

#### Running tests from the IDE
Within RubyMine you can right click on any `.feature` file and select `Run...`.
#### Markdown support
To view the kata descriptions it is recommended that you install the **Markdown support** RubyMine plugin.
Refer to [Enabling and Disabling Plugins](https://www.jetbrains.com/help/webstorm/2016.2/enabling-and-disabling-plugins.html) if you need help with this.
