using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBillingSytem
{
    public interface IBillingOperations
    {
        public bool AddRecord(BillInformation billinformation);

        public IList<BillInformation> DisplayRecords();

        public bool EditRecord(double billAmount, int patientId);
    }
}
