using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CreditinfoCandidateExam.Models
{
	[XmlRoot(ElementName = "IdentificationNumbers", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
	public class IdentificationNumbers
	{
		[XmlElement(ElementName = "NationalID", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public string NationalID { get; set; }
	}
}
