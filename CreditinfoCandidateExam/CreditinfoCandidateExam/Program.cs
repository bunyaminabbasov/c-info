using CreditinfoCandidateExam.DataAccessHandler;
using CreditinfoCandidateExam.Models;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace CreditinfoCandidateExam
{
    internal class Program
    {
        private static DBManager GetConnection() => new DBManager(@"Data Source=DESKTOP-4DHIMKD\SHAHRIYAR;Initial Catalog=CreditinfoCandidateExam;Integrated Security=True");

        private static void Main(string[] args)
        {
            var path = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add("http://creditinfo.com/schemas/Sample/Data", path + "\\Data.xsd");

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            XmlReader rd = XmlReader.Create(path + "\\Sample.xml", settings);
            XDocument doc = XDocument.Load(rd);

            using TextReader sr = new StringReader(doc.ToString());
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Batch));
            Batch response = (Batch)serializer.Deserialize(sr);

            AddDbCreditinfoCandidate(response);
        }

        private static void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.WriteLine("\tWarning: Matching schema not found.  No validation occurred." + args.Message);
            else
                Console.WriteLine("\tValidation error: " + args.Message);
        }

        private static void AddDbCreditinfoCandidate(Batch response)
        {
            var _objData = GetConnection();

            foreach (var contract in response.Contract)
            {
                long lastContractId = AddDbContract(_objData, contract);
                long lastContractDataId = AddDbContractData(_objData, contract, lastContractId);
                AddDbOriginalAmount(_objData, contract, lastContractDataId);
                AddDbInstallmentAmount(_objData, contract, lastContractDataId);
                AddDbCurrentBalance(_objData, contract, lastContractDataId);
                AddDbOverdueBalance(_objData, contract, lastContractDataId);

                foreach (var individual in contract.Individual)
                {
                    AddDbIndividual(_objData, individual, lastContractId);
                }
                foreach (var subjectRole in contract.SubjectRole)
                {
                    AddDbSubjectRole(_objData, subjectRole, lastContractId);
                }
            }
        }

        private static long AddDbContract(DBManager objData, Contract contract)
        {
            IDbDataParameter[] paramContract = new[]
                {
                     objData.CreateParameter("@ContractCode",contract.ContractCode,DbType.String),
                };

            objData.Insert(@"INSERT INTO [dbo].[Contract]([ContractCode])VALUES(@ContractCode); SELECT SCOPE_IDENTITY()", CommandType.Text, paramContract, out long lastContractId);
            return lastContractId;
        }

        private static long AddDbContractData(DBManager objData, Contract contract, long lastContractId)
        {
            IDbDataParameter[] paramContractData = new[]
                {
                     objData.CreateParameter("@ContractId",lastContractId,DbType.Int32),
                     objData.CreateParameter("@DateOfLastPayment",contract.ContractData.DateOfLastPayment,DbType.Date),
                     objData.CreateParameter("@NextPaymentDate",contract.ContractData.NextPaymentDate,DbType.Date),
                     objData.CreateParameter("@DateAccountOpened",contract.ContractData.DateAccountOpened,DbType.Date),
                     objData.CreateParameter("@RealEndDate",contract.ContractData.RealEndDate,DbType.Date),
                };

            objData.Insert(@"INSERT INTO [dbo].[ContractData]([ContractId],[DateOfLastPayment],[NextPaymentDate],[DateAccountOpened],[RealEndDate])VALUES(@ContractId,@DateOfLastPayment,@NextPaymentDate,@DateAccountOpened,@RealEndDate); SELECT SCOPE_IDENTITY()", CommandType.Text, paramContractData, out long lastContractDataId);
            return lastContractDataId;
        }

        private static void AddDbIndividual(DBManager objData, Individual individual, long lastContractId)
        {
            IDbDataParameter[] paramIndividual = new[]
                {
                     objData.CreateParameter("@ContractId",lastContractId,DbType.Int32),
                     objData.CreateParameter("@CustomerCode",individual.CustomerCode,DbType.String),
                     objData.CreateParameter("@FirstName",individual.FirstName,DbType.String),
                     objData.CreateParameter("@LastName",individual.LastName,DbType.String),
                     objData.CreateParameter("@Gender",individual.Gender,DbType.String),
                     objData.CreateParameter("@DateOfBirth",individual.DateOfBirth,DbType.Date)
                };

            objData.Insert(@"INSERT INTO [dbo].[Individual]([ContractId],[CustomerCode],[FirstName],[LastName],[Gender],[DateOfBirth])VALUES(@ContractId,@CustomerCode,@FirstName,@LastName,@Gender,@DateOfBirth); SELECT SCOPE_IDENTITY()", CommandType.Text, paramIndividual);
        }

        private static void AddDbSubjectRole(DBManager objData, SubjectRole subjectRole, long lastContractId)
        {
            IDbDataParameter[] paramSubjectRole = new[]
                {
                     objData.CreateParameter("@ContractId",lastContractId,DbType.Int32),
                     objData.CreateParameter("@CustomerCode",subjectRole.CustomerCode,DbType.String),
                     objData.CreateParameter("@RoleOfCustomer",subjectRole.RoleOfCustomer,DbType.String)
                };

            objData.Insert(@"INSERT INTO [dbo].[SubjectRole]([ContractId],[CustomerCode],[RoleOfCustomer])VALUES(@ContractId,@CustomerCode,@RoleOfCustomer); SELECT SCOPE_IDENTITY()", CommandType.Text, paramSubjectRole);
        }

        private static void AddDbOriginalAmount(DBManager objData, Contract contract, long lastContractDataId)
        {
            IDbDataParameter[] paramOriginalAmount = new[]
                {
                     objData.CreateParameter("@ContractDataId",lastContractDataId,DbType.Int32),
                     objData.CreateParameter("@Value",contract.ContractData.OriginalAmount.Value,DbType.String),
                     objData.CreateParameter("@Currency",contract.ContractData.OriginalAmount.Currency,DbType.String),
                };

            objData.Insert(@"INSERT INTO [dbo].[OriginalAmount]([ContractDataId],[Value],[Currency])VALUES(@ContractDataId,@Value,@Currency)", CommandType.Text, paramOriginalAmount);
        }

        private static void AddDbCurrentBalance(DBManager objData, Contract contract, long lastContractDataId)
        {
            IDbDataParameter[] paramOriginalAmount = new[]
                {
                     objData.CreateParameter("@ContractDataId",lastContractDataId,DbType.Int32),
                     objData.CreateParameter("@Value",contract.ContractData.OriginalAmount.Value,DbType.String),
                     objData.CreateParameter("@Currency",contract.ContractData.OriginalAmount.Currency,DbType.String),
                };

            objData.Insert(@"INSERT INTO [dbo].[CurrentBalance]([ContractDataId],[Value],[Currency])VALUES(@ContractDataId,@Value,@Currency)", CommandType.Text, paramOriginalAmount);
        }

        private static void AddDbInstallmentAmount(DBManager objData, Contract contract, long lastContractDataId)
        {
            IDbDataParameter[] paramOriginalAmount = new[]
                {
                     objData.CreateParameter("@ContractDataId",lastContractDataId,DbType.Int32),
                     objData.CreateParameter("@Value",contract.ContractData.OriginalAmount.Value,DbType.String),
                     objData.CreateParameter("@Currency",contract.ContractData.OriginalAmount.Currency,DbType.String),
                };

            objData.Insert(@"INSERT INTO [dbo].[InstallmentAmount]([ContractDataId],[Value],[Currency])VALUES(@ContractDataId,@Value,@Currency)", CommandType.Text, paramOriginalAmount);
        }

        private static void AddDbOverdueBalance(DBManager objData, Contract contract, long lastContractDataId)
        {
            IDbDataParameter[] paramOriginalAmount = new[]
                {
                     objData.CreateParameter("@ContractDataId",lastContractDataId,DbType.Int32),
                     objData.CreateParameter("@Value",contract.ContractData.OriginalAmount.Value,DbType.String),
                     objData.CreateParameter("@Currency",contract.ContractData.OriginalAmount.Currency,DbType.String),
                };

            objData.Insert(@"INSERT INTO [dbo].[OverdueBalance]([ContractDataId],[Value],[Currency])VALUES(@ContractDataId,@Value,@Currency)", CommandType.Text, paramOriginalAmount);
        }
    }
}