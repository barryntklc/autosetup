nbtstat -R
nbtstat -RR
netsh int ip reset all
netsh int ip delete dnsservers "Local Area Connection" all
netsh int ipv4 reset
netsh int ipv4 delete dnsservers "Local Area Connection" all
netsh int ipv6 reset
netsh int ipv6 delete dnsservers "Local Area Connection" all
netsh winsock reset
net user administrator /active:yes
pause
shutdown -r -t 0