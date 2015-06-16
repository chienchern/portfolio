## Overview
A selection of the side projects I've worked on.

## Desktop Client
A .NET Winforms Client written in C#. Goals:
- Automated UI testing from NUnit
- A few simple NUnit tests using Moq
- Simple MVVM with some navigation

To run:
- Open up DesktopClient.sln
- Build the solution ([NuGet must be allowed to download missing packages during the build](https://goo.gl/0GNygm)).
- Run `AutomationTests` for automated UI tests, or the classes under `DesktopClient.Tests.Unit` for unit tests.
- Of course, you can also run the Desktop Client with `F5`, but it isn't much to look at since aesthetics wasn't a goal here. :smile:
