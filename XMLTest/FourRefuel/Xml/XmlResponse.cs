namespace XMLTest.FourRefuel.Xml;

using System.Xml;
using System.Xml.Serialization;

[XmlRoot("CostCenterDetail")]
public record XmlResponse
{
    [XmlElement("Detail")]
    required public List<XMLInvoice> Invoices { get; set; }
}
