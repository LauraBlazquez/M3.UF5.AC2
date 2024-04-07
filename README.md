# Bibliografía:
Raquel A. N. M03.UF5. Teoria. [https://learn.microsoft.com/es-es/dotnet/csharp/tour-of-csharp/tutorials/arrays-and-collections](https://docs.google.com/document/d/1JJhB0bqxqns69wKZyF-s8eacxkzv55gO-ez6QvXEvhw/edit). Published 26 de febrero de 2024.

# Webgrafía:

## Chat GPT:

- **Prompt 1**:
teniendo en cuenta esta funcion:
```
        public static void PrintDomesticAverageExpense(List<Comarca> comarques)
        {
            int total = 0;
            foreach (Comarca comarca in comarques)
                total += comarca.DomesticExpense;
            Console.WriteLine("La despesa mitjana de consum domèstic és de " + total / comarques.Count);
        }
```
hazme utilizando LINQ el avg de cada comarca en todos los años 

- **Response**:
```
        List<Comarca> comarques = new List<Comarca>
        {
            new Comarca { CodiComarca = 1, NomComarca = "Comarca A", Poblacio = 10000, DomesticExpense = 5000, ActivitatsEconomiques = 1000, Total = 6000, ConsumDomesticPerCapita = 50 },
            new Comarca { CodiComarca = 2, NomComarca = "Comarca B", Poblacio = 15000, DomesticExpense = 7000, ActivitatsEconomiques = 2000, Total = 9000, ConsumDomesticPerCapita = 60 },
            new Comarca { CodiComarca = 1, NomComarca = "Comarca A", Poblacio = 11000, DomesticExpense = 5500, ActivitatsEconomiques = 1200, Total = 6700, ConsumDomesticPerCapita = 55 },
            new Comarca { CodiComarca = 2, NomComarca = "Comarca B", Poblacio = 16000, DomesticExpense = 7500, ActivitatsEconomiques = 2200, Total = 9700, ConsumDomesticPerCapita = 65 }
        };

        var avgByComarca = comarques
            .GroupBy(c => c.CodiComarca)
            .Select(g => new
            {
                CodiComarca = g.Key,
                NomComarca = g.First().NomComarca,
                AvgDomesticExpense = g.Average(c => c.DomesticExpense)
            });

        foreach (var comarca in avgByComarca)
        {
            Console.WriteLine($"Comarca: {comarca.NomComarca}, Promedio de gasto doméstico: {comarca.AvgDomesticExpense}");
        }
    }
}
```
Este código calculará el promedio del gasto doméstico para cada comarca a lo largo de todos los años y mostrará el resultado en la consola.

- **Prompt 2**:
```
        public static List<Comarca> GetTop5Comarques(List<Comarca> comarques, bool ascending) /*Obtenir les 5 comarques amb el consum per càpita més alt o més baix*/
        {
            var avgByComarca = comarques
                .Where(c => c.Year == int.MaxValue)
                .GroupBy(c => c.Year)
                .Select(g => new
                {
                    
                    Code = g.Key,
                    g.First().Name,
                });
            return ascending
                ? comarques.OrderBy(c => c.IndividualExpense).Take(5).ToList()
                : comarques.OrderByDescending(c => c.IndividualExpense).Take(5).ToList();
        }
```
quiero mostrar las 5 comarcas del año mas actual

- **Response**: 
```
public static List<Comarca> GetTop5Comarques(List<Comarca> comarques, bool ascending) 
{
    int currentYear = DateTime.Now.Year;

    var topComarques = comarques
        .Where(c => c.Year == currentYear) // Filtrar por el año más actual
        .OrderBy(c => ascending ? c.IndividualExpense : -c.IndividualExpense) // Ordenar ascendente o descendente según la bandera
        .Take(5) // Tomar las primeras 5 comarcas
        .ToList(); // Convertir a lista

    return topComarques;
}
```
Este método toma una lista de comarcas (comarques) y una bandera booleana ascending, que indica si se debe ordenar de manera ascendente (true) o descendente (false). Filtra las comarcas para obtener solo las del año más actual, luego las ordena según la bandera y toma las primeras 5 comarcas. Finalmente, devuelve estas 5 comarcas en una lista.

- **Prompt 3**:
no, no quiero que sean de este año concretamente, quiero que sean las que tiene el año mas grande

- **Response**:
```
public static List<Comarca> GetTop5Comarques(List<Comarca> comarques, bool ascending) 
{
    int maxYear = comarques.Max(c => c.Year); // Obtener el año más grande

    var topComarques = comarques
        .Where(c => c.Year == maxYear) // Filtrar por el año más grande
        .OrderBy(c => ascending ? c.IndividualExpense : -c.IndividualExpense) // Ordenar ascendente o descendente según la bandera
        .Take(5) // Tomar las primeras 5 comarcas
        .ToList(); // Convertir a lista

    return topComarques;
}
```
Este método toma una lista de comarcas (comarques) y una bandera booleana ascending, que indica si se debe ordenar de manera ascendente (true) o descendente (false). Primero, encuentra el año más grande en la lista de comarcas. Luego, filtra las comarcas para obtener solo las del año más grande, las ordena según la bandera y toma las primeras 5 comarcas. Finalmente, devuelve estas 5 comarcas en una lista.En este ejemplo, listaCombinada contendrá todos los elementos de lista1 seguidos por todos los elementos de lista2, en el mismo orden en que aparecen en cada lista original.

- **Prompt 4**:
como puedo implementar este condicional:
```
                    if (values[0].GetType != String)
                    {

                    }
```

- **Response**:
```
if (values.Count > 0 && values[0].GetType() != typeof(string))
{
    // Tu código aquí si el tipo del primer elemento no es string
}
```
En este código:
    values[0].GetType() devuelve el tipo del primer elemento en la lista values.
    typeof(string) devuelve el tipo string.
    Comparamos si el tipo del primer elemento es diferente del tipo string.
    También agregamos values.Count > 0 para asegurarnos de que la lista no esté vacía antes de intentar acceder al primer elemento.

- **Prompt 5**:
```
 List<Comarca> comarcaToSearch = new List<Comarca>;
            if (comarca.Length > 2)
            {
                comarcaToSearch = comarques.Where(c => c.Name == comarca);
            }
            else
            {
                comarcaToSearch = comarques.Where(c => c.Code == int.Parse(comarca));
            }
```

- **Response**:
```
List<Comarca> comarcaToSearch = new List<Comarca>(); // Inicializamos la lista

if (comarca.Length > 2)
{
    comarcaToSearch = comarques.Where(c => c.NomComarca == comarca).ToList(); // Usamos ToList() para convertir el resultado a una lista
}
else
{
    int code;
    if (int.TryParse(comarca, out code))
    {
        comarcaToSearch = comarques.Where(c => c.CodiComarca == code).ToList(); // Usamos ToList() para convertir el resultado a una lista
    }
}
```
Con esta corrección, comarcaToSearch será una lista de objetos Comarca que satisfacen la condición especificada en el bloque if o en el bloque else, dependiendo de la longitud de comarca.
