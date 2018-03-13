using Contract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    public class NetClient
    {
        TcpClient tcp;
        BinaryFormatter serializer;
        public ObservableCollection<LoginColor> Data;
        public ObservableCollection<SMS> SmsInfo;
        public ObservableCollection<SMS> ALLmessage;
        public String MyLogin { get; set; }
        public void AddMyMessege(string klogin, string Message,string w)
        {
            SmsInfo.Add(new SMS() { Login = klogin, kLogin = "Я", Date = DateTime.Now, Message = Message,Way =w });

        }
        public ObservableCollection<SMS> SMSss(string NickName)
        {
            ObservableCollection<SMS> temporary = new ObservableCollection<SMS>();
            ObservableCollection<SMS> temporary2 = new ObservableCollection<SMS>();
            
            foreach (var i in ALLmessage)
            {

                if (i.kLogin == NickName)
                {
                    temporary.Add(i);
                }
            }
            foreach (var i in SmsInfo)
            {

                if (i.kLogin == "Я" )
                {

                    temporary.Add(i);
                }
            }
            var query =
            from m in temporary
            orderby m.Date ascending
            select m;
            foreach (var i in query)
            {
                temporary2.Add(i);

            }
            return temporary2;
        }

        

        public ObservableCollection<SMS> CLIENT(string nickName)
        {

            ObservableCollection<SMS> temporary = new ObservableCollection<SMS>();
            ObservableCollection<SMS> temporary2 = new ObservableCollection<SMS>();
            foreach (var i in ALLmessage)
            {

                if (i.kLogin == nickName)
                {
                    temporary.Add(i);
                }
            }

            


            foreach (var i in SmsInfo)
            {

                if (i.kLogin == "Я" && i.Login == nickName)
                {

                    temporary.Add(i);
                }
            }
            var query =
            from m in temporary
            orderby m.Date ascending
            select m;
            foreach (var i in query)
            {
                temporary2.Add(i);

            }

            return temporary2;
        }

        public ObservableCollection<SMS> CLIENTGROUP(string nickName)
        {

            ObservableCollection<SMS> temporary = new ObservableCollection<SMS>();
            ObservableCollection<SMS> temporary2 = new ObservableCollection<SMS>();
            foreach (var i in ALLmessage)
            {

                if (i.NameGroup == nickName)
                {
                    
                    temporary.Add(i);
                }
            }
            var query =
            from m in temporary
            orderby m.Date ascending
            select m;
            foreach (var i in query)
            {
                temporary2.Add(i);

            }

            return temporary2;
        }

        public ObservableCollection<LoginColor> ChangeColorNickName(string NickName)
        {

            ObservableCollection<LoginColor> temporary = new ObservableCollection<LoginColor>();
            foreach (var i in Data)
            {
                if (i.Login == NickName)
                {

                    temporary.Add(new LoginColor() { Login = NickName, GetLoginColor = "LightCyan" });
                }
                else
                {
                    temporary.Add(i);
                }
            }
            Data.Clear();
            foreach (var i in temporary)
            {
                Data.Add(i);

            }
            return Data;
        }

        public void ChangeColorNickNameGetSms(string NickName)
        {

            ObservableCollection<LoginColor> temporary = new ObservableCollection<LoginColor>();
            foreach (var i in Data)
            {
                if (i.Login == NickName)
                {

                    temporary.Add(new LoginColor() { Login = NickName, GetLoginColor = "Red" });
                }
                else
                {
                    temporary.Add(i);
                }
            }
            Data.Clear();
            foreach (var i in temporary)
            {
                Data.Add(i);
            }
        }

        public void ChangeColorNickNameGetSmsGroup(string NickName)
        {

            ObservableCollection<LoginColor> temporary = new ObservableCollection<LoginColor>();
            foreach (var i in Data)
            {
                if (i.Login == NickName)
                {

                    temporary.Add(new LoginColor() { Login = NickName, GetLoginColor = "Red" });
                }
                else
                {
                    temporary.Add(i);
                }
            }
            Data.Clear();
            foreach (var i in temporary)
            {
                Data.Add(i);
            }
        }



        public NetClient()
        {
            serializer = new BinaryFormatter();
            Data = new ObservableCollection<LoginColor>();
            SmsInfo = new ObservableCollection<SMS>();
            ALLmessage = new ObservableCollection<SMS>();
        }
        public bool Authentification(string login)
        {
            tcp = new TcpClient();
            tcp.Connect(new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 12345));
            //не отсылается команда, так как это первый запрос и если он не пройдет, то на сервере закроют соединение
            serializer.Serialize(tcp.GetStream(), login);
            BinaryReader br = new BinaryReader(tcp.GetStream());
            bool result = br.ReadBoolean();
            //Запускаем новый поток, который будет слушать с сервера информацию
            if (result)
                new Thread(Subscriber) { IsBackground = true }.Start(tcp);
            else
                tcp.Close();
            return result;
        }

        public void UpdateUsers(string login)
        {
            List<LoginColor> queryUsers = new List<LoginColor>();
            tcp.GetStream().WriteByte((byte)CommandToServer.AllUsers);
            serializer.Serialize(tcp.GetStream(), queryUsers);
        }

        public void SendMessage(String message, String Login, String kLogin, String FileName, byte[] b, bool t)
        {
            SMS sms = new SMS() { Login = Login, Message = message, kLogin = kLogin, Date = DateTime.Now, fileName = FileName, file = b, filetrue = t };
            ALLmessage.Add(sms);
            tcp.GetStream().WriteByte((byte)CommandToServer.SendMessage);
            serializer.Serialize(tcp.GetStream(), sms);
        }

        public void SendMessageGroup(String message, String Login, String kLogin, String FileName, byte[] b, bool t)
        {
            
            SMS sms = new SMS() { NameGroup=kLogin, Login = Login, Message = message, kLogin = Login, Date = DateTime.Now, fileName = FileName, file = b, filetrue = t };
            tcp.GetStream().WriteByte((byte)CommandToServer.SendMessageGroup);
            serializer.Serialize(tcp.GetStream(), sms);
        }

        public void SendSMILE(String message, String Login, String kLogin, String FileName, byte[] b, bool t, string nameSmile)
        {

            SMS sms = new SMS() { Login = Login, Message = message, kLogin = kLogin, Date = DateTime.Now, fileName = FileName, file = b, filetrue = t ,Way = nameSmile};
            //ALLmessage.Add(sms);
            tcp.GetStream().WriteByte((byte)CommandToServer.SendMessage);
            serializer.Serialize(tcp.GetStream(), sms);
        }


        public void SendDeleteGroup(string NameGroup)
        {
            Group g = new Group() { NameGroup = NameGroup, People = MyLogin };
            tcp.GetStream().WriteByte((byte)CommandToServer.DeleteGroup);
            serializer.Serialize(tcp.GetStream(), g);
        }


        public void SendCreateNewGroup(string NameGroup)
        {
            
            Group g = new Group() { NameGroup = NameGroup, People = MyLogin };
            tcp.GetStream().WriteByte((byte)CommandToServer.CreateGroup);
            serializer.Serialize(tcp.GetStream(), g);
        }

        public void SendAddPeopleGroup(string NameGroup,string people)
        {
            Group g = new Group() { NameGroup = NameGroup, People = people };
            tcp.GetStream().WriteByte((byte)CommandToServer.CreateGroup);
            serializer.Serialize(tcp.GetStream(), g);
        }

        public void Exit()
        {
            try
            {
                tcp.GetStream().WriteByte((byte)CommandToServer.Exit);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void Subscriber(Object ob1)
        {
            TcpClient serverListener = ob1 as TcpClient;
            while (true)
            {

                if (serverListener.GetStream().DataAvailable)

                    switch ((CommandToClient)serverListener.GetStream().ReadByte())
                    {
                        case CommandToClient.Message:
                            var str = serializer.Deserialize(serverListener.GetStream()) as SMS;
                            App.Current.Dispatcher.Invoke(() =>
                            {
                                string path = Directory.GetCurrentDirectory();
                                path = Directory.GetParent(path).ToString();
                                path = Directory.GetParent(path).ToString();
                                path = path + @"\Images\" + str.Way;
                                SMS NEW = new SMS() { Date = str.Date, file = str.file, fileName = str.fileName, filetrue = str.filetrue, kLogin = str.kLogin, Login = str.Login, Message = str.Message, Way = path, NameGroup = str.NameGroup };
                                ChangeColorNickNameGetSms(NEW.kLogin);
                                ALLmessage.Add(NEW);
                            });
                            break;

                        case CommandToClient.MessageGroup:
                            var str1 = serializer.Deserialize(serverListener.GetStream()) as SMS;
                            Console.WriteLine("login:"+str1.Login+"klogin:"+str1.kLogin);
                            App.Current.Dispatcher.Invoke(() =>
                            {
                                
                                
                                ChangeColorNickNameGetSmsGroup(str1.NameGroup);
                                for(int i=0;i<1;i++)
                                {
                                    ALLmessage.Add(str1);
                                }
                                
                            });

                            
                            break;
                        case CommandToClient.UsersOnline:
                            var Users = serializer.Deserialize(serverListener.GetStream()) as List<LoginColor>;
                            App.Current.Dispatcher.Invoke(() =>
                            {
                                Data.Clear();
                                foreach (var t in Users)
                                {
                                    if (t.Login != MyLogin)
                                        Data.Add(t);
                                }
                            });
                            break;

                    }

            }
        }

    }

}




       

