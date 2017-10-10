ls
$ips = @("192.168.1.90"); # insert your IPs here.
$rpiFolder = "/home/pi/Documents";
$destFolder = "F:\DEV\blog\";
$myPiPassword = Get-Content -Path "F:\DEV\blog\myPiPassword.txt"
Write-Host "`n"
foreach($ip in $ips){
    Write-Host $ip
    $scriptBlock = [scriptblock]::Create("pscp -l pi -pw $myPiPassword pi@$($ip):$($rpiFolder)/*.txt $($destFolder)")
    Invoke-Command -ScriptBlock $scriptBlock
}
Write-Host "`n"
ls
$manual = Get-Content .\rpi1.txt
$automatic = Get-Content .\Raspberry1.txt

Write-Host "`n The files are equal?" $manual.Equals($automatic)