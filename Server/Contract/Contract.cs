using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;



namespace Contract
{
    

    [Serializable]
    public class ClientInfo
    {
        public Guid id { get; set; }
		[NonSerialized]
		private TcpClient _tcpClient;

		public TcpClient tcpClient
		{
			get { return _tcpClient; }
			set { _tcpClient = value; }
		}

        public String Login { get; set; }
    }

    [Serializable]
    public class SMS
    {
        public string NameGroup { get; set; }
        public string Login { get; set; }
        public string kLogin { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public byte[] file { get; set; }
        public string fileName { get; set; }
        public bool filetrue { get; set; }
        public string Way {get;set;}
    }

    [Serializable]
    public class LoginColor
    {
        public string Login { get; set; }
        public string GetLoginColor { get; set; }

    }

    [Serializable]
    public class Group
    {
        public string NameGroup { get; set; }
        public string People { get; set; }
        
    }

    
}
