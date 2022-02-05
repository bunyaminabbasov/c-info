using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CreditinfoCandidateExam.Models
{
	[XmlRoot(ElementName = "Individual", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
	public class Individual
	{
		[XmlElement(ElementName = "CustomerCode", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public string CustomerCode { get; set; }
		[XmlElement(ElementName = "FirstName", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public string FirstName { get; set; }
		[XmlElement(ElementName = "LastName", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public string LastName { get; set; }
		[XmlElement(ElementName = "Gender", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public string Gender { get; set; }
		[XmlElement(ElementName = "DateOfBirth", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public string DateOfBirth { get; set; }
		[XmlElement(ElementName = "IdentificationNumbers", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public IdentificationNumbers IdentificationNumbers { get; set; }
	}
}
