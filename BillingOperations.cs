using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBillingSytem
{
    class BillingOperations : IBillingOperations
    {
        public SqlConnection SqlCon { get; set; }

        public BillingOperations() { }

        public bool AddRecord(BillInformation billinformation)
        {
            try
            {
                string queryString = "insert into MedicalBillingDB values('" + billinformation.PatientId + "','" + billinformation.PatientName + "','" + billinformation.MobileNumber + "','" + billinformation.BillAmount + "','" + billinformation.PaymentDate + ")";
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand(queryString, SqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                SqlCon.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<BillInformation> DisplayRecords()
        {
            try
            {
                string queryString = "Select * FROM MedicalBillingDB ORDER BY PatientId";
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand(queryString, SqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                List<BillInformation> billList = new List<BillInformation>();

                while (reader.Read())
                {
                    BillInformation billInfo = new BillInformation();
                    billInfo.PatientId = (int)reader[0];
                    billInfo.PatientName = reader[1].ToString();
                    billInfo.MobileNumber = (long)reader[2];
                    billInfo.BillAmount = (double)reader[3];
                    billInfo.PaymentDate = (DateTime)reader[5];

                    billList.Add(billInfo);

                }

                SqlCon.Close();
                return billList;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error 1: " + e.Message);
            }
            return null;
        }

        public bool EditRecord(double billAmount, int patientId)
        {
            try
            {
                string queryString = "UPDATE MedicalBillingDB SET Bill_Amount = '" + billAmount + "'WHERE Patient_Id='" + patientId;
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand(queryString, SqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                SqlCon.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
