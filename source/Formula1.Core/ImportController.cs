using Formula1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Utils;

namespace Formula1.Core
{
    /// <summary>
    /// Daten sind in XML-Dateien gespeichert und werden per Linq2XML
    /// in die Collections geladen.
    /// </summary>
    public static class ImportController
    {
        public static IEnumerable<Race> Races { get; set; }
        public static IEnumerable<Result> Results { get; set; }
        public static IDictionary<string, Driver> Drivers { get; set; }
        public static IDictionary<string, Team> Teams { get; set; }


        /// <summary>
        /// Daten der Rennen werden aus der
        /// XML-Datei ausgelesen und in die Races-Collection gespeichert.
        /// Grund: Races werden nicht aus den Results geladen, weil sonst die
        /// Rennen in der Zukunft fehlen
        /// </summary>
        public static IEnumerable<Race> LoadRacesFromRacesXml()
        {
            IEnumerable<Race> races = null;
            string racesPath = MyFile.GetFullNameInApplicationTree("Races.xml");
            var xElement = XDocument.Load(racesPath).Root;
            if (xElement != null)
            {
                races =
                    xElement.Elements("Race")
                        .Select(race =>
                            new Race
                            {
                                Number = (int)race.Attribute("round"),
                                Date = (DateTime)race.Element("Date"),
                                Country = race.Element("Circuit")
                                                ?.Element("Location")
                                                ?.Element("Locality")?.Value,
                                City = race.Element("Circuit")
                                                ?.Element("Location")
                                                ?.Element("Locality")?.Value
                            });
            }
            return races;
        }

        /// <summary>
        /// Aus den Results werden alle Collections, außer Races gefüllt.
        /// Races wird extra behandelt, um auch Rennen ohne Results zu verwalten
        /// </summary>
        public static IEnumerable<Result> LoadResultsFromXmlIntoCollections()
        {
            Races = LoadRacesFromRacesXml();
            Results = new List<Result>();
            Drivers = new Dictionary<string, Driver>();
            Teams = new Dictionary<string, Team>();

            string resultsPath = MyFile.GetFullNameInApplicationTree("Results.xml");
            var xElement = XDocument.Load(resultsPath).Root;
            if (xElement != null)
            {
                Results = xElement.Elements("Race").Elements("ResultsList").Elements("Result")
                    .Select(result => new Result
                    {
                        Race = GetRace(result),
                        Driver = GetDriver(result),
                        Team = GetTeam(result),
                        Position = (int)result.Attribute("position"),
                        Points = (int)result.Attribute("points")
                    });    
            }
            return Results;
        }

        private static Team GetTeam(XElement xElement)
        {
            string teamName = (string)xElement.Element("Constructor")?.Element("Name").Value;
            if (Teams.ContainsKey(teamName) == false)
            {
                Teams[teamName] = new Team(teamName); 
            }
            return Teams[teamName];
        }

        private static Driver GetDriver(XElement xElement)
        {
            string familyName = (string)xElement.Element("Driver")?.Element("FamilyName").Value;
            string givenName = (string)xElement.Element("Driver")?.Element("GivenName").Value;
            string driverName = $"{familyName} {givenName}";

            if (Drivers.ContainsKey(driverName) == false)
            {
                Drivers[driverName] = new Driver(driverName);
            }
            return Drivers[driverName];
        }

        private static Race GetRace(XElement xElement)
        {
            int raceNumber = (int)xElement.Parent?.Parent?.Attribute("round");
            return Races.Single(race => race.Number == raceNumber);
        }
    }
}