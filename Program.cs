using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MedicalBillingSytem
{
    class Program
    {
        static void Main(string[] args)
        {
            DBHandler db = new DBHandler();
            SqlConnection con = db.GetConnection();
            Console.WriteLine("Menu:");
            Console.WriteLine("Press 1 to enter new record");
            Console.WriteLine("Press 2 to display record");
            Console.WriteLine("Press 3 to edit record");
            Console.WriteLine("Enter your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());

            while (true)
            {


                if (choice == 1)
                {
                    Console.WriteLine("Enter Patient Name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter Patient Mobile Number:");
                    long mobile = long.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Bill Amount");
                    double amount = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter Bill Payment Date(in dd / MM / yyyy format):");
                    DateTime date = Convert.ToDateTime(Console.ReadLine());

                    BillInformation BillInfo = new BillInformation();
                    BillingOperations BillOp = new BillingOperations();

                    try
                    {
                        BillInfo.PatientName = name;
                        BillInfo.MobileNumber = mobile;
                        BillInfo.BillAmount = amount;
                        BillInfo.PaymentDate = date;

                        BillOp.SqlCon = con;
                        BillOp.AddRecord(BillInfo);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                }
                else if (choice == 2)
                {
                    BillingOperations BillOp = new BillingOperations();
                    BillOp.SqlCon = con;
                    Console.WriteLine("Display All Medical Bills");
                    List<BillInformation> bills =(List<BillInformation>)BillOp.DisplayRecords();
                    foreach(var e in bills)
                    {
                        Console.WriteLine("Patient Id \t PatientName \t MobileNumber \t BillAmount \t PaymentDate");
                        Console.WriteLine(((BillInformation)e).PatientId + "\t" + ((BillInformation)e).PatientName + "\t" + ((BillInformation)e).MobileNumber + "\t" + ((BillInformation)e).BillAmount + "\t" + ((BillInformation)e).PaymentDate);
                    }

                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter Patient ID to Search:");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter New Bill Amount");
                    double amount = Convert.ToDouble(Console.ReadLine());

                    try
                    {
                        BillingOperations BillOp = new BillingOperations();
                        BillOp.SqlCon = con;
                        BillOp.EditRecord(amount, id);
                        Console.WriteLine("Medical Bill Record Successfully Inserted");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                else
                {

                }


                Console.WriteLine("Press YES to repeat Menu...Any other key to stop");
                string repeat = Console.ReadLine();
                if(repeat=="yes" || repeat=="Yes" || repeat == "Yes")
                {
                    continue;
                }
                else
                {
                    break;

                }



            }

        }

        
    }
}
