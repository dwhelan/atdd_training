# Ruby

Training exercises and katas in ruby. The exercises were written in Ruby 2.3.1 but should work with Ruby 2.0 or later.

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
 
 See the [cucumber wiki](https://github.com/cucumber/cucumber/wiki/Running-Features) for command line options.
 
## Additional Tools
The following tools are not required but are recommended.

### RubyMine
[RubyMine](https://www.jetbrains.com/ruby/) is recommended due to its excellent refactoring and test support.
If you don't have RubyMine installed you can download a 30 day trial version [here](https://www.jetbrains.com/ruby/download/).

#### Running tests from the IDE
Within RubyMine you can right click on any `.feature` file and select `Run...`.
#### Markdown support
To view the kata descriptions it is recommended that you install the 'Markdown Support' RubyMine plugin.
Refer to the [Enabling and Disabling Plugins](https://www.jetbrains.com/help/webstorm/2016.2/enabling-and-disabling-plugins.html) if you need help with this.
