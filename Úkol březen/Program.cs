using Spectre.Console;

Dictionary<int, int> teplotyDny = new Dictionary<int, int>();
dalsiden:
Console.WriteLine("Zadej den od 1 do 31.");
int den = int.Parse(Console.ReadLine());


Console.WriteLine("Zadej teplotu pro den číslo " + den + ".");
int teplota = int.Parse(Console.ReadLine());
try
{
    if (teplotyDny.ContainsKey(den))
    {
        teplotyDny.Remove(den);
    }
    teplotyDny.Add(den, teplota);
}
catch
{
    Console.WriteLine("Chybne data");
    goto dalsiden;
}

var pokracovani = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("[blue]Chceš zadat další den?[/]")
        .PageSize(3)
        .MoreChoicesText("[grey]Pro pohyb v menu používej šipky.[/]")
        .AddChoices(new[] {
            "Ano", "Ne"
        }));
if (pokracovani == "Ano")
{
    goto dalsiden;
}
else
{
    var vyhodnoceni = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("[blue]Jaké statistiky chceš zobrazit?[/]")
        .PageSize(3)
        .MoreChoicesText("[grey]Pro pohyb v menu používej šipky.[/]")
        .AddChoices(new[] {
            "Maximální teplotu", "Minimální teplotu", "Průměrnou teplotu"
        }));
    if (vyhodnoceni == "Maximální teplotu")
    {
        Console.WriteLine("Maximální teplota v měsíci byla: " + teplotyDny.Values.Max());
    }
    else if (vyhodnoceni == "Minimální teplotu")
    {
        Console.WriteLine("Minimální teplota v měsící byla: " + teplotyDny.Values.Min());
    }
    else { Console.WriteLine("Průměrná teplota v měsíci byla: " + teplotyDny.Values.Average());}
}