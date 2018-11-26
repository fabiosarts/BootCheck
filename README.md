# BootCheck
Bootdisk check utility for disk images.

![Screenshot](https://raw.githubusercontent.com/fabiosarts/BootCheck/master/images/screenshot01.png)

BootCheck check any MBR compatible to print out a list of bootable disk images, it currently works with raw floppy disk and hard disk images.

## Executable downloads
* Windows/Linux/Mac (32 and 64 bits) [Mega (link will be unusable by each update)](https://mega.nz/#!kFgCya4A!YOwQlA5nV5-ovi5Sg8uctrKjXcIiLPAGr7XMNVE9sVw)

## OS Support
It has been tested on Windows and lbuntu 18.10 64 bits using Mono

## Mono 4.0
Keep in mind, Mono 4.0 appears to have a bug when colors is in use, if you're using this version, set TERM to xterm this way:
``
TERM=xterm BootCheck.exe {parameters}
``
This doesn't happen on newer 5.0 version of mono, which can be installed [from this link](https://www.mono-project.com/).

## Usage
* BootCheck.exe *file list*
* BootCheck.exe .\images\\\*.img (currently this only works linux bash, since it appears to preprocess inputs to a file-list, while windows doesn't)
* At least on Windows, you can *drag and drop* multiple input files to the exe file [like this](https://raw.githubusercontent.com/fabiosarts/BootCheck/master/images/screenshot02.png)

## TODO List
* Add support for certain "false positive", whrer there's a small program with the sole purpose of displaying a "This disk is not bootable..." message (quite odd)
* Add support for VDI, VHD and VMDK files (probably even more)
* Add per-partition boot data (MBR and GTP)
* Add Macintosh floppy and hard disk support
* Add support for file patterns, like ***.img**

## Outsourced assets
The floppy icon comes from a CC0 icon pack
small-n-flat
============
http://paomedia.github.io/small-n-flat/

![Floppy](https://github.com/fabiosarts/BootCheck/raw/master/BootCheck/floppy.ico)
