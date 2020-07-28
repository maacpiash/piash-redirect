# Redirection handler for [pia.sh](http://pia.sh)

[![Hosted on Heroku](https://img.shields.io/badge/Website-Hosted-brightgreen?logo=heroku&style=flat-square)](http://pia.sh)
[![macOS Build Status](https://img.shields.io/github/workflow/status/maacpiash/piash-redirect/macOS?label=macOS&logo=apple&style=flat-square)](https://github.com/maacpiash/piash-redirect/actions?query=workflow%3AmacOS)
[![Ubuntu Build Status](https://img.shields.io/github/workflow/status/maacpiash/piash-redirect/Ubuntu?label=Ubuntu&logo=Ubuntu&style=flat-square)](https://github.com/maacpiash/piash-redirect/actions?query=workflow%3AUbuntu)
[![Windows Build Status](https://img.shields.io/github/workflow/status/maacpiash/piash-redirect/Windows?label=Windows&logo=Microsoft&style=flat-square)](https://github.com/maacpiash/piash-redirect/actions?query=workflow%3AWindows)
[![Codecov](https://img.shields.io/codecov/c/gh/maacpiash/piash-redirect.svg?logo=codecov&style=flat-square)](https://codecov.io/gh/maacpiash/piash-redirect)
[![.NET Core 3.1 (LTS)](https://img.shields.io/badge/Core-v3.1%20(LTS)-5C2D91.svg?logo=.net&style=flat-square)](https://dotnet.microsoft.com/download/dotnet-core/3.1)
[![PRs welcome!](https://img.shields.io/badge/PRs-Welcome-3DA639.svg?logo=github&style=flat-square)](https://github.com/maacpiash/piash-redirect/compare)

## Technical details

- Framework: ASP.NET Core
  - One [model class](src/Shortcut.cs)
  - One [service class](src/ShortcutService.cs)
- Database: MongoDB
  - Hosted on [Atlas](https://www.mongodb.com/cloud/atlas), free tier.
