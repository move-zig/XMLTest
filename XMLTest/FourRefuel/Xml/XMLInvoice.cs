namespace XMLTest.FourRefuel.Xml;

using System.Xml;
using System.Xml.Serialization;

public record XMLInvoice
{
    [XmlAttribute("CustCode")]
    required public string CustomerCode { get; set; }

    [XmlAttribute("CustName")]
    required public string CustomerName { get; set; }

    [XmlAttribute("TransTime")]
    required public DateTime TransactionTime { get; set; }

    [XmlAttribute("DocketNo")]
    required public int DocketNumber { get; set; }

    [XmlAttribute("Quantity")]
    required public double Quantity { get; set; }

    [XmlAttribute("FuelQuantity")]
    required public double FuelQuantity { get; set; }

    [XmlAttribute("ProductName")]
    required public string ProductName { get; set; }

    [XmlAttribute("LineTotal")]
    required public double LineTotal { get; set; }
}