# PDGAApi.Net
This is an unofficial package for accessing the [PDGA API](https://www.pdga.com/dev/api/rest/v1/services).  In order to use this, you must have an API login from the PDGA.  API logins can be found at [this location](https://www.pdga.com/dev).

[![.NET](https://github.com/SpyderHunter03/PDGAApi.Net/actions/workflows/dotnet.yml/badge.svg?branch=master)](https://github.com/SpyderHunter03/PDGAApi.Net/actions/workflows/dotnet.yml)

## Features
* Player Search
* Player Statistics Search
* Course Search
* Event Search

## Demo
* Get Player Information (Player Search)
```
using var service = new PDGA(new PDGARestConfig
{
    UserName = userName,
    Password = password
});

var resp = await service.PlayerSearchAsync(new PlayerSearchParameters
{
    PDGANumber = pdgaNumber
});
```

* Get Player Statistics (Player Statistics)
```
using var service = new PDGA(new PDGARestConfig
{
    UserName = userName,
    Password = password
});

var resp = await service.PlayerStatisticsAsync(new PlayerStatisticsParameters
{
    PDGANumber = pdgaNumber
});
```

* Get Event Information (Event Search)
```
using var service = new PDGA(new PDGARestConfig
{
    UserName = userName,
    Password = password
});

var resp = await service.EventSearchAsync(new EventSearchParameters
{
    TournamentId = tournamentId
});
```

* Get Course Information (Course Search)
```
using var service = new PDGA(new PDGARestConfig
{
    UserName = userName,
    Password = password
});

var resp = await service.CourseSearchAsync(new CourseSearchParameters
{
    CourseId = courseId
});
```

For all parameter objects, you can pass in 1 value or many and it will filter down the total number of results.  For all the values that you can pass in to the parameters objects and the values returned in the response objects, visit the [PDGA API page](https://www.pdga.com/dev/api/rest/v1/services).
