using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.IO;
using DataBasePerson;
using System.Threading;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start ");

            //string a = Directory.GetCurrentDirectory();
            //string connection = $"Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = { Directory.GetCurrentDirectory()} " + "\\Login.mdf;" + " Integrated Security = True; Connect Timeout = 30";
            string connection = $"Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename ={ Directory.GetCurrentDirectory()}" + "\\Login.mdf;" + " Integrated Security = True; Connect Timeout = 30";
            ////Console.WriteLine(connection);
            ////Console.ReadKey();
            ////string a = Directory.GetCurrentDirectory();
            //var Db = new DataContext(connection);
            ////Db.Data.Add(new Data() { Login="Andrey",Password="347888" });
            //var res = from i in Db.Data
            //          select i;

            //foreach (var t in res)
            //{
            //    Console.WriteLine(t.Login);
            //}
            //////Db.SaveChanges();
            //Db.Dispose();
            //Console.WriteLine(a);
            //string connection = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + a+"\\"+"Baza.mdf;"+" Integrated Security = True; Connect Timeout = 30";
            ////Console.WriteLine(connection);
            //var Db = new DataContext(connection);
            //////Db.Phone.Add(new Data() { PhoneNumber = "+380731666666", Message = "hello", Date = "22" });
            ////var res = from i in Db.Phone
            ////          select i;
            ////foreach (var t in res)
            ////{
            ////    Console.WriteLine(t.PhoneNumber);
            ////}

            //////Db.SaveChanges();
            //////Db.Dispose();

            //List<Contract.SMS> a = new List<Contract.SMS>();
            //string dateString = "5/1/2008 7:30:52 AM";

            //string dateString1 = "5/1/2017 8:30:52 AM";
            //string dateString2 = "5/1/2017 9:30:52 AM";
            //string dateString3 = "5/1/2017 10:30:52 AM";
            //DateTime date1 = DateTime.Parse(dateString,
            //                          System.Globalization.CultureInfo.InvariantCulture);
            //DateTime date2 = DateTime.Parse(dateString1,
            //                          System.Globalization.CultureInfo.InvariantCulture);
            //DateTime date3 = DateTime.Parse(dateString2,
            //                          System.Globalization.CultureInfo.InvariantCulture);
            //DateTime date4 = DateTime.Parse(dateString3,
            //                          System.Globalization.CultureInfo.InvariantCulture);
            //a.Add(new Contract.SMS() { Login = "Hello", kLogin = "Hello", Date = date2 });
            //a.Add(new Contract.SMS() { Login = "Hello", kLogin = "Hello", Date = date1 });
            //a.Add(new Contract.SMS() { Login = "Hello", kLogin = "Hello", Date = date4 });
            //a.Add(new Contract.SMS() { Login = "Hello", kLogin = "Hello", Date = date3 });
            //var query =
            //from m in a
            //orderby m.Date ascending
            //select m;

            //foreach(var i in query)
            //{
            //    Console.WriteLine(i.Date);
            //}


            //NetServer ns = new NetServer();
            //ns.StartServer();
            //Console.ReadKey();

        }
    }
}
