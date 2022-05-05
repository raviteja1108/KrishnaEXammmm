using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBillingSytem
{
    public class BillAmountValidator
    {
        public string BillValidator(double billAmount)
        {
            if (billAmount < 0)
            {
                return "Invalid Bill Amount";
            }
            else
            {
                return "";
            }
        }
    }
}
