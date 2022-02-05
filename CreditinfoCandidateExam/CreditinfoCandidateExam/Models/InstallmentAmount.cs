﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CreditinfoCandidateExam.Models
{
	[XmlRoot(ElementName = "InstallmentAmount", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
	public class InstallmentAmount
	{
		[XmlElement(ElementName = "Value", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public string Value { get; set; }
		[XmlElement(ElementName = "Currency", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
		public string Currency { get; set; }
	}
}
