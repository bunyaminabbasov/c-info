using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CreditinfoCandidateExam.Models
{
	[XmlRoot(ElementName = "ContractData", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
	public class ContractData
	{
		[XmlElement(ElementName = "PhaseOfContract", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public string PhaseOfContract { get; set; }
		[XmlElement(ElementName = "OriginalAmount", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public OriginalAmount OriginalAmount { get; set; }
		[XmlElement(ElementName = "InstallmentAmount", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public InstallmentAmount InstallmentAmount { get; set; }
		[XmlElement(ElementName = "CurrentBalance", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public CurrentBalance CurrentBalance { get; set; }
		[XmlElement(ElementName = "OverdueBalance", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public OverdueBalance OverdueBalance { get; set; }
		[XmlElement(ElementName = "DateOfLastPayment", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public string DateOfLastPayment { get; set; }
		[XmlElement(ElementName = "NextPaymentDate", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public string NextPaymentDate { get; set; }
		[XmlElement(ElementName = "DateAccountOpened", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public string DateAccountOpened { get; set; }
		[XmlElement(ElementName = "RealEndDate", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public string RealEndDate { get; set; }
	}
}
