@echo off
set /p ipaddr="Enter the IP Address for this computer: "
echo Setting IP Address as %ipaddr% on the subnet 106.
netsh int ip set address "Local Area Connection" static %ipaddr% 255.255.255.0 128.171.106.1
netsh int ip delete dns "Local Area Connection" all
netsh int ip add dns "Local Area Connection" 128.171.106.15 validate=no
netsh int ip add dns "Local Area Connection" 128.171.107.11 validate=no
pause