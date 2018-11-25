# BootCheck
Bootdisk check utility for disk images.

BootCheck check any MBR compatible to print out a list of bootable disk images, it currently works with raw floppy disk and hard disk images.

## OS Support
It has been tested on Windows and XUbuntu 18.10 64 bits using

## Mono 4.0
Keep in mind, Mono 4.0 appears to have a bug when colors is in use, if you're using this version, set TERM to xterm this way:
``
TERM=xterm BootCheck.exe {parameters}
``
This doesn't happen on newer 5.0 version of mono, which can be installed [from this link](https://www.mono-project.com/).

## Usage
* BootCheck.exe *file list*
* BootCheck.exe .\images\\\*.img (currently this only works linux bash, since it appears to preprocess inputs to a file-list, while windows doesn't)

## TODO List
* Add support for certain "false positive", whrer there's a small program with the sole purpose of displaying a "This disk is not bootable..." message (quite odd)
* Add support for VDI, VHD and VMDK files (probably even more)
* Add per-partition boot data (MBR and GTP)
* Add Macintosh floppy and hard disk support
* Add support for file patterns, like ***.img**