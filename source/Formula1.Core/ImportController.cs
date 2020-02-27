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
        /// <summary>
        /// Daten der Rennen werden aus der
        /// XML-Datei ausgelesen und in die Races-Collection gespeichert.
        /// Grund: Races werden nicht aus den Results geladen, weil sonst die
        /// Rennen in der Zukunft fehlen
        /// </summary>
        public static IEnumerable<Race> LoadRacesFromRacesXml()
        {
            List<Race> races = new List<Race>();
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
                            })
                        .ToList();
            }
            return races;
        }

        /// <summary>
        /// Aus den Results werden alle Collections, außer Races gefüllt.
        /// Races wird extra behandelt, um auch Rennen ohne Results zu verwalten
        /// </summary>
        public static IEnumerable<Result> LoadResultsFromXmlIntoCollections()
        {
            LoadRacesFromRacesXml();
            var Drivers = new List<Driver>();
            var Teams = new List<Team>();
            var Results = new List<Result>();



            return Results;
        }


    }
}