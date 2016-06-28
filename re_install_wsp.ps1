$wspName = "tarcisio_test.wsp"

$webAppUrl = "http://dev-it/"

$snapin = Get-PSSnapin | Where-Object { $_.Name -eq "Microsoft.SharePoint.Powershell" }
if ($snapin -eq $null) {
    Write-Host "Loading SharePoint Powershell Snapin"
    Add-PSSnapin "Microsoft.SharePoint.Powershell"
}

$isInstalled = Get-SPSolution | where { $_.Name -eq $wspName }
if ($isInstalled)
{       
    $solution = Get-SPSolution | where { $_.Name -match $wspName }
	
	Uninstall-SPSolution -identity $wspName -Confirm:$false    
    
	$job = Get-SPTimerJob | ?{ $_.Name -like "*solution-deployment*$wspName*" }
    $maxwait = 30
    $currentwait = 0

    if (!$job)
    {
        Write-Host -f Red 'Error - Timer job not found'
    }
    else
    {
        $jobName = $job.Name
        Write-Host -NoNewLine "Waiting to finish job $jobName"        
        while (($currentwait -lt $maxwait))
        {
            Write-Host -f Green -NoNewLine .
            $currentwait = $currentwait + 1
            Start-Sleep -Seconds 2
            if (!(Get-SPTimerJob $jobName)){
                break;
            }
        }
    }
	
    Remove-SPSolution -Identity $wspName -Confirm:$false	
}