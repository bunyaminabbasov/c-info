using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CreditinfoCandidateExam.Models
{
	[XmlRoot(ElementName = "Batch", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
	public class Batch
	{
		[XmlElement(ElementName = "Contract", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public List<Contract> Contract { get; set; }
		[XmlAttribute(AttributeName = "ci", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ci { get; set; }
		[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xsi { get; set; }
		[XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public string SchemaLocation { get; set; }
	}
}
