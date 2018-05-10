@echo off
set /p ipaddr="Enter the IP Address for this computer: "
set /p subnet="Enter the Subnet for this computer: "
echo Setting IP Address as %ipaddr% on the subnet %subnet%.
@echo on
IF %subnet%==106 (
	netsh int ip set address "Local Area Connection" static %ipaddr% 255.255.255.0 128.171.106.1
	netsh int ip add dns "Local Area Connection" static 128.171.106.15 index=1
	netsh int ip add dns "Local Area Connection" static 128.171.107.11 index=2
	)
IF %subnet%==107 (
	netsh int ip set address "Local Area Connection" static %ipaddr% 255.255.255.0 128.171.107.1
	netsh int ip add dns "Local Area Connection" static 128.171.107.11 index=1
	netsh int ip add dns "Local Area Connection" static 128.171.106.15 index=2
	)
IF %subnet%==57 (
	netsh int ip set address "Local Area Connection" static %ipaddr% 255.255.255.0 128.171.57.1
	netsh int ip add dns "Local Area Connection" static 128.171.107.11 index=1
	netsh int ip add dns "Local Area Connection" static 128.171.106.15 index=2
	)
IF %subnet%==51 (
	echo 51 subnet.
	)
pause