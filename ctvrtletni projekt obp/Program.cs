using Spectre;
using Spectre.Console;
using System.Xml.Linq;
using ctvrtletni_projekt_obp;

internal class Program
{
    private static void Main(string[] args)
    {
        bool cykl = true;

        var inventory = new Inventory();

        while (cykl == true)
        {
            var vyber = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[green]Vyber Funkci Programu[/]?")
                .PageSize(10)
                .AddChoices(new[] {
            "[Lime]Přidat položku[/]", "[Red]Odebrat Položku[/]", "[Lime]Zobrazit Inventář[/]",
            "[Lime]Ukončit Program[/]",
                }));
            switch (vyber)
            {
                case "[Lime]Přidat položku[/]":
                    {
                        while (true)
                        {
                            try
                            {

                                Console.WriteLine("Zadejte název položky: ");
                                string name = Console.ReadLine();
                                Console.Clear();

                                Console.WriteLine("Zadejte cenu položky:");
                                double price = double.Parse(Console.ReadLine());

                                Console.Clear();
                                inventory.AddProduct(name, price);
                                break;
                            }
                            catch
                            {

                                Console.Clear();
                                Console.WriteLine("Nevhodný vstup, zadejte jej znovu");
                            }
                        }

                        break;
                    }
                case "[Red]Odebrat Položku[/]":
                    {

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Seznam položek:");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("--------------------");
                        foreach (var product in inventory.Products)
                        {
                            Console.WriteLine(product.Name + " - " + product.Cena + " Kč");
                        }
                        Console.WriteLine("--------------------");
                        string nazev = AnsiConsole.Ask<string>("zadej název položky, kterou chcete [red]smazat[/]?");
                        inventory.RemoveProduct(nazev);
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("Položka byla smazána jestliže název byl zadán správně");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("");
                        Console.Write("Pro pokračování stiskněte libovolnou klávesu...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                case "[Lime]Zobrazit Inventář[/]":
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Počet položek v inventáři: " + inventory.PocetProduktu);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Seznam položek:");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");
                        Console.WriteLine("--------------------");
                        foreach (var product in inventory.Products)
                        {
                            Console.WriteLine(product.Name + " - " + product.Cena + " Kč");
                        }
                        Console.WriteLine("--------------------");
                        Console.WriteLine("");
                        Console.Write("Pro pokračování stiskněte libovolnou klávesu...");
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    }
                case "[Lime]Ukončit Program[/]":
                    {
                        cykl = false;
                        break;
                    }


            }



        }
    }
}

