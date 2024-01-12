﻿using Restaurant_C__Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.Design;
namespace Restaurant_C__Project
{
       public class Reservations
    {
        public int ReserveId { get; set; }
        //public int ReserveTime { get; set; }
        public string ReserveDate { get; set; }  //concat of month + day + hour
        public Customer Customer { get; set; }
        public string ReservedTableNo { get; set; }
        public int CustomerId { get; set; }

        public static List<Reservations> Reservants { get; set; } = new List<Reservations>();
        public List<DiningTable> DinningTableList { get; set; } = new List<DiningTable>();

        public Reservations() { }

        public Reservations( string ReserveDate, string reservantTableno, Customer customer)
        {
            Random R = new Random();
            this.ReserveId = R.Next();
            this.ReserveDate = ReserveDate;
            this.ReservedTableNo = reservantTableno;
            Customer = customer;


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
        public static bool CheckReservation(int TableNo, string ReserveMonth, string ReserveDay, string ReserveTime)
        {
            bool boolean = false;
            foreach (var Item in Reservants)
            {
                if (Item.ReservedTableNo == TableNo && Item.ReserveDate == ReserveMonth + ReserveDay + )
                {



                    //for (int i = 0; i <= 2; i++)
                    //{
                    //    if (Item.ReserveDate.Substring(6,2) + i)
                    //    {
                    //        Console.WriteLine("this table is not available");
                    //        boolean = false;
                    //    }
                    //    else if (Item.ReserveTime - i == ReserveTime)
                    //    {
                    //        Console.WriteLine("this table is not available");
                    //        boolean = false;
                    //    }
                    //}

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
                //Console.WriteLine("Reservant Name is: " + item.Customer.FullName);
                //Console.WriteLine("Reservant Phone is: " + item.Customer.PhoneNumber);
                Console.WriteLine("Reservation ID is: " + item.ReserveId);
                //Console.WriteLine("Reservation Date is: " + item.ReserveDate);
                Console.WriteLine("Reservation Time is: " + item.ReserveTime);
                Console.WriteLine("Customer ID is: " + item.CustomerId);
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
        //public void ShowActiveReservatioList(int FromTime, int ToTime)
        //{
        //ShowActiveReservatioListAgain:
        //    DiningTable dinTable;
        //    dinTable ShowTables();
        //    Console.WriteLine("please, enter start time of reservation");
        //    int fromTime = int.Parse(Console.ReadLine());
        //    Console.WriteLine("please, enter end time of reservation");
        //    int toTime = int.Parse(Console.ReadLine());
        //    bool isAvailable = false;
        //    foreach (var Item in Reservants)
        //    {
        //        if (Item.ReserveTime in(FromTime, ToTime))
        //        {
        //            isAvailable = true;
        //            Console.WriteLine(Item);
        //        }
        //    }
        //    if (isAvailable == false)
        //    {
        //        Console.WriteLine("there is no tables available on this time");
        //        goto ShowActiveReservatioListAgain;
        //    }

        //}
        //////???????????????????????????
        public static void ReserveTable(int TableNo, string ReserveDate)
        {
            DinningTableList.AddRange(new List<int> { TableNo, ReserveDate });
            //foreach (var item in Reservants)
            //{
            //    Console.WriteLine(item);
            //}
        }
        //////////////////////////////////////////////////////
        /////done


    }
}
