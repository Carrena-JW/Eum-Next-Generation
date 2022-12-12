
#main function
function main(){
    Write-Host -ForegroundColor Green "Start registering the Eum project template."

    #dotnet command vailidation
    $vaildCommand = Get-Command dotnet -ErrorAction SilentlyContinue
    if($vaildCommand.Name -ne "dotnet.exe"){
        Write-Error  "The .NET sdk is not installed. Exit the task."
        return 
    }

    #run script root path
    $runPath = $PSScriptRoot
    $subFolders = Get-ChildItem -Path $runPath -Directory 

    foreach($p in $subFolders){
        Set-Location -Path $p

        #Do not handle exceptions
        Invoke-Command -ScriptBlock {dotnet new uninstall .}
        #Invoke-Command -ScriptBlock {dotnet new install .}
        Write-Host -ForegroundColor Green "Template registration complete : $($p.Name)"
    }

    Write-Host -ForegroundColor Green "Exit registering the Eum project template."
}

## call main functions

main