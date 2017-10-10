#!/bin/bash
FLAG="/path/to/log/getMacAddress.log"
if [ ! -f $FLAG ]; then
    echo "Getting Mac address"
    ifconfig eth0 | grep -Po 'HWaddr \K.*$' > "/path/to/destinationFile/$(cat /etc/hostname).txt"
    touch $FLAG
fi