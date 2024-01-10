using Restaurant_C__Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.Design;
namespace Restaurant_C__Project
{
    internal class Reservations
    {
        public int ReserveId { get; set; }
        public int ReserveTime { get; set; }

        public int ReserveDate { get; set; }
        public string ReservantName { get; set; }
        public string ReservantPhone { get; set; }
        public int ReservedTableNo { get; set; }

        public static List<Reservations> Reservants { get; set; } = new List<Reservations>();
        public List<DiningTable> DinningTableList { get; set; } = new List<DiningTable>();

        public Reservations() { }

        public Reservations(string ReservantName, string Reservantphone, int reservantTableno)
        {
            Random R = new Random();
            this.ReserveId = R.Next();


        }
        //done
        public static void LoadAllReserervisionFromJson(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                Reservants = JsonConvert.DeserializeObject<List<Reservations>>(json);
            }
        }
        //done
    public void AddToReservation()
        {
            Reservants.Add(this);
        }
        //done
        
        public void RemoveFromReservation(int ReserveId)
        {
            foreach (var Item in Reservants)
            {
                if (ReserveId == Item.ReserveId)
                {
                    Reservants.Remove(Item);
                }
            }
        }
        //done
        public void DeleteAllReservation()
        {
            Reservants.Clear();
        }
        public static void SaveReservationToJson(string JsonFile)
        {
            string json = JsonConvert.SerializeObject(Reservants, Formatting.Indented);
            File.WriteAllText(JsonFile, json);
        }
        public bool CheckReservation(int TableNo, int ReserveTime, int ReserveDate)
        {
            bool boolean = false;
            foreach (var Item in Reservants)
            {
                if (Item.ReservedTableNo == TableNo && Item.ReserveDate == ReserveDate)
                {



                    for (int i = 0; i <= 3; i++)
                    {
                        if (Item.ReserveTime + i == ReserveTime)
                        {
                            Console.WriteLine("this table is not available");
                            boolean = false;
                        }
                        else if (Item.ReserveTime - i == ReserveTime)
                        {
                            Console.WriteLine("this table is not available");
                            boolean = false;
                        }

                    }

                }

                else { boolean = true; }



            }
            return boolean;
        }
        public static void SaveOrderToJson(string JsonFile)
        {
            string json = JsonConvert.SerializeObject(Reservants, Formatting.Indented);
            System.IO.File.WriteAllText(JsonFile, json);
        }
        public static void ShowReservations()
        {
            foreach (var item in Reservants)
            {
                Console.WriteLine("Reservant Name is: " + item.ReservantName);
                Console.WriteLine("Reservant Phone is: " + item.ReservantPhone);
                Console.WriteLine("Reservation ID is: " + item.ReserveId);
                Console.WriteLine("Reservation Date is: " + item.ReserveDate);
                Console.WriteLine("Reservation Time is: " + item.ReserveTime);
                Console.WriteLine("Reservation Table Number is: " + item.ReservedTableNo);
                Console.WriteLine("*************************************************************");
            }
        }
        //public void RemoveFromReservation(Reservations Reservant)
        //{
        //    foreach (var Item in Reservants)
        //    {
        //        if (Reservant.ReserveId == Item.ReserveId)
        //        {
        //            Reservants.Remove(Item);
        //        }
        //    }
        //}
        ////done
        //public void DeleteAllReservation()
        //{
        //    Reservants.Clear();
        //}
        //////////???????????????????????????????????
        ////public void ShowActiveReservatioList(int FromTime,int ToTime)
        ////{
        ////    bool isAvailable = false;
        ////    foreach (var Item in Reservants)
        ////    {
        ////        if (Item.ReserveTime in(FromTime,ToTime))
        ////        {
        ////            isAvailable = true;
        ////            Console.WriteLine(Item);
        ////        }
        ////    }
        ////    if(isAvailable==false)
        ////    {
        ////        Console.WriteLine("there is no tables available on this time");
        ////    }

        ////   // Console.WriteLine(Reservants);
        ////}
        //////???????????????????????????
        //public void ReserveTable(int TableNo, int ReserveTime)
        //{
        //    DinningTableList.AddRange(new List<int> { TableNo, ReserveTime });
        //    foreach (var item in Reservants)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}
        //////////////////////////////////////////////////////
        /////done


    }
}
