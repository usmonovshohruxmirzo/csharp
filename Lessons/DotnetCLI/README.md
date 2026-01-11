## Basic commands

### `dotnet new`

Creates a new project/solution from a template.
Examples: console app, web API, class library.

### `dotnet restore`

Downloads and restores NuGet packages listed in the project.

### `dotnet build`

Compiles the project without running it.

### `dotnet publish`

Builds and prepares the app for deployment (outputs runnable files).

### `dotnet run`

Builds **and runs** the application.

### `dotnet test`

Runs unit tests using a test framework (xUnit, NUnit, MSTest).

### `dotnet vstest`

Runs tests using the VSTest console runner (advanced test scenarios).

### `dotnet pack`

Creates a NuGet package (`.nupkg`) from the project.

### `dotnet clean`

Deletes build output (`bin/`, `obj/`).

### `dotnet sln`

Creates and manages solution (`.sln`) files.

### `dotnet help`

Shows help for commands.

### `dotnet store`

Stores packages in a runtime package store (mostly obsolete).

### `dotnet watch`

Watches files and automatically rebuilds/restarts on changes.

### `dotnet format`

Automatically formats code (C#, F#, VB) using .NET analyzers.

## Project modification commands

### `dotnet package add`

Adds a NuGet package reference to a project.

### `dotnet package download`

Downloads NuGet packages without adding them to a project.

### `dotnet package list`

Lists packages used by the project.

### `dotnet package remove`

Removes a package reference.

### `dotnet package search`

Searches NuGet packages.

### `dotnet package update`

Updates packages to newer versions.

### `dotnet project convert`

Converts old project formats to SDK-style projects.

### `dotnet reference add`

Adds a project-to-project reference.

### `dotnet reference list`

Lists project references.

### `dotnet reference remove`

Removes a project reference.

## NuGet commands

### `dotnet nuget delete`

Deletes a package version from a NuGet server.

### `dotnet nuget locals`

Manages NuGet cache locations (http-cache, global-packages).

### `dotnet nuget push`

Uploads a NuGet package to a feed.

### `dotnet nuget add source`

Adds a new NuGet source (feed).

### `dotnet nuget disable source`

Disables a NuGet source.

### `dotnet nuget enable source`

Enables a NuGet source.

### `dotnet nuget list source`

Lists all configured NuGet sources.

### `dotnet nuget remove source`

Removes a NuGet source.

### `dotnet nuget update source`

Updates an existing NuGet source.

### `dotnet nuget verify`

Verifies signed NuGet packages.

### `dotnet nuget trust`

Manages trusted package signers.

### `dotnet nuget sign`

Signs NuGet packages.

### `dotnet nuget why`

Explains **why** a dependency exists (dependency graph).

## Workload management commands

> Workloads = mobile, MAUI, Android, iOS, WASM, etc.

### `dotnet workload`

Base command for managing workloads.

### `dotnet workload clean`

Cleans unused workload packs.

### `dotnet workload config`

Manages workload configuration settings.

### `dotnet workload install`

Installs workloads.

### `dotnet workload history`

Shows workload installation history.

### `dotnet workload list`

Lists installed workloads.

### `dotnet workload update`

Updates workloads.

### `dotnet workload restore`

Restores workloads defined in a project.

### `dotnet workload repair`

Fixes broken workloads.

### `dotnet workload uninstall`

Removes workloads.

### `dotnet workload search`

Searches available workloads.

## Advanced commands

### `dotnet sdk check`

Checks installed SDK versions and update status.

### `dotnet msbuild`

Runs MSBuild directly (low-level build control).

### `dotnet build-server`

Manages background build servers (Razor, MSBuild).

### `dotnet dev-certs`

Manages HTTPS development certificates.

### `dotnet install script`

Installs .NET SDK or runtime via script (CI / automation).

## Tool management commands

> Tools = global/local CLI utilities

### `dotnet tool install`

Installs a .NET CLI tool.

### `dotnet tool list`

Lists installed tools.

### `dotnet tool update`

Updates tools.

### `dotnet tool restore`

Restores tools from `dotnet-tools.json`.

### `dotnet tool run`

Runs a local tool.

### `dotnet tool uninstall`

Removes a tool.

### `dotnet tool search`

Searches available tools.
