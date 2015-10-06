NuGet pack ..\source\kasthack.yandex.pdd\kasthack.yandex.pdd.csproj -Prop Configuration=Release -IncludeReferencedProjects
Nuget Push *.nupkg
del *.nupkg
pause