using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CreditinfoCandidateExam.Models
{
	[XmlRoot(ElementName = "Contract", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
	public class Contract
	{
		[XmlElement(ElementName = "ContractCode", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public string ContractCode { get; set; }
		[XmlElement(ElementName = "ContractData", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public ContractData ContractData { get; set; }
		[XmlElement(ElementName = "Individual", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public List<Individual> Individual { get; set; }
		[XmlElement(ElementName = "SubjectRole", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public List<SubjectRole> SubjectRole { get; set; }
	}
}
