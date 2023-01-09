using System;

namespace SerialPortsRegInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var pInfo = new SerialPortsRegInfo();
            foreach (var p in pInfo.Items)
            {
                Console.WriteLine("");
                Console.WriteLine("Caption=" + "\"" + p.Caption + "\"");
                Console.WriteLine("Name=" + "\"" + p.Name + "\"");
                Console.WriteLine("DeviceID=" + "\"" + p.DeviceID + "\"");
            }

            Console.ReadKey();
        }
    }
}
