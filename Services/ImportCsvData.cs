using CsvHelper;
using CsvHelper.Configuration;
using PizzaPlace.Mapping;
using PizzaPlace.Model;
using System.Globalization;
using System.IO;
public class ImportCsvData
{
    public IEnumerable<OrderDetails> ImportOrderDetails(string filePath)
    {
        var orderDetails = ImportData<OrderDetails, OrderDetailsMap>(filePath);
        return orderDetails;
    }

    public IEnumerable<Orders> ImportOrderTransaction(string filePath)
    {
        var orderDetails = ImportData<Orders, OrderMapping>(filePath);
        return orderDetails;
    }

    public IEnumerable<Pizza> ImportPizza(string filePath)
    {
        var orderDetails = ImportData<Pizza, PizzaMapping>(filePath);
        return orderDetails;
    }

    public IEnumerable<PizzaType> ImportPizzaType(string filePath)
    {
        var orderDetails = ImportData<PizzaType, PizzaTypeMapping>(filePath);
        return orderDetails;
    }

    public IEnumerable<T> ImportData<T, TMap>(string filePath)
    where TMap : ClassMap<T>
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            HeaderValidated = null,
            MissingFieldFound = null,
        });

        csv.Context.RegisterClassMap<TMap>();
        var records = csv.GetRecords<T>().ToList();
        return records;
    }
}

