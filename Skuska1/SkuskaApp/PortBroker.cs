using System;
using System.IO.Ports;
using SkuskaApp.DTOs;

namespace SkuskaApp;

public static class PortBroker
{
    private static SerialPort  port = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
    private static String humData;
    private static String temptData;
    public static float multiplier = 1;

    static PortBroker()
    {
        
        Console.WriteLine("Start");
        port.Open();
        humData = port.ReadTo("\n");
        temptData = port.ReadTo("\n");
        port.DataReceived += port_DataReceived;
    }
    static public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        //Console.WriteLine();
        humData = port.ReadTo("\n");
        temptData = port.ReadTo("\n");
    }

    static public void printValue()
    {
        
    }

    static public DataDTO getData(float multiplier)
    {
        Console.WriteLine("multiplier " + multiplier);
        DataDTO dataDto = new DataDTO( float.Parse(temptData) * multiplier, float.Parse(humData) * multiplier);
        //dataDto.print();
        return dataDto;
    }
}