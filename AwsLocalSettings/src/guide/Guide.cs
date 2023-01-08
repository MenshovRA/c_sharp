using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AwsLocalSettings
{
	public enum ConnectionType
	{
		SERIAL,
		TCP,
	}

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