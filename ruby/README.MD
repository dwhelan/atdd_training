[![Build Status](https://travis-ci.org/dwhelan/atdd_training.png?branch=master)](https://travis-ci.org/dwhelan/atdd_training)

# Ruby
ATDD training exercises in ruby.

Acceptance tests use [Cucumber](https://cucumber.io/) with
[RSpec](http://rspec.info/). Web tests use the [page-object](https://github.com/cheezy/page-object) gem.

## Getting started (on a Mac)
You shold first open a terminal and `cd` to the `training/ruby` folder:

```sh
cd <local "training" folder>/ruby
```

## Install HomeBrew
It will help to have `HomeBrew` to install anthing that you do not already have instaled. To install `HomBrew` enter the following:

```
/usr/bin/ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)".
```

See [Homebrew](http://brew.sh/) for information on installation.

## Install ruby
You will need a Ruby installed. The following ruby versions are supported:
  - 1.9.3
  - 2.0.0
  - 2.1.0
  - 2.2.0  
  - 2.2.1
  - 2.2.2
  - 2.2.3
  - 2.3.1

Other rubies (except 1.8.x and earlier) will likely work but have not been tested.

You can check if you have a ruby installed and its version by entering:

```
ruby -v
```
You should something like:
```
ruby 1.9.3p551 (2014-11-13 revision 48407) [x86_64-darwin15.6.0]
```

If your version matches one of the versions listed above then you are all set.

If you need to install ruby or you want to run a different version so that you don't
alter your overall system version of ruby then you may want to install `rvm` and use it to configure a local
ruby version:

```
brew install rvm
rvm install 2.3.1
rvm use 2.3.1
```

If you don't want to use `rvm` and need to install `ruby` see the [Ruby installation page](https://www.ruby-lang.org/en/documentation/installation/)
for installation instructions.

***Note***: If you are on El Capitain and you don't have `rvm` or `rbenv` installed then subsequent install steps may complain aboout not being able to write to the `/usr/local` folder. To fix this edit your `~/.gemrc` file and include:
```
gem: --user-install -n/usr/local/bin
```
## Install dependencies

Run the following:

```
brew install chromedriver 
brew install phantomjs

gem install bundler
gem install cucumber
```

### Chromedriver version
`chromedriver` may fail to download.
`2.24` is the *current* version, but brew update may only find `2.23`.

You can fix that locally by changing the brew formula:
```
EDITOR=<editorOfChoice>
brew edit chromedriver
```
to manually update the `url`, `version` and `sha256` for the formula.
Just replace the existing lines in the file for those settings with:
  
```
  url "https://chromedriver.storage.googleapis.com/2.24/chromedriver_mac64.zip"
  version "2.24"
  sha256 "d4f6e13d88ecf20735138f16ab1545e855a42bce41bebe73667a028871777790"
```

See here for the full formula
[here](https://github.com/Homebrew/homebrew-core/blob/303660134f72cffaef94f87abfb6bfeedccc0e1c/Formula/chromedriver.rb)  

Update gems using `bundler`:

```sh
bundle install
```

## Running the tests
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

# IDE suggestions
For some tips on using some popular IDEs you might to check out:
* [RubyMine](RubyMine.md)
* [Atom](Atom.md)
