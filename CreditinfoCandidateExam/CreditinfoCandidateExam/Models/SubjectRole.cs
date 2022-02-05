using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CreditinfoCandidateExam.Models
{
	[XmlRoot(ElementName = "SubjectRole", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
	public class SubjectRole
	{
		[XmlElement(ElementName = "CustomerCode", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public string CustomerCode { get; set; }
		[XmlElement(ElementName = "RoleOfCustomer", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public string RoleOfCustomer { get; set; }
		[XmlElement(ElementName = "GuaranteeAmount", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public GuaranteeAmount GuaranteeAmount { get; set; }
	}
}
