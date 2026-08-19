# detect-nuget-inspector 2.6.0 repro — .slnx + NuGet

Minimal reproduction for STGBD bug: `detect-nuget-inspector` 2.6.0 crashes with
`No instances of MSBuild could be detected` when scanning a `.slnx` solution on
a `windows-2022` Azure DevOps agent (VS2022 / MSBuild 17.x).

## Structure

```
SF90.slnx                         ← new XML solution format (replaces .sln)
src/
  SampleApp/SampleApp.csproj      ← Exe; refs Microsoft.Extensions.*, Serilog
  SampleLib/SampleLib.csproj      ← Lib; refs Newtonsoft.Json, NLog, Serilog
```

## NuGet packages (open source)

| Package | Version |
|---------|---------|
| Newtonsoft.Json | 13.0.3 |
| NLog | 5.3.4 |
| Serilog | 3.1.1 |
| Microsoft.Extensions.Logging | 8.0.1 |
| Microsoft.Extensions.DependencyInjection | 8.0.1 |
| Serilog.Extensions.Logging | 8.0.0 |

## Expected Black Duck behavior

- **detect-nuget-inspector 2.6.0**: crashes — `Microsoft.Build.Locator` 1.4.1
  cannot enumerate VS2022 instances; fallback NuGet scanner ignores `*.slnx`
  (only scans `*.sln` / `*.csproj`)
- **Fixed version**: should resolve all 6 packages into the BOM
