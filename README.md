# Redirection software for [pia.sh](https://pia.sh)

[![Website](https://img.shields.io/website?down_color=red&logo=heroku&style=flat-square&up_color=deepgreen&url=https%3A%2F%2Fpiash-redirect.herokuapp.com/)](https://piash-redirect.herokuapp.com/)
[![.NET Core 3.1 (LTS)](https://img.shields.io/badge/Core-v3.1%20(LTS)-5C2D91.svg?logo=.net&style=flat-square)](https://dotnet.microsoft.com/download/dotnet-core/3.1)
[![Dependency status](https://img.shields.io/librariesio/github/maacpiash/piash-redirect?logo=nuget&style=flat-square)](https://libraries.io/github/maacpiash/piash-redirect)
[![License](https://img.shields.io/github/license/maacpiash/piash-redirect?logo=open-source-initiative&style=flat-square)](https://github.com/maacpiash/piash-redirect/blob/master/LICENSE)
[![PRs welcome!](https://img.shields.io/badge/PRs-Welcome-3DA639.svg?logo=github&style=flat-square)](https://github.com/maacpiash/piash-redirect/compare)

## Technical details

- Framework: ASP.NET Core
  - One [model class](src/Shortcut.cs)
  - One [service class](src/ShortcutService.cs)
- Database: MongoDB
  - Hosted on [Atlas](https://www.mongodb.com/cloud/atlas), free tier
