namespace XMLTest.FourRefuel.Xml;

using System.Net.Http;
using System.Xml.Serialization;

/// <inheritdoc/>
public class XmlClient : IClient
{
    private const string Endpoint = "https://secure.qccareerschool.com/test.xml";

    private readonly IHttpClientFactory httpClientFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="XmlClient"/> class.
    /// </summary>
    /// <param name="httpClientFactory">An instance of an IHttpClientFactory.</param>
    public XmlClient(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Invoice>> GetAllAsync()
    {
        using var client = this.httpClientFactory.CreateClient();
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
            throw new Exception("Unable to deserialize");
        }

        return fourRefuelResponse.Invoices.Select(i => new Invoice
        {
            Id = i.CustomerCode,
            Date = i.TransactionTime,
        });
    }
}
