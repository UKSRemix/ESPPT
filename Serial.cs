using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ESPPT
{
    public delegate void SerialMessage(string Message);

    class Serial
    {
        public event SerialMessage eventSerialMessage;
        public static System.IO.Ports.SerialPort _serialPort;
        public static bool _continue;
        public static Thread readThread;

        public string PortName
        {
            get { return _serialPort.PortName; }
            set { _serialPort.PortName = value; }
        }
        public int BaudRate
        {
            get { return _serialPort.BaudRate; }
            set { _serialPort.BaudRate = value; }
        }
        public string Parity
        {
            get { return _serialPort.Parity.ToString(); }
            set { _serialPort.Parity = (System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity), value, true); }
        }
        public int DataBits
        {
            get { return _serialPort.DataBits; }
            set { _serialPort.DataBits = value; }
        }
        public string StopBits
        {
            get { return _serialPort.StopBits.ToString(); }
            set { _serialPort.StopBits = (System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), value, true); } 
        }
        public string Handshake
        {
            get { return _serialPort.Handshake.ToString(); }
            set { _serialPort.Handshake = (System.IO.Ports.Handshake)Enum.Parse(typeof(System.IO.Ports.Handshake), value, true); } 
        }
        public bool Open()
        {
            try
            {
                _serialPort.Open();
                _continue = true;
                readThread = new Thread(Read);
                readThread.Start();
                return true;
            }
            catch(Exception e)
            {
                if (this.eventSerialMessage != null) this.eventSerialMessage(e.Message);
                return false;
            }
        }
        public void Close()
        {        
            _continue = false;
            Thread.Sleep(500);
            if(_serialPort.IsOpen)
                _serialPort.Close();
            if (readThread != null)
                readThread.Abort();
            
        }
        public void Send(string message)
        {
            _serialPort.WriteLine(message + "\r");
        }
        public string[] GetPorts()
        {
            return System.IO.Ports.SerialPort.GetPortNames();
        }
        public Serial()
        {
            _serialPort = new System.IO.Ports.SerialPort();
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;
        }

        public System.IO.Ports.Parity SetPortParity(System.IO.Ports.Parity defaultPortParity)
        {
            string parity;

            Console.WriteLine("Available Parity options:");
            foreach (string s in Enum.GetNames(typeof(System.IO.Ports.Parity)))
            {
                Console.WriteLine("   {0}", s);
            }

            Console.Write("Enter Parity value (Default: {0}):", defaultPortParity.ToString(), true);
            parity = Console.ReadLine();

            if (parity == "")
            {
                parity = defaultPortParity.ToString();
            }

            return (System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity), parity, true);
        }

        public virtual void Read()
        {
            while (_continue)
            {
                try
                {
                    if (!_serialPort.IsOpen) return;
                    string message = _serialPort.ReadLine();
                    if (this.eventSerialMessage != null) this.eventSerialMessage(message);
                }
                catch (TimeoutException) { }
            }
        }
    }
}
