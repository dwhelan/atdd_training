﻿# Getting started on a Mac
You shold first open a terminal and `cd` to the `atdd_training/ruby` folder:

```sh
cd <local folder>/atdd_training/ruby
```

## Install HomeBrew
It will help to have `HomeBrew` to install anything that you do not already have installed.
To install `HomBrew` enter the following:

```
/usr/bin/ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)".
```

See [Homebrew](http://brew.sh/) for additional information on installation.

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

***Note***: If you are on El Capitain and you don't have `rvm` or `rbenv` installed
then subsequent install steps may complain aboout not being able to write to the `/usr/local` folder.
To fix this, edit your `~/.gemrc` file and include:

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

You can fix that locally by changing the brew formula
by manually update the `url`, `version` and `sha256` for the formula.
Just replace the existing lines in the file for those settings with:
  
```
  url "https://chromedriver.storage.googleapis.com/2.24/chromedriver_mac64.zip"
  version "2.24"
  sha256 "d4f6e13d88ecf20735138f16ab1545e855a42bce41bebe73667a028871777790"
```
If you would prefer a different editor from the one `brew` defaults to
do the following
```
EDITOR=<path to editor of choice>
export EDITOR                      # => may be necessary depending what shell you are using
brew edit chromedriver
```

You can see the full formula [here](https://github.com/Homebrew/homebrew-core/blob/303660134f72cffaef94f87abfb6bfeedccc0e1c/Formula/chromedriver.rb).

## Update gems
Update local gems using `bundler`:

```sh
bundle install
```

## Run the tests
Once you have successfully installed ruby and cucumber you are ready to [run the tests](./Running-tests.MD).
