using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;
using System.IO;
using DataBasePerson;
using System.Net.Sockets;

namespace Server
{
    
    public class Logic
    {
        string connection = $"Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename ={ Directory.GetCurrentDirectory()}" + "\\message2.mdf;" + " Integrated Security = True; Connect Timeout = 30";
        static public List<Group> group = new List<Group>();
        static public List<ClientInfo> clientsOnline = new List<ClientInfo>();
        public static void AddGroup(Group info)
        {
            lock (group)
            {
                var ob1 = group.FirstOrDefault(x => x.NameGroup == info.NameGroup && x.People == info.People);
                if (ob1 == null)
                {
                    group.Add(info);
                    
                }
                     
            }
        }
        public static List<Group> GetAllGroup()
        {
            return group;
        }
        public static void RemoveGroup(string n,string l)
        {
            for (int i = 0; i < group.Count; i++)
            {
                if (group[i].NameGroup == n && group[i].People == l)
                {
                    group.RemoveAt(i);
                    
                }
            }
        }


        public static void RemoveClient(TcpClient tcp)
        {
            for (int i = 0; i < clientsOnline.Count; i++)
            {
                if (clientsOnline[i].tcpClient == tcp)
                {
                    clientsOnline.RemoveAt(i);
                    break;
                }
            }
        }

        public static void AddBaseMessage(SMS info)
        {
            string connection = $"Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename ={ Directory.GetCurrentDirectory()}" + "\\message2.mdf;" + " Integrated Security = True; Connect Timeout = 30";
            var Db = new DataContext(connection);
            //var T = Db.Person.FirstOrDefault((x) => x.Login == "kirill");

            //Sent i = new Sent() {Date = DateTime.Now,Message="hi",Fromperson = T.Login,WhichPerson= "Igor" };
            //T.SentId = new List<Sent>();
            //T.SentId.Add(i);
            Db.SaveChanges();
            Db.Dispose();
        }

        public static bool CanConnect(ClientInfo info)
        {
            string connection = $"Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename ={ Directory.GetCurrentDirectory()}" + "\\message2.mdf;" + " Integrated Security = True; Connect Timeout = 30";
            var Db = new DataContext(connection);
            
            lock (clientsOnline)
            {
                var ob1 = clientsOnline.FirstOrDefault(x => x.Login == info.Login);
                if (ob1 == null)
                {
                    clientsOnline.Add(info);
                    var T = Db.Person.FirstOrDefault((x) => x.Login == info.Login);
                    if(T==null)
                    {
                        Db.Person.Add(new Person() { Login = info.Login});
                    }
                    Db.SaveChanges();
                    Db.Dispose();
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            return true;
        }
        
        public static List<ClientInfo> GetAllCLients()
        {
            return clientsOnline;
        }

        public static List<ClientInfo> GetCLientsWithOut(String login)
        {
            return clientsOnline.Where(x => x.Login == login).ToList();
        }

        


        //public void AddNewPerson(Login Person)
        //{
        //    var Db = new DataContext(connection);
        //    Db.Data.Add(new Data { Login = Person.name, Password = Person.Password });
        //    Db.SaveChanges();
        //    Db.Dispose();
        //}

        //public List<Login> GetPositionPerson()
        //{
        //    List<Login>  tmp = new List<Login>();
        //    var Db = new DataContext(connection);
        //    foreach (var i in Db.Data)
        //    {
        //        tmp.Add(new Login { name = i.Login, Password = i.Password });
        //    }

        //    Db.Dispose();
        //    return tmp;
        //}
        //public void SendLoginPassword(Login Person)
        //{

        //}
    }
}
