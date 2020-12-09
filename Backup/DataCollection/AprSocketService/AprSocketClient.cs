// Decompiled with JetBrains decompiler
// Type: DataCollection.AprSocketService.AprSocketClient
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using DataCollection.DataFileCache;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Utils;

namespace DataCollection.AprSocketService
{
  internal class AprSocketClient : IDisposable
  {
    private long position;
    private CollectionFile file;
    private static string hostName = "apr.c2dms.com";
    private static int hostPort = 8787;
    private TcpClient tcpClient;
    private NetworkStream stream;

    public AprSocketClient(CollectionFile file)
    {
      this.position = 0L;
      this.file = file;
    }

    public AprSocketClient UploadFile()
    {
      AprStatus aprStatus = AprStatus.INIT;
      try
      {
        aprStatus = AprStatus.UPLOAD;
        this.Connect().Upload().Dispose();
        aprStatus = AprStatus.CHECKSUM;
        this.Connect().Validate().Dispose();
        aprStatus = AprStatus.DONE;
        return this;
      }
      finally
      {
        switch (aprStatus)
        {
          case AprStatus.UPLOAD:
            if (!string.IsNullOrEmpty(this.file.SourceId))
            {
              this.file.MarkSuspend();
              break;
            }
            goto default;
          case AprStatus.DONE:
            this.file.MarkDone();
            break;
          default:
            this.file.MarkAbort();
            break;
        }
      }
    }

    private AprSocketClient Connect()
    {
      this.tcpClient = new TcpClient();
      IAsyncResult asyncResult = this.tcpClient.BeginConnect(AprSocketClient.hostName, AprSocketClient.hostPort, (AsyncCallback) null, (object) null);
      WaitHandle asyncWaitHandle = asyncResult.AsyncWaitHandle;
      try
      {
        if (!asyncResult.AsyncWaitHandle.WaitOne(60000, false))
        {
          this.tcpClient.Close();
          throw new CException(258L, "Connect APR server fails during 60 seconds");
        }
        this.tcpClient.EndConnect(asyncResult);
        this.stream = this.tcpClient.GetStream();
        return this;
      }
      finally
      {
        asyncWaitHandle.Close();
      }
    }

    private AprSocketClient Upload()
    {
      byte[] uploadRequest = this.GetUploadRequest();
      this.stream.Write(uploadRequest, 0, uploadRequest.Length);
      this.stream.Flush();
      byte[] numArray = new byte[100];
      this.stream.Read(numArray, 0, numArray.Length);
      this.ParseUploadResponse(numArray);
      using (FileStream fileStream = File.OpenRead(this.file.FilePath))
      {
        fileStream.Seek(this.position, SeekOrigin.Begin);
        int count1 = 256;
        byte[] buffer = new byte[count1];
        int count2;
        while ((count2 = fileStream.Read(buffer, 0, count1)) > 0)
        {
          this.stream.Write(buffer, 0, count2);
          this.stream.Flush();
        }
        if (fileStream.Length > 5242880L)
          Thread.Sleep(90000);
        else if (fileStream.Length > 1048576L)
          Thread.Sleep(45000);
        else
          Thread.Sleep(10000);
      }
      return this;
    }

    private byte[] GetUploadRequest() => Encoding.UTF8.GetBytes(string.Format("Type=1;Content-Length={0};filename={1};sourceid={2}\r\n", (object) new FileInfo(this.file.FilePath).Length, (object) this.file.FileName, (object) this.file.SourceId));

    private void ParseUploadResponse(byte[] uploadResponse)
    {
      string str = Encoding.UTF8.GetString(uploadResponse);
      string[] strArray = str.Split(';');
      this.file.SourceId = strArray.Length >= 2 ? strArray[0].Substring(strArray[0].IndexOf('=') + 1) : throw new CException(1616L, "Get unexpected upload response, response: " + str);
      this.position = long.Parse(strArray[1].Substring(strArray[0].IndexOf('=') + 1));
    }

    private AprSocketClient Validate()
    {
      byte[] checksumRequest = this.GetChecksumRequest();
      this.stream.Write(checksumRequest, 0, checksumRequest.Length);
      this.stream.Flush();
      byte[] numArray = new byte[100];
      this.stream.Read(numArray, 0, numArray.Length);
      this.ParseChecksumResponse(numArray);
      return this;
    }

    private byte[] GetChecksumRequest() => Encoding.UTF8.GetBytes(string.Format("Type=2;Content-Length={0};filename={1};sourceid={2};CRC-Checksun={3}\r\n", (object) new FileInfo(this.file.FilePath).Length, (object) this.file.FileName, (object) this.file.SourceId, (object) this.GetChecksumOf(this.file.FilePath)));

    private uint GetChecksumOf(string filePath)
    {
      using (FileStream fileStream = File.Open(filePath, FileMode.Open))
      {
        byte[] hash = new Crc32().ComputeHash((Stream) fileStream);
        Array.Reverse((Array) hash);
        return BitConverter.ToUInt32(hash, 0);
      }
    }

    private void ParseChecksumResponse(byte[] checksumResponse)
    {
      string str = Encoding.UTF8.GetString(checksumResponse);
      string[] strArray = str.Split(';');
      if (strArray.Length < 1)
        throw new CException(1616L, "Get unexpected checksum response, response: " + str);
      if (!strArray[0].Substring(strArray[0].IndexOf('=') + 1).Equals("yes"))
        throw new CException(1616L, "Get failed checksum response, response: " + str);
    }

    public void Dispose()
    {
      try
      {
        if (this.stream != null)
          this.stream.Close();
        if (this.tcpClient != null)
          this.tcpClient.Close();
      }
      catch
      {
      }
      this.stream = (NetworkStream) null;
      this.tcpClient = (TcpClient) null;
    }
  }
}
