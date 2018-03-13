using Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Server
{

    class NetServer
    {
        public void StartServer()
        {
            new Thread(() =>
            {
                TcpListener serv = new TcpListener(new IPEndPoint(IPAddress.Any, 12345));
                serv.Start();
                while (true)
                {
                    TcpClient client = serv.AcceptTcpClient();
                    new Thread(new NetServer().ListenerClient) { IsBackground = true }.Start(client);
                }
            })
            { IsBackground = true }.Start();
        }

        public void ListenerClient(Object ob)
        {
            TcpClient tcp = ob as TcpClient;

            BinaryFormatter bf = new BinaryFormatter();
            String userLogin = bf.Deserialize(tcp.GetStream()) as String;

            bool result = Logic.CanConnect(new ClientInfo
            {
                id = Guid.NewGuid(),
                Login = userLogin,
                tcpClient = tcp
            });

            BinaryWriter bw = new BinaryWriter(tcp.GetStream());
            bw.Write(result);
            BinaryReader br = new BinaryReader(tcp.GetStream());

            if (result == false)
            {
                tcp.Close();
                return;
            }

            bool bye_bye = true;


            while (bye_bye)
            {
                var comand = (CommandToServer)br.ReadByte();
                switch (comand)
                {
                    case CommandToServer.DeleteGroup:
                        var datatmp = bf.Deserialize(tcp.GetStream()) as Group;

                        
                        Logic.RemoveGroup(datatmp.NameGroup ,datatmp.People);


                        var data7 = new List<LoginColor>();
                        var clients7 = Logic.GetAllCLients();
                        var group7 = Logic.GetAllGroup();
                        foreach (var i in Logic.GetAllCLients())
                        {
                            data7.Add(new LoginColor() { Login = i.Login, GetLoginColor = "LightCyan" });
                        }
                        int tmp7 = 0;
                        int count7 = data7.Count;
                        for (int i = 0; i < clients7.Count; i++)
                        {

                            for (int j = 0; j < group7.Count; j++)
                            {
                                if (clients7[i].Login == group7[j].People)
                                {
                                    tmp7++;
                                    data7.Add(new LoginColor() { Login = group7[j].NameGroup, GetLoginColor = "LightCyan" });

                                }
                            }
                            clients7[i].tcpClient.GetStream().WriteByte((byte)CommandToClient.UsersOnline);
                            bf.Serialize(clients7[i].tcpClient.GetStream(), data7);
                            if (count7 != 0)
                            {
                                data7.RemoveRange(count7, tmp7);

                            }
                            tmp7 = 0;
                        }

                        break;
                    case CommandToServer.CreateGroup:
                        var dataGroup = bf.Deserialize(tcp.GetStream()) as Group;
                        Logic.AddGroup(dataGroup);
                        var data4 = new List<LoginColor>();
                        var clients2 = Logic.GetAllCLients();
                        var group = Logic.GetAllGroup();
                        foreach (var i in Logic.GetAllCLients())
                        {
                            data4.Add(new LoginColor() { Login = i.Login, GetLoginColor = "LightCyan" });
                        }
                        int tmp = 0;
                        int count = data4.Count;
                        for (int i = 0; i < clients2.Count; i++)
                        {

                            for (int j = 0; j < group.Count; j++)
                            {
                                if (clients2[i].Login == group[j].People)
                                {
                                    tmp++;
                                    data4.Add(new LoginColor() { Login = group[j].NameGroup, GetLoginColor = "LightCyan" });

                                }
                            }
                            clients2[i].tcpClient.GetStream().WriteByte((byte)CommandToClient.UsersOnline);
                            bf.Serialize(clients2[i].tcpClient.GetStream(), data4);
                            if (count != 0)
                            {
                                data4.RemoveRange(count, tmp);

                            }
                            tmp = 0;
                        }
                        break;
                    case CommandToServer.Exit:
                        Logic.RemoveClient(tcp);
                        bye_bye = false;
                        break;
                    case CommandToServer.SendMessage:
                        var data = bf.Deserialize(tcp.GetStream()) as SMS;
                        var clients = Logic.GetCLientsWithOut(data.Login);
                        clients[0].tcpClient.GetStream().WriteByte((byte)CommandToClient.Message);
                        bf.Serialize(clients[0].tcpClient.GetStream(), data);
                        break;
                    case CommandToServer.SendMessageGroup:
                        var data2 = bf.Deserialize(tcp.GetStream()) as SMS;
                        string tmp5 = data2.kLogin;
                        

                        var clients3 = Logic.GetAllCLients();
                        var group3 = Logic.GetAllGroup();

                        for (int i = 0; i < clients3.Count; i++)
                        {
                            for (int j = 0; j < group3.Count; j++)
                            {

                                if (clients3[i].Login == group3[j].People && data2.NameGroup == group3[j].NameGroup)
                                {
                                    Console.WriteLine("->"+clients3[i].Login+"->"+ group3[j].People+"->"+data2.kLogin+"->"+ group3[j].NameGroup);
                                    clients3[i].tcpClient.GetStream().WriteByte((byte)CommandToClient.MessageGroup);
                                    bf.Serialize(clients3[i].tcpClient.GetStream(), data2);
                                }

                            }
                        }

                        break;
                    case CommandToServer.AllUsers:
                        var data3 = bf.Deserialize(tcp.GetStream()) as List<LoginColor>;
                        var clients1 = Logic.GetAllCLients();
                        var group2 = Logic.GetAllGroup();
                        foreach (var i in Logic.GetAllCLients())
                        {
                            data3.Add(new LoginColor() { Login = i.Login, GetLoginColor = "LightCyan" });
                        }
                        int tmp2 = 0;
                        int count2 = data3.Count;
                        for (int i = 0; i < clients1.Count; i++)
                        {

                            for (int j = 0; j < group2.Count; j++)
                            {
                                if (clients1[i].Login == group2[j].People)
                                {
                                    tmp2++;
                                    data3.Add(new LoginColor() { Login = group2[j].NameGroup, GetLoginColor = "LightCyan" });

                                }
                            }
                            clients1[i].tcpClient.GetStream().WriteByte((byte)CommandToClient.UsersOnline);
                            bf.Serialize(clients1[i].tcpClient.GetStream(), data3);
                            if (count2 != 0)
                            {
                                data3.RemoveRange(count2, tmp2);

                            }
                            tmp2 = 0;
                        }



                        //var data3 = bf.Deserialize(tcp.GetStream())as List<LoginColor>;
                        //var clients1 = Logic.GetAllCLients();



                        //foreach (var i in Logic.GetAllCLients())
                        //{                
                        //    data3.Add(new LoginColor() { Login =i.Login, GetLoginColor = "LightCyan" });
                        //}
                        //for (int i = 0; i < clients1.Count; i++)
                        //{                       
                        //    clients1[i].tcpClient.GetStream().WriteByte((byte)CommandToClient.UsersOnline);
                        //    bf.Serialize(clients1[i].tcpClient.GetStream(), data3) ;
                        //}
                        break;
                }
            }
            tcp.Close();
        }


    }
}

