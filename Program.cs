using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LTTTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] name = new string[100]; string FName = null, LName = null;
            string[] dob = new string[100]; string[] regNo = new string[100];
            string[] course = new string[100];
            float[] admFee = new float[100]; float tFee = 0.0F;
            int[] mNum = new int[100]; int[] admId = new int[100]; int adFee, admNum = 1000;
            string Course = null; string UserId = null;
            string PassKey = null; string reg = null;
            bool stats = true;
            int status = 1, choice, i;
            do{
                Console.Write("\nEnter UserId: ");
                UserId = Console.ReadLine();
                Console.Write("Enter PassKey: ");
                PassKey = Console.ReadLine();
                if (UserId != "name" || PassKey != "abc@123")
                {
                    Console.WriteLine("Validating.......");
                    Thread.Sleep(500);
                    Console.WriteLine("Invalid UserId and PassKey");
                    status++;
                }
            } while (status <= 3 && PassKey != "abc@123");
            if (UserId == "Name" && PassKey == "abc@123")
            {
                Console.WriteLine("\n\t----------> ENTER STUDENT DETAILS <----------");
                Console.Write("\n\tEnter No Of Students: ");
                int n = int.Parse(Console.ReadLine());
                for (i = 0; i < n; i++)
                {
                    Console.WriteLine($"\n\t\t\t\tSTUDENT.{i + 1} DETAILS: ");
                    Console.Write("\n\tEnter First Name: ");
                    FName = Console.ReadLine();
                    Console.Write("\tEnter Last Name: ");
                    LName = Console.ReadLine();
                    name[i] = FName + " " + LName;
                    Console.Write("\tEnter Date Of Birth(DD/MM/YYYY): ");
                    dob[i] = Console.ReadLine();
                    if (i == 0)
                    {
                        Console.Write("\tEnter Register Number: ");
                        reg = Console.ReadLine();
                        regNo[i] = reg;
                    }
                    else{
                        do{
                            Console.Write("\tEnter Register Number: ");
                            reg = Console.ReadLine();
                            for (int j = 0; j < i; j++)
                            {
                                if (reg != regNo[j])
                                { regNo[i] = reg; stats = true; break; }
                                else
                                    Console.WriteLine("\tRegister Num Already Exist...!!"); stats = false;
                            } } 
                        while (!stats);}
                    Console.Write("\tEnter Course: ");
                    course[i] = Console.ReadLine();
                    Console.Write("\tEnter Admission Fee: ");
                    adFee = int.Parse(Console.ReadLine());
                    admFee[i] = adFee + (adFee * 0.18F);
                    Console.Write("\tEnter Mobile Number: ");
                    mNum[i] = int.Parse(Console.ReadLine());
                    admId[i] = admNum + 1;}
                do{
                    Console.WriteLine("\n\t\t************ Student Details ************");
                    Console.WriteLine("\n\t1.Display All Students");
                    Console.WriteLine("\t2.Show Total Admission Fee");
                    Console.WriteLine("\t3.Search Student By Course");
                    Console.WriteLine("\t4.EXIT");
                    Console.Write("\nEnter Choice: ");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n\n  StudentName | DateOfBirth | RegisterNumber | Course | AdmissionFees | MobileNumber | AdmissionID\n");
                            for (i = 0; i < n; i++)
                            {
                                Console.WriteLine($"  {name[i]}\t| {dob[i]} |\t {regNo[i]}\t|\t {course[i]}\t|\t {admFee[i]} \t| {mNum[i]} \t|\t {admId[i]}");
                            }
                            break;
                        case 2:
                            for (i = 0; i < n; i++)
                            {
                                tFee = tFee + admFee[i];
                            }
                            Console.WriteLine($"\n------------- Total Admission Fee: {tFee}");
                            break;
                        case 3:
                            Console.Write("\n\tEnter Course: ");
                            Course = Console.ReadLine();
                            for (i = 0; i < n; i++){
                                if (course[i] == Course)
                                {
                                    Console.WriteLine($"\t\t{i + 1}. {name[i]}");
                                }}
                            break;
                        case 4: Console.WriteLine("\n\t\t\t.............Exiting Application............."); break;
                        default: Console.WriteLine("\n\t...........Invalid Input, Returning to main menu............."); Thread.Sleep(1000); break;
                    }
                } while (choice != 4);}
            else
                Console.WriteLine("\n\t------------->>> Try After SomeTime<<<-------------");
        }
    }
}
