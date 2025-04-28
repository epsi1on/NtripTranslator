using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace V1Translator
{
    //http and alike protocols (to support minor protocol violations)
    public class XttpRequest
    {
        public const string CrLf = "\r\n";

        public byte[] Data;
        public string Path;
        public string Method;
        public string ProtocolVer;

        public List<Tuple<string, string>> Headers;

        public static XttpRequest ReadXttpReq(Stream str)
        {
            var buf = new XttpRequest();

            var rdr = new StreamReader(str);

            var raw = rdr.ReadUntil(CrLf + CrLf);//read unltill two consecutive newlines


            var lines = raw.Split(CrLf);

            {
                var first = lines[0];

                var st = first.IndexOf(' ');
                var en = first.LastIndexOf(' ');

                buf.Method = first.Substring(0, st);
                buf.Path = first.Substring(st + 1, en - st - 1);
                buf.ProtocolVer = first.Substring(en + 1);
            }

            buf.Headers = new List<Tuple<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                var idx = line.IndexOf(':');

                var header = line.Substring(0, idx);
                var value = line.Substring(idx + 1);

                buf.Headers.Add(new Tuple<string, string>(header, value));
            }

            var cl = buf.Headers.FirstOrDefault(i => i.Item1 == "Content-Length");

            if (cl != null)
            {
                var lng = int.Parse(cl.Item2);
                var dt = ReadExactly(str, lng);

                buf.Data = dt;
            }

            return buf;
        }

        public static byte[] ReadExactly(System.IO.Stream stream, int count)
        {
            byte[] buffer = new byte[count];
            int offset = 0;

            while (offset < count)
            {
                int read = stream.Read(buffer, offset, count - offset);
                if (read == 0)
                    throw new System.IO.EndOfStreamException();
                offset += read;
            }

            System.Diagnostics.Debug.Assert(offset == count);
            return buffer;
        }
    }


}
