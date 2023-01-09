using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AwsLocalSettings
{

    /// <summary>
    /// Тип подключения рабочего места
    /// </summary>
	public enum ConnectionType
	{
		SERIAL,
		TCP,
	}

    /// <summary>
    /// Данные для TCP подключения
    /// </summary>
    public class ConnectionInfoCOM
    {
        public string Name;
        public string DeviceId;
    }

    /// <summary>
    /// Данные для TCP подключения
    /// </summary>
    public class ConnectionInfoTCP 
    {
        public string EndPoint;
    }

    /// <summary>
    /// Данные по подключению
    /// </summary>
    public class ConnectionInfo
    {
        public ConnectionType Type { get; set; }
        public ConnectionInfoCOM ComInfo { get; set; }
        public ConnectionInfoTCP TcpInfo { get; set; }

        public ConnectionInfo()
        {
            ComInfo = new ConnectionInfoCOM();
            TcpInfo = new ConnectionInfoTCP();
        }
    }

    /// <summary>
    /// Тип операции в СУВИ (вафельница, монтаж, сборка)
    /// </summary>
	public static class OperationType
	{
		public class Info : INotifyPropertyChanged
		{
			private string name;
			public string Name 
			{
				get { return name; }
				set
				{
					name = value;
					OnPropertyChanged("Name");
				}
			}

			private int code;
			public int Code
			{
				get { return code; }
				set
				{
					code = value;
					OnPropertyChanged("Code");
				}
			}

			public event PropertyChangedEventHandler PropertyChanged;
			public void OnPropertyChanged([CallerMemberName] string prop = "")
			{
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs(prop));
			}
		}

		private static List<Info> data = new List<Info>
		{
			new Info() { Name = "Вафельница", Code = 111 },
			new Info() { Name = "Сборка", Code = 222 },
		};

		public static List<Info> GetData()
		{
			return data;
		}
	}
}