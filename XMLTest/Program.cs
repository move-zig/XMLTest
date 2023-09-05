var client = new XMLTest.FourRefuel.Xml.XmlClient();
var invoices = await client.GetAllAsync();

foreach (var invoice in invoices)
{
    Console.WriteLine($"Invoice #{invoice.Id} has date {invoice.Date}");
}
