# _F1 Driver API_

#### By _**Marcus Kyung**_
#### _API to get 2023 Formula 1 driver and team information and statistics, built with C#, ASP.NET Core, and MySQL_

<br />

<img src="https://media4.giphy.com/media/WQ5S4IrhieIetExlL1/giphy.gif?cid=ecf05e47hhgh5mvowd5jg0q7yqgsjmj2r4oplzpr5gbtlx0u&ep=v1_gifs_search&rid=giphy.gif&ct=g" width="200"/>

<br />

## Contents
* [Description](#description)
* [Setup & installation](#setupinstallation-requirements)
* [Endpoints](#endpoints)
* [Optional Query Parameters](#optional-query-string-parameters)
* [Example Get Requests](#example-get-requests)
* [Known-bugs](#known-bugs)
* [License](#license)

## Technologies Used

* _C#_
* _.NET_
* _MySQL/MySQL Workbench_
* _Postman_
* _Swagger UI_
* _Entity Framework_
* _ASP.NET Core_

## Description

_This API is designed to catalog and display information on all 20 main Formula 1 drivers and 10 teams. This API supports full CRUD functionality for both teams and drivers._

## Setup/Installation Requirements

* _Download project repository from GH to your local machine._
* _Clone this repository to your desktop._
* _Open a terminal window and navigate to this project's production directory at ```./F1DriverApi.Solution/F1DriverApi/```._

#### To Configure and Access the Database:
* _Within the production directory "TravelApi", create a new file called ``appsettings.json``._
* _Within ```appsettings.json```, input the following code, replacing the "uid" and "pwd" values (in the brackets below) with your own username and password for MySQL. Also replace the "database" value with your desired database name._
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[DATABASE_NAME];uid=[USERNAME];pwd=[PASSWORD];"
  }
}
```
* _Once complete, run the terminal command ```dotnet ef database update``` to create the initial MySQL database. The database will be seeded with data based on the included migrations files._

#### To Run the API:
* _Navigate to this project's production directory named "F1DriverApi"._
* _Run ```dotnet watch run``` in the command line to run the API in development mode from your local port. This will also open up Swagger UI in your browser. At this point, you can begin making API calls._
* _Run ```dotnet run``` in the command line to run the API in production mode from your local port._
* _To make a test a get request, click on the "Get" reviews route in the Swagger UI, then click the "try it out" button._
* _Reference the endpoint urls, optional parameters, and example requests listed below. The TravelAPI supports Get, Post, Update, and Delete functionality._

## Endpoints
```
Driver Endpoints:

GET - https://localhost:5001/api/{v1/v2}/drivers/
GET - https://localhost:5001/api/{v1/v2}/drivers/{id}
GET - https://localhost:5001/api/v2/drivers/statistics
POST - https://localhost:5001/api/{v1/v2}/drivers/
PUT - https://localhost:5001/api/{v1/v2}/drivers/{id}
DELETE - https://localhost:5001/api/{v1/v2}/drivers/{id}
DELETE - https://localhost:5001/api/{v1/v2}/random

Note: `{id}` is a variable and it should be replaced with the id number of the driver you want to GET, PUT, or DELETE.
Note: `{v1/v2}` indicates the version of the API you want to use. Version 2 contains all functionality of version 1 but also includes pagination and additional query options for Get results.
```

```
Team Endpoints:

GET - https://localhost:5001/api/v2/teams/
GET - https://localhost:5001/api/v2/teams/{id}
POST - https://localhost:5001/api/v2/teams/
PUT - https://localhost:5001/api/v2/teams/{id}
DELETE - https://localhost:5001/api/v2/teams/{id}

Note: `{id}` is a variable and it should be replaced with the id number of the team you want to GET, PUT, or DELETE.
Note: `v2` indicates the version of the API you want to use. Version 2 contains access to team based endpoints.
```


## Optional Driver Query String Parameters 
| Parameter             | Type        | Required     | Description                                                                   |
| --------------------- | ----------- | ----------   | -----------                                                                   | 
| DriverName            | String      | Required     | Returns drivers with a matching driver name value                             |
| DriverNationality     | String      | Required     | Returns drivers with a matching driver nationality value                      |
| CurrentTeam           | String      | Required     | Returns drivers with a matching driver current team value                     |
| DriverAge             | String      | Requred      | Returns drivers with a matching driver age value                              |
| RaceWins              | Int         | Required     | Returns drivers with a matching driver race wins value                        |
| Podiums               | Int         | Required     | Returns drivers with a matching podium value                                  | 
| CareerPoints          | Int         | Required     | Returns drivers with a matching career points value                           |
| WDCChampionships      | Int         | Required     | Returns drivers with a matching WDC Championships value                       |
| SortBy                | String      | Not Required | Sorts returned drivers by points, page, podiums, wins, championship, or name  |
| IsWDCChampion         | Bool        | Not Required | Returns drivers who are WDC champions                                         |
| MinPoints             | Int         | Not Required | Returns drivers over a minimum career points value                            |
| PageNumber            | Int         | Not Required | Returns specified page of results                                             |
| PageSize              | Int         | Not Required | Returns specified number of results per page                                  |

## Optional Team Query String Parameters 
| Parameter             | Type        | Required     | Description                                                                   |
| --------------------- | ----------- | ----------   | -----------                                                                   | 
| TeamName              | String      | Required     | Returns drivers with a matching driver name value                             |
| TeamNationality       | String      | Required     | Returns drivers with a matching driver nationality value                      |
| TeamPrincipal         | String      | Required     | Returns drivers with a matching driver current team value                     |
| TeamBase              | String      | Requred      | Returns drivers with a matching driver age value                              |
| TeamChampionships     | Int         | Required     | Returns drivers with a matching driver race wins value                        |
| PageNumber            | Int         | Not Required | Returns specified page of results                                             |
| PageSize              | Int         | Not Required | Returns specified number of results per page                                  |
| SortBy                | String      | Not Required | Sorts returned drivers championships or name                                  |


## Example Get Requests
* _To make an Api call for all drivers for RedBull Racing:_
https://localhost:5001/api/v2/Drivers?currentTeam=Red%20Bull%20Racing&sortBy=name

```
[
  {
    "driverId": 1,
    "driverName": "Max Verstappen",
    "driverNationality": "Dutch",
    "currentTeam": "Red Bull Racing",
    "driverAge": 25,
    "raceWins": 40,
    "podiums": 84,
    "careerPoints": 2181,
    "wdcChampionships": 2
  },
  {
    "driverId": 2,
    "driverName": "Sergio Perez",
    "driverNationality": "Mexican",
    "currentTeam": "Red Bull Racing",
    "driverAge": 33,
    "raceWins": 6,
    "podiums": 30,
    "careerPoints": 1318,
    "wdcChampionships": 0
  }
]
```

* _To make a call returning the first page of drivers, with 2 drivers listed per page:_
https://localhost:5001/api/v2/Drivers?pageNumber=1&pageSize=2
```
[
  {
    "driverId": 1,
    "driverName": "Max Verstappen",
    "driverNationality": "Dutch",
    "currentTeam": "Red Bull Racing",
    "driverAge": 25,
    "raceWins": 40,
    "podiums": 84,
    "careerPoints": 2181,
    "wdcChampionships": 2
  },
  {
    "driverId": 2,
    "driverName": "Sergio Perez",
    "driverNationality": "Mexican",
    "currentTeam": "Red Bull Racing",
    "driverAge": 33,
    "raceWins": 6,
    "podiums": 30,
    "careerPoints": 1318,
    "wdcChampionships": 0
  }
]
```

## Additional Requirements for Driver/Team Post Request
* _POST requests for drivers https://localhost:5001/api/{v1/v2}/drivers/ require JSON body formatting shown below._
* _POST requests for teams https://localhost:5001/api/v2/teams/ require JSON body formatting shown below._
```
POST Request for Drivers Format:
{
  "driverName": "string",
  "driverNationality": "string",
  "currentTeam": "string",
  "driverAge": 0,
  "raceWins": 0,
  "podiums": 0,
  "careerPoints": 0,
  "wdcChampionships": 0
}

POST Request for Teams Format:
{
  "teamName": "string",
  "teamNationality": "string",
  "teamPrincipal": "string",
  "teamBase": "string",
  "teamChampionships": 0
}
```

## Additional Requirements for Driver/Team Put Request
* _PUT requests for drivers https://localhost:5001/api/{v1/v2}/drivers/{id} require JSON body formatting shown below._
* _PUT requests for teams https://localhost:5001/api/v2/teams/{id} require JSON body formatting shown below._
```
Driver PUT Request Format:
{
  "driverId": 0,
  "driverName": "string",
  "driverNationality": "string",
  "currentTeam": "string",
  "driverAge": 0,
  "raceWins": 0,
  "podiums": 0,
  "careerPoints": 0,
  "wdcChampionships": 0
}

Team PUT Request Format:
{
  "teamId": 0,
  "teamName": "string",
  "teamNationality": "string",
  "teamPrincipal": "string",
  "teamBase": "string",
  "teamChampionships": 0
}
```

## Known Bugs

* _API not currently configured to display .5 points for applicable drivers. Drivers with point totals ending in .5 are rounded down to nearest point (6/17/23)_

## License

MIT License

Copyright (c) [2023] [Marcus Kyung]

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: 

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR\ A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.