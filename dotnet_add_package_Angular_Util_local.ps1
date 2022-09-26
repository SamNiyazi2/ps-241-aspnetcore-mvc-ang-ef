# 09/26/2022 09:13 am - SSN - Copied from "C:\Sams_P\DevSitesIndex\DevSitesIndex\dotnet_add_package_DAL_local.ps1"
$erroractionpreference = "stop"

$error.clear()
0..10|%{""}
get-date 
""


. C:\Sams\PS\NuGet\add-nuget-package-util.ps1



$projectName = "$psscriptroot\ps-DutchTreat.csproj"

$packageName = "SSN_Angular_Script_Util"

 add-nugetPackage -projectName $projectName -packageName $packageName

  

   

