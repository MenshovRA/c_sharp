using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;

namespace SerialPortsRegInfo
{
	public class SerialPortsRegInfo
	{
		public struct PortInfo
		{
			public string Name;
			public string DeviceID;
			public string Caption;
		}

		public List<PortInfo> Items;

		public void RefreshInfo()
		{

			var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_SerialPort");
			var ports = searcher.Get().Cast<ManagementBaseObject>().ToList();

			Items.Clear();
			foreach (var p in ports)
			{
				var info = new PortInfo();
				info.Caption = p.GetPropertyValue("Caption").ToString();
				info.Name = p.GetPropertyValue("DeviceID").ToString();
				info.DeviceID = p.GetPropertyValue("PNPDeviceID").ToString();

				Items.Add(info);
			}
		}

		public SerialPortsRegInfo()
		{
			Items = new List<PortInfo>();
			RefreshInfo();
		}
	}
}