namespace XMLTest.FourRefuel.Xml;

using System.Xml.Serialization;

public class XmlClient : IClient
{
    private const string Endpoint = "https://secure.qccareerschool.com/test.xml";

    public async Task<IEnumerable<Invoice>> GetAllAsync()
    {
        using var client = new HttpClient();
        using var response = await client.GetAsync(Endpoint);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Unable to fetch");
        }

        using var stream = await response.Content.ReadAsStreamAsync();

        var serializer = new XmlSerializer(typeof(XmlResponse));
        var fourRefuelResponse = (XmlResponse?)serializer.Deserialize(stream);

        if (fourRefuelResponse == null)
        {
            throw new Exception("Unable deserialize");
        }

        return fourRefuelResponse.Invoices.Select(i => new Invoice
        {
            Id = i.CustomerCode,
            Date = i.TransactionTime,
        });
    }
}
