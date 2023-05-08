using CsvHelper;
using CsvHelper.Configuration;
using RecruitmentTest.Models;
using System.Data.Common;
using System.Formats.Asn1;
using System.Globalization;
using System.Text.Json;

namespace RecruitmentTest.RepositoryDirectory
{
    public class FindOrderCSV : IFindOrder
    {

        private readonly string connection;

        public FindOrderCSV(string connectionString) 
        { 
            connection = connectionString; 
        }

        public string FindOrders(string numberOrder, DateTime fromDate, DateTime toDate, string[] clientCode)
        {
            if (File.Exists(connection) == false)
                return JsonSerializer.Serialize(new { resul = (connection == null ? "no set source file" : "no exist file: " + connection) });

            try
            {   
                var csvConfig = new CsvConfiguration(new CultureInfo("en-GB")) { HasHeaderRecord = true, Comment = '#', AllowComments = true, Delimiter = ",", };
                using var streamReader = File.OpenText(connection);
                using var csvReader = new CsvReader(streamReader, csvConfig);
                var result = csvReader.GetRecords<Orders>().ToList();

                if (result.Any() == false)
                    return JsonSerializer.Serialize(new { resul = "no items" });

                if (fromDate>toDate)
                    return JsonSerializer.Serialize(new { resul = "error value Date From and Date To" });

                result = result.Where(a => (a.OrderDate.Date >= fromDate.Date && a.OrderDate.Date <= toDate.Date)).ToList(); ;

                if (result.Any() == true && numberOrder!=null)
                    result = result.Where(a => a.Number.ToUpper() == numberOrder.ToUpper()).ToList(); ;

                if (result.Any() == true && clientCode != null)
                    result = result.Where(a => clientCode.ToList().ConvertAll(d => d.ToUpper()).Contains(a.Number.ToUpper())).ToList();

                if (result.Any() == false)
                    return JsonSerializer.Serialize(new { resul = "no items" });

                return JsonSerializer.Serialize(result);
            }
            catch 
            {
                return JsonSerializer.Serialize(new { resul = "error read file" });
            }
        }
    }

    public class FindOrderMSSQL : IFindOrder
    {
        private readonly string connection;

        public FindOrderMSSQL(string connectionString)
        {
            connection = connectionString;
        }
        public string FindOrders(string numberOrder, DateTime fromDate, DateTime toDate, string[] clientCode)
        {
            return JsonSerializer.Serialize(new { resul = "no implemen SQL reader" });
        }
    }
}
