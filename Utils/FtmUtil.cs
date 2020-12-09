// Decompiled with JetBrains decompiler
// Type: Utils.FtmUtil
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.IO.Ports;
using System.Threading;

namespace Utils
{
  internal class FtmUtil
  {
    private static int mBaudRate = 115200;
    private static Parity mParity = Parity.None;
    private static StopBits mStopBits = StopBits.One;

    private static void ParseFtmResponse(string oriResponse, ref FtmResponse ftmResponse)
    {
      CLogs.I("Parse FTM response...");
      string[] strArray1 = oriResponse.Replace("\n", "").Split('\r');
      if (strArray1 == null)
      {
        ftmResponse.apiStatus = "ERROR";
        ftmResponse.errMsg = "Parse FTM response fail!";
      }
      else
      {
        foreach (string str in strArray1)
        {
          if (str.Length != 0 && !(str == "\r"))
          {
            if (str.ToUpper().Contains("API STATUS"))
              ftmResponse.apiStatus = str.ToUpper().Replace("API STATUS=", "").Trim();
            else if (str.ToUpper().Contains("ERROR MESSAGE"))
              ftmResponse.errMsg = str.ToUpper().Replace("ERROR MESSAGE=", "").Trim();
            else if (str.Contains("="))
            {
              string[] strArray2 = str.Split('=');
              if (strArray2 != null && strArray2.Length == 1)
                ftmResponse.listKeyValueParis.Add(strArray2[0].Trim(), "");
              else
                ftmResponse.listKeyValueParis.Add(strArray2[0].Trim(), strArray2[1].Trim());
            }
          }
        }
      }
    }

    public static FtmResponse SendAndRecv(string portName, string ftmCmd) => FtmUtil.SendAndRecv(portName, FtmUtil.mBaudRate, FtmUtil.mParity, FtmUtil.mStopBits, ftmCmd, 1000);

    public static FtmResponse SendAndRecv(
      string portName,
      string ftmCmd,
      int delayBetweenSendAndRecv)
    {
      return FtmUtil.SendAndRecv(portName, FtmUtil.mBaudRate, FtmUtil.mParity, FtmUtil.mStopBits, ftmCmd, delayBetweenSendAndRecv);
    }

    public static FtmResponse SendAndRecv(
      string portName,
      int baudRate,
      Parity parity,
      StopBits stopBit,
      string ftmCmd,
      int delayBetweenSendAndRecv)
    {
      CLogs.I(string.Format("[FTM][PARAM] COM PORT: {0} | Baud Rate: {1} | Parity: {2} | StopBits: {3}", (object) portName, (object) baudRate.ToString(), (object) parity.ToString(), (object) stopBit.ToString()));
      SerialPort serialPort = (SerialPort) null;
      FtmResponse ftmResponse = new FtmResponse();
      try
      {
        serialPort = new SerialPort();
        serialPort.PortName = portName;
        serialPort.BaudRate = baudRate;
        serialPort.Parity = parity;
        serialPort.StopBits = stopBit;
        CLogs.I("[FTM] Open device...");
        serialPort.Open();
        CLogs.I(string.Format("[FTM][SEND] {0}", (object) ftmCmd));
        serialPort.WriteLine(ftmCmd);
        Thread.Sleep(delayBetweenSendAndRecv);
        int num = 1;
        string oriResponse;
        do
        {
          oriResponse = serialPort.ReadExisting();
          if (oriResponse.Length > 0)
            CLogs.I(string.Format("[FTM][RECV][{0}]\n{1}", (object) num.ToString(), (object) oriResponse));
          else
            CLogs.I(string.Format("[FTM][RECV]", (object) num.ToString()));
          if (oriResponse.Length <= 0)
            ++num;
          else
            break;
        }
        while (num <= 3);
        if (oriResponse.Length == 0)
        {
          ftmResponse.apiStatus = "ERROR";
          ftmResponse.errMsg += "Empty response!";
        }
        else
          FtmUtil.ParseFtmResponse(oriResponse, ref ftmResponse);
      }
      catch (Exception ex)
      {
        CLogs.E(string.Format("[FTM][ERROR] {0}", (object) ex.Message));
        ftmResponse.apiStatus = "EXCEPTION";
        ftmResponse.errMsg += ex.Message;
      }
      finally
      {
        if (serialPort != null)
        {
          CLogs.I("[FTM] Close device...");
          serialPort.DiscardInBuffer();
          serialPort.Close();
          serialPort.Dispose();
        }
      }
      return ftmResponse;
    }
  }
}
