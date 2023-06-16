# _F1 Driver API_

#### By _**Marcus Kyung**_
#### _API to get 2023 F1 Driver Information built with C#, ASP.NET Core, and MySQL_

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
* _MySQL_
* _MySQL Workbench_
* _Postman_
* _Swagger UI_
* _Entity Framework_


## Description

_TravelAPI is an API used to track reviews for travel destinations around the world. The starting database is seeded with data for 20 reviews but the API supports full CRUD functionality to store additional reviews and to edit and delete existing ones. Reviews are queryable by destination, city, country, user, and rating. TravelApi v2 also supports pagination and querying results by page number and page size. This project was built using C#, Entity Framework Core, and MySQL._

## Setup/Installation Requirements

* _Download project repository from GH to your local machine._
* _Clone this repository to your desktop._
* _Open your shell (e.g., Terminal or GitBash) and navigate to this project's production directory at ```./TravelAPi.Solution/TravelApi/```._

#### To Configure and Access the Database:
* _Within the production directory "TravelApi", create a new file called ``appsettings.json``._
* _Within ```appsettings.json```, put the following code, replacing the "uid" and "pwd" values (in the brackets below) with your own username and password for MySQL. Also replace the "database" value with your desired database name._
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[DATABASE_NAME];uid=[USERNAME];pwd=[PASSWORD];"
  }
}
```
* _Run the terminal command ```dotnet ef database update``` to create the initial MySQL database._

#### To Run the API:
* _Navigate to this project's production directory named "TravelApi"._
* _Run ```dotnet watch run``` in the command line to run the API from your local port. This will also open up Swagger UI in your browser. At this point, you can begin making API calls._
* _To make a test a get request, click on the "Get" reviews route in the Swagger UI, then click the "try it out" button._
* _Reference the endpoint urls, optional parameters, and example requests listed below. The TravelAPI supports Get, Post, Update, and Delete functionality._

## Endpoints
```
GET http://localhost:5000/api/{v1/v2}/reviews/
GET http://localhost:5000/api/{v1/v2}/reviews/{id}
POST http://localhost:5000/api/{v1/v2}/reviews/
PUT http://localhost:5000/api/{v1/v2}/reviews/{id}
DELETE http://localhost:5000/api/{v1/v2}/reviews/{id}
```
Note: `{id}` is a variable and it should be replaced with the id number of the review you want to GET, PUT, or DELETE.
Note: `{v1/v2}` indicates the version of the API you want to use. Version 2 contains all functionality of version 1 but also includes pagination for Get results.

## Optional Query String Parameters
| Parameter   | Type        |  Required    | Description |
| ----------- | ----------- | -----------  | ----------- | 
| Destination | String      |   Required   | Returns reviews with a matching Destination value    |
| Country     | String      |   Required   | Returns reviews with a matching Country value        |
| City        | String      |   Required   | Returns reviews with a matching City value           |
| Address     | String      | Not Required | Returns reviews with a matching Address value        |
| UserName    | String      |   Required   | Returns reviews with a matching UserName value       |
| Rating      | Int         |   Required   | Returns reviews with a matching Rating value         |
| Description | String      |   Required   | Returns reviews with a matching Description value    |
| Date        | DateTime    | Not Required | Returns reviews with a matching Date value           |
| byRating    | String      | Not Required | Value of "true" orders the returned list by descending rating |
| pageNumber  | Int         | Not Required | Returns reviews from the specified page number       |
| pageSize    | Int         | Not Required | Controls the amount of reviews returned on each page |

## Example Get Requests
* _To make an Api call for all reviews for destinations in Peru:_
http://localhost:5000/api/{v1/v2}/reviews/?country=peru
``
[
    {
        "reviewId": 7,
        "destination": "Machu Picchu",
        "country": "Peru",
        "city": "Cusco",
        "address": "789 Inca Trail",
        "userName": "HistoryBuff2021",
        "rating": 9,
        "description": "A mystical ancient city hidden in the mountains. The hike was challenging but rewarding!",
        "date": "2021-09-02T00:00:00"
    },
    {
        "reviewId": 15,
        "destination": "Machu Picchu",
        "country": "Peru",
        "city": "Cusco",
        "address": "789 Inca Trail",
        "userName": "Adventurer123",
        "rating": 9,
        "description": "A once-in-a-lifetime experience. The ancient ruins are awe-inspiring!",
        "date": "2023-05-30T00:00:00"
    },
    {
        "reviewId": 19,
        "destination": "Machu Picchu",
        "country": "Peru",
        "city": "Cusco",
        "address": "789 Inca Trail",
        "userName": "MountainHiker",
        "rating": 9,
        "description": "A challenging hike to reach the ancient ruins, but the view from the Sun Gate was worth it!",
        "date": "2022-08-05T00:00:00"
    }
]
``
* _To make a call returning the first page of reviews, with 2 reviews listed per page:_
http://localhost:5000/api/{v1/v2}/reviews/?pageNumber=1&pageSize=2
``
[
    {
        "reviewId": 1,
        "destination": "Waikiki Beach",
        "country": "United States",
        "city": "Honolulu",
        "address": "123 Beach st",
        "userName": "Mr_ReviewGuy",
        "rating": 9,
        "description": "Lovely vacation destination with great weather. No spiders at all!",
        "date": "2019-12-25T00:00:00"
    },
    {
        "reviewId": 2,
        "destination": "Coronado",
        "country": "United States",
        "city": "San Diego",
        "address": null,
        "userName": "Marcus",
        "rating": 7,
        "description": "Sunny San Diego offers a perfect blend of beach bliss and urban spiders",
        "date": "2006-07-25T00:00:00"
    }
]
``

## Additional Requirements for Post Request
* _POST requests http://localhost:5000/api/{v1/v2}/reviews/ require JSON body formatting shown below._
```
{
  "Destination": "Machu Picchu",
  "Country": "Peru",
  "City": "Cusco",
  "Address": "789 Inca Trail"
  "UserName": "Mr.Review",
  "Rating": 8,
  "Description": "A challenging hike to reach the ancient ruins, but the view from the Sun Gate was worth it!",
  "Date": new DateTime(2022, 08, 05)
}
```

## Additional Requirements for Put Request
* _PUT requests http://localhost:5000/api/{v1/v2}/reviews/{id} require JSON body formatting shown below._
```
{
  "ReviewId": 1,
  "Destination": "Machu Picchu",
  "Country": "Peru",
  "City": "Cusco",
  "Address": "789 Inca Trail"
  "UserName": "Mr.Review",
  "Rating": 8,
  "Description": "A challenging hike to reach the ancient ruins, but the view from the Sun Gate was worth it!",
  "Date": new DateTime(2022, 08, 05)
}
```

## Known Bugs

* _No known issues as of 6/14/23_

## License

MIT License

Copyright (c) [2023] [Marcus Kyung]

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: 

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR\ A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.