// Decompiled with JetBrains decompiler
// Type: Utils.RsaCrypt
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
  public static class RsaCrypt
  {
    private static int defaultKeySize = 2048;
    private static string defaultXml = "<RSAKeyValue><Modulus>ojc2m3OZnwADzrKsRMG/ljkTtDu7rdpU6jE5udK63dNeibdI6pvOxUvQzQ2TcS0LyYn+TUeHkruLwrestMB6dCJmwINAhBQqpsflBCapDthmdWM9XwY1iYCX4XfK+6SVCDnGSZ91dvimiho7R/lL0e/Kp1BfU0JIgVUAklcXo37hK1ANe5cFnLwPkMHo0tls9sYENztNuY6DJ5tZyQRl9FJgHgnoAciJzplIWN4CeZr1T1tB4PYesmilaOMF5zr69PWfLWlANwlKSMWPeEBpVR33tswJxDE+VFjIiAi0zNjEwi2RqY9PiFR0PDRZTO+JCnExIEqgwFuDkFTCsVNx4Q==</Modulus><Exponent>AQAB</Exponent><P>zAOYX9MgNLga2A8H5k3Wy47rGXXeaJqHbH+9AmP8XOexqCafseVWIEAEpZQdaMhSpAi89c4own4NCnjgz5Otx6Ev1PVasQgvXW22nCjRnzm8Z74GKlDLuTVw7TpWS2Mg6lqVJzm550SN2lvAf10Ozno0+zrsNKiYi3BpJjmKrdE=</P><Q>y4z+fjH5iSBxBdOcoPM8J+E41T/Hh9nuydP5kwR9+HeaNXKrCC8KbipKDgGX91Puj51O8RsSqwERpr+epoTD28cV/IO5iUJD8ACsJyDzo6MjFabFdu2RxSS1VZXbWD/R7wiOyRoVPru3B2v5x5+y/l7oPsVBJxIarOuXjcrmNxE=</Q><DP>odYoRbuhTLDO+p3R0mvk/E0/Sk8qQyhyTSt3sDHIu5pAX/djrycSDzs5dG/udHSUufMEkqkbxE1h4vDIxWGM9VN0Mib/7ndju2WQ+oeW4gxW3KTtFxxIv38ZOdaRJfRY5A8/SoKMal0DejhWl7ImULy40qKHRa6Ic/SUNPJohEE=</DP><DQ>Cn93EKMbL4tQyPAk/9gLnjLrb3Qeok8HFbmtAXwV0x64AVGsqHtkmlHsB9TlNYhKoXWHgL/YsqEXe/YeBJCMWWVnKOLSStX0Ewi12D7G0gWz5YX4YS3Xesdt4sAb0+1WsnFKi+ygc9/SjLtw4m7GGIBkkfgyaAVzAsATzOhN/0E=</DQ><InverseQ>omJAUY+A+2BXtrSw/6YzdLM2yOdNtaXcXAo27uoztaKFxY7Kg+EsPWW1DdBXr6CGWrOwP9GsAlfOOzI14lNFrpGUv3wAIdMLn0Akhgaw6BZVnnX7lQiGPkNgU/aN6ZBZ5Ub3tyjEsFWCH9ahO1mlpuZyLstH543kYfop8OP+47s=</InverseQ><D>fblhX3ZnOC6gxNECZ3/q55lxRh2Nxp8TdTeV0AodvtOV0BL4Nq1vwsaSHHtLLUqGejuzl127G+Sz28TT3HvZ7KzFCqwvkq62p/EB9Qepu9HJB25VIJMFZ379OEjKT+MthuSQZHtsZTsuiJbwH0Z+l0XMwYSvfS5AV8zz1ngd4B64r2yb9q/+sXXQ62vmNT+o7Mou9PI5CdZdpVUHRvN7CqWy/wPVqs0OsJqFVgTmYoewa3MPxDU0JdZJpj9kNBck/es7+Wp0XvuYsAIm0lesZ0G1OF0MpbyKbHY/4U6VBO4oUM579qQrDENVdWUvUGlCFNFJFeDZoBrhvrrvbNtiAQ==</D></RSAKeyValue>";
    private static string logEncryptPubKey = "<RSAKeyValue><Modulus>nqvqU31sL2Q+/PWHt1F4/KaQOIdzTDHK7zKNgUG0yG/16L9p1ta76KWC2PYLs6zUiPr08qu9ew8xXPgIEPuyloQzJToN8tPXw56UgrCNueVXYfxoW3cRzTy2BXq/sLhhCcyONfhGvmmCP8yWmM0orkXWHbZ1DVmxiThIikIDjHPpFAbhCPN9QEYDmqwL/RLYVLpNxNeHCetWdiPNBeVyPzot2FWmE9X8Mprd8WIiR48XBCe+Ma5xXY9x+ykmVpd02j6MysM/EIWOOWjmIyqU2RW+SoYaJpVVq1PdsWxeZxoyjwNYM6B/wjdByI/da1n3joK7F0J8h2u94dB6upRFDQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

    public static string EncryptString(string plaintext, int xmlKeySize, string xmlKeyString)
    {
      RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider(xmlKeySize);
      cryptoServiceProvider.FromXmlString(xmlKeyString);
      int num1 = xmlKeySize / 8;
      byte[] bytes = Encoding.Unicode.GetBytes(plaintext);
      int num2 = num1 - 42;
      int length = bytes.Length;
      int num3 = length / num2;
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index <= num3; ++index)
      {
        byte[] rgb = new byte[length - num2 * index > num2 ? num2 : length - num2 * index];
        Buffer.BlockCopy((Array) bytes, num2 * index, (Array) rgb, 0, rgb.Length);
        byte[] inArray = cryptoServiceProvider.Encrypt(rgb, true);
        stringBuilder.Append(Convert.ToBase64String(inArray));
      }
      return stringBuilder.ToString();
    }

    public static string DecryptString(string cipherText, int xmlKeySize, string xmlKeyString)
    {
      RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider(xmlKeySize);
      cryptoServiceProvider.FromXmlString(xmlKeyString);
      int length = xmlKeySize / 8 % 3 != 0 ? xmlKeySize / 8 / 3 * 4 + 4 : xmlKeySize / 8 / 3 * 4;
      int num = cipherText.Length / length;
      ArrayList arrayList = new ArrayList();
      for (int index = 0; index < num; ++index)
      {
        byte[] rgb = Convert.FromBase64String(cipherText.Substring(length * index, length));
        arrayList.AddRange((ICollection) cryptoServiceProvider.Decrypt(rgb, true));
      }
      return Encoding.Unicode.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);
    }

    public static string EncryptString(string plaintext) => RsaCrypt.EncryptString(plaintext, RsaCrypt.defaultKeySize, RsaCrypt.defaultXml);

    public static string DecryptString(string cipherText) => RsaCrypt.DecryptString(cipherText, RsaCrypt.defaultKeySize, RsaCrypt.defaultXml);

    public static string EncryptLog(string logtext) => "<Cipher>" + RsaCrypt.EncryptString(logtext, RsaCrypt.defaultKeySize, RsaCrypt.logEncryptPubKey) + "</Cipher>";
  }
}
