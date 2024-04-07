using System.Globalization;
using System.Xml.Linq;
using CsvHelper;

namespace AC2
{
    public static class HelperClass
    {
        public static List<Comarca> ReadCSV()
        {
            List<Comarca> comarques = new List<Comarca>();
            using StreamReader reader = new StreamReader("consumAigua.csv");
            using CsvReader csvreader = new CsvReader(reader, CultureInfo.InvariantCulture);
            csvreader.Read();
            csvreader.ReadHeader();
            while (csvreader.Read())
            {
                var record = new Comarca
                {
                    Year = csvreader.GetField<int>("Any"),
                    Code = csvreader.GetField<int>("Codi comarca"),
                    Name = csvreader.GetField<string>("Comarca"),
                    Population = csvreader.GetField<int>("Població"),
                    DomesticExpense = csvreader.GetField<int>("Domèstic xarxa"),
                    EconomicalActivitiesExpense = csvreader.GetField<int>(
                        "Activitats econòmiques i fonts pròpies"
                    ),
                    Total = csvreader.GetField<int>("Total"),
                    IndividualExpense = csvreader.GetField<decimal>("Consum domèstic per càpita")
                };
                comarques.Add(record);
            }
            return comarques;
        }

        public static void CreateXML(List<Comarca> comarques)
        {
            XDocument xmlDoc = new XDocument(
                new XElement(
                    "consum",
                    from comarca in comarques
                    select new XElement(
                        "comarca",
                        new XElement("Any", comarca.Year),
                        new XElement("CodiComarca", comarca.Code),
                        new XElement("NomComarca", comarca.Name),
                        new XElement("Poblacio", comarca.Population),
                        new XElement("DomesticXarxa", comarca.DomesticExpense),
                        new XElement("ActivitatsEconomiques", comarca.EconomicalActivitiesExpense),
                        new XElement("Total", comarca.Total),
                        new XElement("ConsumDomesticPerCapita", comarca.IndividualExpense)
                    )
                )
            );

            string xmlFilePath = "consumAigua.xml";
            xmlDoc.Save(xmlFilePath);
        }

        public static void PrintBigComarques(List<Comarca> comarques)
        {
            foreach (var comarca in comarques)
            {
                if (comarca.Population > 200000)
                    Console.WriteLine(comarca.ToString());
            }
        }

        public static void PrintDomesticAverageExpense(List<Comarca> comarques)
        {
            var avgByComarca = comarques
                .GroupBy(c => c.Code)
                .Select(g => new
                {
                    Code = g.Key,
                    g.First().Name,
                    AvgDomesticExpense = g.Average(c => c.DomesticExpense).ToString("0.00")
                });

            foreach (var comarca in avgByComarca)
                Console.WriteLine(
                    comarca.Code + " | " + comarca.Name + " | " + comarca.AvgDomesticExpense
                );
        }

        public static List<Comarca> GetTop5Comarques(List<Comarca> comarques, bool ascending) /*Obtenir les 5 comarques amb el consum per càpita més alt o més baix*/
        {
            int maxYear = comarques.Max(c => c.Year);

            var filteredComarques = comarques.Where(c => c.Year == maxYear);
            return ascending
                ? filteredComarques.OrderBy(c => c.IndividualExpense).Take(5).ToList()
                : filteredComarques.OrderByDescending(c => c.IndividualExpense).Take(5).ToList();
        }

        public static void SearchComarca(List<Comarca> comarques, string comarca)
        {
            List<Comarca> comarcaToSearch = new List<Comarca>();
            if (comarca.Length > 2)
                comarcaToSearch = comarques.Where(c => c.Name == comarca).ToList();
            else
                comarcaToSearch = comarques.Where(c => c.Code == int.Parse(comarca)).ToList();

            if (comarcaToSearch != null)
            {
                foreach (var c in comarcaToSearch)
                    Console.WriteLine(c.ToString());
            }
            else
            {
                Console.WriteLine("Comarca no trobada");
            }
        }
    }
}
