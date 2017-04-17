using SRC.Library.Business.Interfaces;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Domain.Facade.Interfaces;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities.CustomEntities;
using SRC.Web.NewPortal.filters;
using SRC.Web.NewPortal.MockData;
using SRC.Web.NewPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using SRC.Library.Entities;
using System.Configuration;
using SRC.Library.Common;
using System.Xml;
using System.Text;
using System.IO;
using System.Web;

namespace SRC.Web.NewPortal.Controllers
{
    public class EducationApiController : ApiController
    {
        private IEducationBusiness _educationBusiness;
        private IEducationFacade _educationFacade;
        private IBaseBusiness<Education> _baseEducationBusiness;
        private IBaseBusiness<EducationAttendance> _educationAttendanceBaseBusiness;
        private IBaseBusiness<CreditCardLog> _creditCardLogBaseBusiness;

        private bool isMockActive = bool.Parse(ConfigurationManager.AppSettings["isMockActive"]);

        public EducationApiController(IEducationBusiness educationBusiness, IEducationFacade educationFacade
            , IBaseBusiness<Education> baseEducationBusiness
            , IBaseBusiness<EducationAttendance> educationAttendanceBaseBusiness
            , IBaseBusiness<CreditCardLog> creditCardLogBaseBusiness)
        {
            _educationBusiness = educationBusiness;
            _educationFacade = educationFacade;
            _baseEducationBusiness = baseEducationBusiness;
            _educationAttendanceBaseBusiness = educationAttendanceBaseBusiness;
            _creditCardLogBaseBusiness = creditCardLogBaseBusiness;
        }

        public ResponseContainer<List<Education>> GetComingEducationList()
        {
            ResponseContainer<List<Education>> returnValue = new ResponseContainer<List<Education>>();

            if (isMockActive)
            {
                returnValue.Result = EducationMock.GetComingEducations();
                returnValue.Success = true;
            }
            else
            {
                Guid? associationId = null;

                if (LoggedUser.IsLoggedIn && LoggedUser.Current.Association != null)
                {
                    associationId = LoggedUser.Current.Association.Id;
                }

                returnValue.Result = _educationFacade.GetComingEducationList(associationId);
                returnValue.Success = true;
                returnValue.Message = "Yaklaşan eğitimler çekildi.";

            }

            return returnValue;
        }

        public ResponseContainer<List<Education>> GetDoneEducationList()
        {
            ResponseContainer<List<Education>> returnValue = new ResponseContainer<List<Education>>();

            if (isMockActive)
            {
                returnValue.Result = EducationMock.GetDoneEducations();
                returnValue.Success = true;
            }
            else
            {
                Guid? associationId = null;

                if (LoggedUser.IsLoggedIn && LoggedUser.Current.Association != null)
                {
                    associationId = LoggedUser.Current.Association.Id;
                }

                returnValue.Result = _educationFacade.GetDoneEducationList(associationId);
                returnValue.Success = true;
                returnValue.Message = "Tamamlanan eğitimler çekildi.";
            }

            return returnValue;
        }

        public ResponseContainer<List<Education>> GetEducations()
        {
            ResponseContainer<List<Education>> returnValue = new ResponseContainer<List<Education>>();

            if (isMockActive)
            {
                returnValue.Result = EducationMock.GetComingEducations();
                returnValue.Success = true;
            }
            else
            {
                returnValue.Result = _educationFacade.GetEducations(DateTime.Now.Month, DateTime.Now.Year);

                List<EducationAttendance> contactAttendanceList = null;

                if (LoggedUser.IsLoggedIn)
                {
                    contactAttendanceList = _educationFacade.GetContactAttendances(LoggedUser.Current.Id);

                    _educationFacade.SetEducationAttendance(returnValue.Result, contactAttendanceList);
                }

                returnValue.Success = true;
                returnValue.Message = "Eğitim listesi çekildi.";
            }

            return returnValue;
        }

        public ResponseContainer<List<Education>> GetList(string month, string year)
        {
            ResponseContainer<List<Education>> returnValue = new ResponseContainer<List<Education>>();

            int monthNow = int.Parse(month);
            int yearNow = int.Parse(year);

            if (isMockActive)
            {
                //returnValue.Result = _educationFacade.GetEducations(monthNow, yearNow);
                returnValue.Result = EducationMock.GetComingEducations().Where(e => e.StartDate.Value.Month == monthNow
                    && e.StartDate.Value.Year == yearNow).ToList();

                List<EducationAttendance> contactAttendanceList = null;

                if (LoggedUser.IsLoggedIn)
                {
                    contactAttendanceList = AttendanceMock.GetAttendances();

                    _educationFacade.SetEducationAttendance(returnValue.Result, contactAttendanceList);
                }
            }
            else
            {
                Guid? associationId = null;

                if (LoggedUser.IsLoggedIn && LoggedUser.Current.Association != null)
                {
                    associationId = LoggedUser.Current.Association.Id;
                }

                returnValue.Result = _educationFacade.GetEducations(monthNow, yearNow, associationId);

                List<EducationAttendance> contactAttendanceList = null;

                if (LoggedUser.IsLoggedIn)
                {
                    contactAttendanceList = _educationFacade.GetContactAttendances(LoggedUser.Current.Id);

                    _educationFacade.SetEducationAttendance(returnValue.Result, contactAttendanceList);
                }

                returnValue.Success = true;
                returnValue.Message = "Eğitim listesi çekildi.";
            }

            returnValue.Success = true;

            return returnValue;
        }

        public ResponseContainer<Education> GetEducation(string id)
        {
            ResponseContainer<Education> returnValue = new ResponseContainer<Education>();

            if (isMockActive)
            {
                returnValue.Result = EducationMock.GetEducations().Where(e => e.Id == Guid.Parse(id)).FirstOrDefault();

                List<EducationAttendance> contactAttendanceList = null;

                if (LoggedUser.IsLoggedIn)
                {
                    contactAttendanceList = AttendanceMock.GetAttendances();

                    _educationFacade.SetEducationAttendance(returnValue.Result, contactAttendanceList);
                }

                returnValue.Success = true;
            }
            else
            {
                returnValue.Result = _baseEducationBusiness.Get(Guid.Parse(id));

                List<EducationAttendance> contactAttendanceList = null;

                if (LoggedUser.IsLoggedIn)
                {
                    contactAttendanceList = _educationFacade.GetContactAttendances(LoggedUser.Current.Id);

                    _educationFacade.SetEducationAttendance(returnValue.Result, contactAttendanceList);
                }

                returnValue.Success = true;
                returnValue.Message = "Eğitim detayı çekildi.";
            }


            return returnValue;
        }

        [HttpPost]
        [AuthenticationFilter]
        public ResponseContainer<EducationAttendance> ApplyEducation(string id)
        {
            ResponseContainer<EducationAttendance> returnValue = new ResponseContainer<EducationAttendance>();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Result = AttendanceMock.GetAttendances().FirstOrDefault();
                returnValue.Message = "İşlem sırasında bir hata ile karşılaşıldı.";
                returnValue.Success = true;
            }
            else
            {
                var attendance = new EducationAttendance
                {
                    Contact = LoggedUser.Current.ToEntityReferenceWrapper(),
                    Education = Guid.Parse(id).ToEntityReferenceWrapper<Education>(),
                    Name = string.Format("{0} {1}|{2}", LoggedUser.Current.FirstName, LoggedUser.Current.LastName, DateTime.Now.ToString("dd.MM.yyyy HH:mm"))
                };

                var attendanceId = _educationAttendanceBaseBusiness.Insert(attendance);

                returnValue.Result = _educationAttendanceBaseBusiness.Get(attendanceId);
                returnValue.Success = true;
                returnValue.Message = "Eğitim katılımı talebiniz başarıyla alınmıştır.";
            }

            return returnValue;
        }

        [HttpPost]
        [AuthenticationFilter]
        public ResponseContainer<bool> CancelAttendance(string id)
        {
            ResponseContainer<bool> returnValue = new ResponseContainer<bool>();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Result = true;
                returnValue.Message = "İşlem sırasında bir hata ile karşılaşıldı.";
                returnValue.Success = true;
            }
            else
            {
                _educationFacade.CancelEducationAttendance(new Guid(id));
                returnValue.Success = true;
                returnValue.Result = true;
                returnValue.Message = "Eğitim katılımı iptali başarıyla tamamlanmıştır.";
            }

            return returnValue;
        }

        [HttpPost]
        [AuthenticationFilter]
        public ResponseContainer<bool> PayEducation(CreditCardLog creditCardData)
        {
            ResponseContainer<bool> returnValue = new ResponseContainer<bool>();

            creditCardData.Id = Guid.NewGuid();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Result = true;
                returnValue.Success = true;
                returnValue.Message = "Ödeme başarılı bir şekilde alınmıştır.";
            }
            else
            {
                if (creditCardData.AttendanceId != null)
                {
                    creditCardData.EducationAttendance = creditCardData.AttendanceId.Value.ToEntityReferenceWrapper<EducationAttendance>();
                }

                var creditCardResult = DoPayment(creditCardData);

                creditCardData.ResultCode = creditCardResult.Result.Code;
                creditCardData.Result = string.Format("Ip:{0}|Result:{1}", HttpContext.Current.Request.UserHostAddress, creditCardResult.Result.Description);

                var creditCardLogId = _creditCardLogBaseBusiness.Insert(creditCardData);

                if (!creditCardResult.Success || creditCardResult.Result.Code != "0000")
                {
                    returnValue.Result = false;
                    returnValue.Message = creditCardResult.Message;

                    return returnValue;
                }

                EducationAttendance attendance = new EducationAttendance
                {
                    Id = creditCardData.AttendanceId.Value,
                    CreditCardLog = creditCardLogId.ToEntityReferenceWrapper<CreditCardLog>(),
                    Status = EducationAttendance.StatusCode.REGISTRATION_CONFIRMED.ToOptionSetValueWrapper(),
                    IsPaymentDone = true
                };

                _educationAttendanceBaseBusiness.Update(attendance);

                returnValue.Result = true;
                returnValue.Success = true;
                returnValue.Message = "Ödeme başarılı bir şekilde alınmıştır.";
            }

            return returnValue;
        }

        [AuthenticationFilter]
        public ResponseContainer<List<Education>> GetContactEducationByStatus(int status)
        {
            ResponseContainer<List<Education>> returnValue = new ResponseContainer<List<Education>>();

            if (isMockActive)
            {
                returnValue.Result = EducationMock.GetComingEducations();

                List<EducationAttendance> contactAttendanceList = null;

                if (LoggedUser.IsLoggedIn)
                {
                    contactAttendanceList = AttendanceMock.GetAttendances();

                    _educationFacade.SetEducationAttendance(returnValue.Result, contactAttendanceList);
                }

                returnValue.Success = true;
            }
            else
            {
                var attendances = _educationFacade.GetContactAttendances(LoggedUser.Current.Id)
                    .Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() == (EducationAttendance.StatusCode)status).ToList();

                if (attendances.Count > 0)
                {
                    var educationList = _educationFacade.GetEducationsOfAttendances(attendances);

                    _educationFacade.SetEducationAttendance(educationList, attendances);

                    returnValue.Result = educationList;
                }

                returnValue.Success = true;
                returnValue.Message = "Üye eğitim ve eğitim katılımları çekildi.";
            }

            return returnValue;
        }

        [AuthenticationFilter]
        public ResponseContainer<ContactAttendanceSummary> GetContactAttendanceSummary()
        {
            ResponseContainer<ContactAttendanceSummary> returnValue = new ResponseContainer<ContactAttendanceSummary>();

            if (isMockActive)
            {
                var attendances = AttendanceMock.GetAttendances();

                ContactAttendanceSummary summary = new ContactAttendanceSummary();
                summary.Contact = LoggedUser.Current.ToEntityReferenceWrapper();

                if (attendances != null && attendances.Count > 0)
                {
                    summary.ConfirmedCount = attendances.Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() == EducationAttendance.StatusCode.REGISTRATION_CONFIRMED).ToList().Count;
                    summary.JoinedCount = attendances.Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() == EducationAttendance.StatusCode.JOINED).ToList().Count;
                    summary.WaitingPaymentCount = attendances.Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() == EducationAttendance.StatusCode.WAITING_PAYMENT).ToList().Count;
                }

                returnValue.Result = summary;
                returnValue.Success = true;

                returnValue.Message = "Üye eğitim katılım özeti çekildi.";
            }
            else
            {
                var attendances = _educationFacade.GetContactAttendances(LoggedUser.Current.Id);

                ContactAttendanceSummary summary = new ContactAttendanceSummary();
                summary.Contact = LoggedUser.Current.ToEntityReferenceWrapper();

                if (attendances != null && attendances.Count > 0)
                {
                    summary.ConfirmedCount = attendances.Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() == EducationAttendance.StatusCode.REGISTRATION_CONFIRMED).ToList().Count;
                    summary.JoinedCount = attendances.Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() == EducationAttendance.StatusCode.JOINED).ToList().Count;
                    summary.WaitingPaymentCount = attendances.Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() == EducationAttendance.StatusCode.WAITING_PAYMENT).ToList().Count;
                }

                returnValue.Result = summary;
                returnValue.Success = true;

                returnValue.Message = "Üye eğitim katılım özeti çekildi.";
            }

            return returnValue;
        }

        private ResponseContainer<CreditCardResult> DoPayment(CreditCardLog creditCardData)
        {
            ResponseContainer<CreditCardResult> returnValue = new ResponseContainer<CreditCardResult>
            {
                Result = new CreditCardResult()
            };

            var paymentXmlResult = GetPaymentXmlText(creditCardData);

            string xmlMessage = string.Empty;

            if (paymentXmlResult.Success)
            {
                xmlMessage = paymentXmlResult.Result;
            }

            //oluşturduğumuz xml i vposa gönderiyoruz.
            byte[] dataStream = Encoding.UTF8.GetBytes("prmstr=" + xmlMessage);
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create("https://onlineodeme.vakifbank.com.tr:4443/VposService/v3/Vposreq.aspx");//Vpos adresi
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = dataStream.Length;
            webRequest.KeepAlive = false;
            string responseFromServer = "";

            using (Stream newStream = webRequest.GetRequestStream())
            {
                newStream.Write(dataStream, 0, dataStream.Length);
                newStream.Close();
            }

            using (WebResponse webResponse = webRequest.GetResponse())
            {
                using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    responseFromServer = reader.ReadToEnd();
                    reader.Close();
                }

                webResponse.Close();
            }

            if (string.IsNullOrEmpty(responseFromServer))
            {
                returnValue.Message = "Kredi kartı işlem talebi boş döndü.";
                return returnValue;
            }

            var xmlResponse = new XmlDocument();
            xmlResponse.LoadXml(responseFromServer);
            var resultCodeNode = xmlResponse.SelectSingleNode("VposResponse/ResultCode");
            var resultDescriptionNode = xmlResponse.SelectSingleNode("VposResponse/ResultDetail");

            if (resultCodeNode != null)
            {
                returnValue.Result.Code = resultCodeNode.InnerText;
            }
            if (resultDescriptionNode != null)
            {
                returnValue.Result.Description = resultDescriptionNode.InnerText;
            }

            returnValue.Message = string.Format("İşlem sonuç Kodu: {0}, Mesaj: {1}", returnValue.Result.Code, returnValue.Result.Description);
            returnValue.Success = true;

            return returnValue;
        }

        private ResponseContainer<string> GetPaymentXmlText(CreditCardLog creditCardData)
        {
            ResponseContainer<string> returnValue = new ResponseContainer<string>();

            XmlDocument xmlDoc = new XmlDocument();

            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);

            XmlElement rootNode = xmlDoc.CreateElement("VposRequest");
            xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement);
            xmlDoc.AppendChild(rootNode);

            //eklemek istediğiniz diğer elementleride bu şekilde ekleyebilirsiniz.
            XmlElement merchantNode = xmlDoc.CreateElement("MerchantId"); //*** Üye işyeri numarası
            XmlElement passwordNode = xmlDoc.CreateElement("Password"); //*** Üye işyeri şifresi
            XmlElement terminalNode = xmlDoc.CreateElement("TerminalNo"); //*** İşlemin hangi terminal üzerinden gönderileceği bilgisi. ÜİY için tanımlanmış mevcut terminallerden herhangi birinin terminal numarası iletilmelidir. Ör: VB007000,...
            XmlElement transactionTypeNode = xmlDoc.CreateElement("TransactionType");
            XmlElement transactionIdNode = xmlDoc.CreateElement("TransactionId");
            XmlElement currencyAmountNode = xmlDoc.CreateElement("CurrencyAmount");
            XmlElement currencyCodeNode = xmlDoc.CreateElement("CurrencyCode");
            XmlElement panNode = xmlDoc.CreateElement("Pan");
            XmlElement cvvNode = xmlDoc.CreateElement("Cvv");
            XmlElement expiryNode = xmlDoc.CreateElement("Expiry");
            XmlElement ClientIpNode = xmlDoc.CreateElement("ClientIp");
            XmlElement transactionDeviceSourceNode = xmlDoc.CreateElement("TransactionDeviceSource");
            //XmlElement installmentCount = xmlDoc.CreateElement("NumberOfInstallments");
            XmlElement cardHoldersName = xmlDoc.CreateElement("CardHoldersName");

            //yukarıda eklediğimiz node lar için değerleri ekliyoruz.
            XmlText merchantText = xmlDoc.CreateTextNode("000000000019125"); //***
            XmlText passwordtext = xmlDoc.CreateTextNode("SZYF6Y8GQI"); //***
            XmlText terminalNoText = xmlDoc.CreateTextNode("VP001896"); //***
            XmlText transactionTypeText = xmlDoc.CreateTextNode("Sale");
            XmlText transactionIdText = xmlDoc.CreateTextNode(creditCardData.Id.ToString("N"));
            XmlText currencyAmountText = xmlDoc.CreateTextNode(creditCardData.FormattedAmount); //tutarı nokta ile gönderdiğinizden emin olunuz.
            XmlText currencyCodeText = xmlDoc.CreateTextNode("949");
            XmlText panText = xmlDoc.CreateTextNode(creditCardData.CardNumber);
            XmlText cvvText = xmlDoc.CreateTextNode(creditCardData.Cvc);
            XmlText expiryText = xmlDoc.CreateTextNode(creditCardData.FormattedExpireDate);
            XmlText ClientIpText = xmlDoc.CreateTextNode(HttpContext.Current.Request.UserHostAddress);
            XmlText transactionDeviceSourceText = xmlDoc.CreateTextNode("0");
            //XmlText installmentCountText = xmlDoc.CreateTextNode(creditCardData.InstallmentType.Value.ToString());
            XmlText cardHoldersNameText = xmlDoc.CreateTextNode(creditCardData.FullName);

            //nodeları root elementin altına ekliyoruz.
            rootNode.AppendChild(merchantNode);
            rootNode.AppendChild(passwordNode);
            rootNode.AppendChild(terminalNode);
            rootNode.AppendChild(transactionTypeNode);
            rootNode.AppendChild(transactionIdNode);
            rootNode.AppendChild(currencyAmountNode);
            rootNode.AppendChild(currencyCodeNode);
            rootNode.AppendChild(panNode);
            rootNode.AppendChild(cvvNode);
            rootNode.AppendChild(expiryNode);
            rootNode.AppendChild(ClientIpNode);
            rootNode.AppendChild(transactionDeviceSourceNode);
            //rootNode.AppendChild(installmentCount);
            rootNode.AppendChild(cardHoldersName);

            //nodelar için oluşturduğumuz textleri node lara ekliyoruz.
            merchantNode.AppendChild(merchantText);
            passwordNode.AppendChild(passwordtext);
            terminalNode.AppendChild(terminalNoText);
            transactionTypeNode.AppendChild(transactionTypeText);
            transactionIdNode.AppendChild(transactionIdText);
            currencyAmountNode.AppendChild(currencyAmountText);
            currencyCodeNode.AppendChild(currencyCodeText);
            panNode.AppendChild(panText);
            cvvNode.AppendChild(cvvText);
            expiryNode.AppendChild(expiryText);
            ClientIpNode.AppendChild(ClientIpText);
            transactionDeviceSourceNode.AppendChild(transactionDeviceSourceText);
            //installmentCount.AppendChild(installmentCountText);
            cardHoldersName.AppendChild(cardHoldersNameText);

            returnValue.Result = xmlDoc.OuterXml;
            returnValue.Success = true;
            returnValue.Message = "Ödeme Xml text oluşturuldu.";

            return returnValue;
        }
    }
}
