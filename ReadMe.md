# Ragnar Relay Estimator

This is a web app built to allow Ragnar teams to create and update a list of projected start and finish times for each runner on their respective segments. A standard team has eight members (Ultra teams have four), a race consists of three loops that each runner must complete once. Times for each runner are based off their individual pace and course multiplyer.

## Getting Started

Clone this repo to your local machine. See deployment for notes on how to deploy the project on a live system.dotnet

### Prerequisites

You will need .Net Core 1.0.0 and MySQL 5.7 for this app to function correctly. Please see vendor documentation for correct installation. Create a appsettings.json file in the project's root folder.
```
{
  "DBConnection":
  {
    "Name": "MySQLconnect",
    "ConnectionsString": "server=localhost;userid='yourIDhere;password=yourPWhere;port=yourPortHere;database=RagnarEstimator;SslMode=None"
  }
}
```
Create a database named RagnarEstimator or edit the database name in appsettings.json.

### Installing

Hold your horses

## Deployment

I'm not there yet :-)

## Built With

* [1.0.3 with SDK Preview 2 build 3156](https://github.com/dotnet/core/blob/master/release-notes/download-archives/1.0.3-preview2-download.md) - .NET Core Runtime and SDK download
* [Ver 14.14 Distrib 5.7.19](https://dev.mysql.com/downloads/) - MySQL

## Contributing

Not at this time

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/jono3028/RagnarEstimator/tags). 

## Authors

* **Jonathan Owen** - *Initial work* - [jono3028](https://github.com/jono3028)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Escobar Beer Milers