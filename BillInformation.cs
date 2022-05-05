using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBillingSytem
{
    public class BillInformation
    {
        //Properties
        public int PatientId { get; set; } 
        public string PatientName { get; set; }
        public long MobileNumber { get; set; }
        public double BillAmount { get; set; }
        public DateTime PaymentDate { get; set; }

        //Methods


        //Default Constructor
        public BillInformation()
        {
            //Default Constructor
        }

        //Parametrized Constructor
        public BillInformation(int patientId, string patientName, long mobileNumber,double billAmount, DateTime paymentDate)
        {
            this.PatientId = patientId;
            this.PatientName = patientName;
            this.MobileNumber = mobileNumber;
            this.BillAmount = billAmount;
            this.PaymentDate = paymentDate;
        }

    }
}
