using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace AwsLocalSettings
{
	public class LocalSettingData
	{
		public class Employee 
		{
			// TODO: это внешний класс
		}

		public class WorkstationInfo : INotifyPropertyChanged
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

			private OperationType.Info operationType;
			public OperationType.Info OperationType
			{
				get { return operationType; }
				set
				{
					operationType = value;
					OnPropertyChanged("OperationType");
				}
			}


            private ConnectionInfo connectionInfo;
            public ConnectionInfo ConnectionInfo
            {
                get { return connectionInfo; }
                set
                {
                    connectionInfo = value;
					OnPropertyChanged("ConnectionInfo");
                }
            }


            // TODO: это свойство необходимо после убрать - вместо него ConnectionInfo
			private ConnectionType connectionType;
			public ConnectionType ConnectionType
			{
				get { return connectionType; }
				set
				{
					connectionType = value;
					OnPropertyChanged("ConnectionType");
				}
			}

			private bool enabled;
			public bool Enabled 
			{
				get { return enabled; }
				set
				{
					enabled = value;
					OnPropertyChanged("Enabled");
				}
			}

            // TODO:
			public List<Employee> Emple;

			public WorkstationInfo()
			{
				Emple = new List<Employee>();
                connectionInfo = new ConnectionInfo();
			}

			public event PropertyChangedEventHandler PropertyChanged;
			public void OnPropertyChanged([CallerMemberName] string prop = "")
			{
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs(prop));
			}
		}

		public List<WorkstationInfo> Workstation { get; set; }

		public void ShowSettingPanel()
		{
			var form = new LocalSettingWindow();
			
			form.BtnApply.Click += (s, e) =>
			{
				form.Close();
			};

			form.BtnCancel.Click += (s, e) => form.Close();

			form.BtnAddWorkstation.Click += (s, e) =>
			{
				Workstation.Add(new WorkstationInfo()
				{
					Name = string.Format("Рабочее место №{0:D}", Workstation.Count + 1),
					OperationType = OperationType.GetData()[0],
					ConnectionType = ConnectionType.SERIAL,
					Enabled = false,
				});

				form.DgWorkstation.ItemsSource = null;
				form.DgWorkstation.ItemsSource = Workstation;
			};

			form.BtnDelWorkstation.Click += (s, e) =>
			{
			};

			form.DgWorkstation.ItemsSource = Workstation;
			form.ShowDialog();
		}

		public LocalSettingData(string store_path)
		{
			Workstation = new List<WorkstationInfo>();
		}
	}
}