using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Business.Interfaces;
using SRC.Library.Constants.LogKey;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Domain.Facade.Interfaces;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;

namespace SRC.Library.Domain.Facade
{
    public class EducationFacade : IEducationFacade
    {
        private IEducationBusiness _educationBusiness;
        private IEducationAttendanceBusiness _educationAttendanceBusiness;
        private IBaseBusiness<EducationAttendance> _baseEducationAttendanceBusiness;
        private IBaseBusiness<CreditCardLog> _baseCreditCardBusiness;

        public EducationFacade(IEducationBusiness educationBusiness, IEducationAttendanceBusiness educationAttendanceBusiness,
            IBaseBusiness<EducationAttendance> baseBusiness, IBaseBusiness<CreditCardLog> baseCreditCardBusiness)
        {
            _educationBusiness = educationBusiness;
            _educationAttendanceBusiness = educationAttendanceBusiness;
            _baseEducationAttendanceBusiness = baseBusiness;
            _baseCreditCardBusiness = baseCreditCardBusiness;
        }

        public List<Education> GetEducations(int? month, int? year)
        {
            month.CheckNull("Ay boş olamaz!", EducationLogKeys.MONTH_NULL);
            month.CheckNull("Yıl boş olamaz!", EducationLogKeys.YEAR_NULL);

            DateTime startDate = new DateTime((int)year, (int)month, 1);
            DateTime endDate = startDate.AddMonths(1);

            return _educationBusiness.GetEducations(startDate, endDate);
        }

        public List<Education> GetEducationsOfAttendances(List<EducationAttendance> attendances)
        {
            return _educationBusiness.GetEducationsOfAttendances(attendances);
        }

        public List<EducationAttendance> GetContactAttendances(Guid? contactId)
        {
            contactId.CheckNull("Üye bilgisi boş olamaz!", ContactLogKeys.CONTACT_NULL);

            return _educationAttendanceBusiness.GetEducations((Guid)contactId);
        }

        public Guid CreateEducationAttendance(EducationAttendance educationAttendance)
        {
            educationAttendance.CheckNull("Eğitim katılım bilgisi boş olamaz!", EducationAttendanceLogKeys.EDUCATION_ATTENDANCE_NULL);
            return _baseEducationAttendanceBusiness.Insert(educationAttendance);
        }

        public void CancelEducationAttendance(Guid? educationAttendanceId)
        {
            educationAttendanceId.CheckNull("Eğitim katılım bilgisi boş olamaz!", EducationAttendanceLogKeys.EDUCATION_ATTENDANCE_ID_NULL);
            EducationAttendance educationAttendance = new EducationAttendance()
            {
                Id = (Guid) educationAttendanceId,
                Status = EducationAttendance.StatusCode.PARTICIPANT_CANCELED.ToOptionSetValueWrapper()
            };

            _baseEducationAttendanceBusiness.Update(educationAttendance);
        }

        public void SetEducationAttendance(List<Education> educations, List<EducationAttendance> educationAttendances)
        {
            foreach (Education education in educations)
            {
               education.Attendance = educationAttendances.FirstOrDefault(p => p.Education.Id == education.Id);
            }
        }

        //TODO: Burada olması doğru mu?
        public Guid CreateCreditCard(CreditCardLog creditCard)
        {
            creditCard.CheckNull("Kredi kartı bilgisi boş olamaz!", CreditCardLogKeys.CREDIT_CARD_NULL);
            return _baseCreditCardBusiness.Insert(creditCard);
        } 
    }
}
