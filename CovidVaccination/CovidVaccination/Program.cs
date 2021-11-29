using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccination
{
    class Program
    {
        public List<Vaccination> GetVaccination = new List<Vaccination>();
        public List<Benifiery> Benifieries = new List<Benifiery>();
        public int id = 1000;
        static void Main(string[] args)
        {
            Program p = new Program();
            /// <summary>
            //We adding  Benifieries details with name,age,city,phonenum
            /// <summary>
            p.id++;
            p.Benifieries.Add(new Benifiery
            {
                name = "rat",
                age = 20,
                city = "kanchipuram",
                phonenum = 31314,
                id = p.id
            });
            p.id++;
            p.Benifieries.Add(new Benifiery
            {
                name = "cat",
                age = 19,
                city = "kannyakumari",
                phonenum = 3647,
                id = p.id
            });
            p.GetVaccination.Add(new Vaccination
            {
                id=p.id,
                date = DateTime.Now,
                dosage = 0
            });
            p.GetVaccination.Add(new Vaccination
            {
                id = p.id-1,
                date = DateTime.Now,
                dosage = 1

            });
            p.GetVaccination.Add(new Vaccination
            {
                id = p.id-2,
                date = DateTime.Now,
                dosage = 2
            });
            do
            {
                Console.WriteLine("--------------Welcome to our vaccination page---------------");
                Console.WriteLine("*********************************************************");
                Console.WriteLine("Enter your option");
                Console.WriteLine("1.Benificiary registration");
                Console.WriteLine("2.Vaccination");
                Console.WriteLine("3.Exit");
                Console.WriteLine("*********************************************************");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            p.AddBenificiary();
                            break;
                        }
                    case 2:
                        {
                            p.Vaccine();
                            break;
                        }
                    case 3:
                        return;
                }
            } while (1 != 2);
           
        }
        /// <summary>
        /// This AddBenificiary method is used to add benifiery details.
        /// </summary>
        public void AddBenificiary()
        {
            Benifiery benifiery = new Benifiery();
            Console.WriteLine("Enter your name:");
            benifiery.name = Console.ReadLine();

            Console.WriteLine("Enter your age:");
            benifiery.age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your city:");
            benifiery.city = Console.ReadLine();

            Console.WriteLine("Enter your mobile number:");
            benifiery.phonenum = Convert.ToInt64(Console.ReadLine());
           
            
            Console.WriteLine("Choose gender");
            Console.WriteLine("1.Male");
            Console.WriteLine("2.Female");
            Console.WriteLine("3.unknown");
            Console.WriteLine("**************************************************************");
            benifiery.gender = int.Parse(Console.ReadLine());

            Console.WriteLine("**************************************************************");
            id++;
            benifiery.id = id;
            Benifieries.Add(benifiery);
            Console.WriteLine("Benificiary added successfully.your Registration Number is: {0}", benifiery.id);
            Console.WriteLine("**************************************************************");
        }
        /// <summary>
        /// This Vaccine method is used to show user details according to Registration number .
        /// </summary>
        public void Vaccine()
        {
            Benifiery Benifieryobj = new Benifiery();
            do
            {
                Console.WriteLine("Enter your Registration number for further details");
                Benifieryobj.id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your choice");
                Console.WriteLine("1.Take vaccination ");
                Console.WriteLine("2.Vaccination History");
                Console.WriteLine("3.Next due date");
                Console.WriteLine("4.Exit");
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {

                    case 1:
                        {
                            var check = GetVaccination.Where(x => x.id == Benifieryobj.id).Select(x => x).FirstOrDefault();
                            if(check==null)
                            {
                                Console.WriteLine("Enter type of vaccination");
                                Console.WriteLine("1.Covishield");
                                Console.WriteLine("2.Covaxin");
                                Console.WriteLine("3.sputnik");
                                int option = Convert.ToInt32(Console.ReadLine());
                                if(option==1|| option == 2|| option == 3)
                                Console.WriteLine("you have Registered for 1st dose");
                                string type = option.ToString();

                                GetVaccination.Add(new Vaccination
                                {
                                    id = Benifieryobj.id,
                                    date = DateTime.Now,
                                    Vaccinename=type,
                                    dosage = 1
                                });
                            }
                            else if(check.dosage==1)
                            {
                                GetVaccination.Where(x => x.id == Benifieryobj.id).ToList().ForEach(x => x.dosage = 2) ;
                                Console.WriteLine("vaccination 2nd dose done");
                            }
                            else 
                            {
                                Console.WriteLine(" you have already done vaccination ");
                            }
                            break;
                        }
                    /// <summary>
                    //This 2nd case shows vaccination history of benificiary .
                    /// <summary>
                    case 2:
                        {
                            Console.WriteLine("your vacinnation history is");
                            var history = GetVaccination.Where(x => x.id == Benifieryobj.id).Select(x => x).ToList();
                            if (history != null && history.Count > 0)
                            {
                                foreach (var vaccine in history)
                                {
                                    Console.WriteLine("your vacinnation name is {0} :",vaccine.Vaccinename);
                                    Console.WriteLine("you completed the dosage of {0}:", vaccine.dosage);
                                }
                            }
                            break;
                        }
                    /// <summary>
                    /// This 3rd case shows the next due date of benificiary according to registration number .
                    /// </summary>
                    case 3:
                        {
                            
                            var check = GetVaccination.Where(x => x.id == Benifieryobj.id).Select(x => x).FirstOrDefault();
                            if (check == null)
                            {
                                Console.WriteLine("you have not vaccinated");
                            }
                            else if (check.dosage == 1)
                            {

                                var nextDueDate = check.date.AddDays(30).ToString();
                                Console.WriteLine("your next due date  is: {0} ", nextDueDate);
                            }
                            else
                            {
                                Console.WriteLine("you have completed 2 dosage of vaccinations");
                            }
                                break;

                        }
                    default:
                        return;

                }
            } while (1 != 2);
            var value = GetVaccination.Where(x => x.id != Benifieryobj.id).Select(x => x).FirstOrDefault();
            Console.WriteLine("Invalid registration number. Please enter valid one");
        }

    }
}
