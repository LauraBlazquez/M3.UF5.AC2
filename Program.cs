using System.Xml.Linq;

namespace AC2
{
    public class Program
    {
        public static void Main()
        {
            const string Menu = "Quines dades vols veure?\n1. Grans comarques (+200.000 habitants)\n2. Consum domèstic mitjà per comarca.\n3. Top 5 comarques amb consums per càpita més alts.\n4. Top 5 comarques amb consums per càpita més baixos.\n5. Cercar dades d'una comarca concreta.\n0. Sortir\n";
            const string MSGName = "Introdueix el nom o el codi de la comarca que vols cerca: ";
            const string Pause = "Prem una tecla per continuar...";
            int option;
            List<Comarca> comarques = HelperClass.ReadCSV();

            try
            {
                XDocument.Load("consumAigua.xml");
            }
            catch
            {
                HelperClass.CreateXML(comarques);
            }

            do
            {
                Console.WriteLine(Menu);
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        HelperClass.PrintBigComarques(comarques);
                        Console.WriteLine(Pause);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        HelperClass.PrintDomesticAverageExpense(comarques);
                        Console.WriteLine(Pause);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        List<Comarca> filteredComarquesAsc = HelperClass.GetTop5Comarques(comarques,false);
                        foreach (Comarca comarca in filteredComarquesAsc)
                        {
                            Console.WriteLine(comarca.ToString());
                        }
                        Console.WriteLine(Pause);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        List<Comarca> filteredComarquesDesc = HelperClass.GetTop5Comarques(comarques,true);
                        foreach (Comarca comarca in filteredComarquesDesc)
                        {
                            Console.WriteLine(comarca.ToString());
                        }
                        Console.WriteLine(Pause);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.WriteLine(MSGName);
                        string comarcaInput = Console.ReadLine();
                        HelperClass.SearchComarca(comarques, comarcaInput);
                        Console.WriteLine(Pause);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 0:
                        Console.WriteLine("Chaito <3");
                        break;
                }
            } while (option != 0);
        }
    }
}
