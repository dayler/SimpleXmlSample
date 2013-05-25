using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XMLNativeSerializerSample.util.File
{
    public class FileUtils
    {
        public static void WriteToFile(String outputFileName, Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream cannot be null.");
            }

            FileStream fileStream = null;

            try
            {
                stream.Seek(0, SeekOrigin.Begin);
                int streamLengt = Convert.ToInt32(stream.Length);
                byte[] memoryBytes = new byte[streamLengt];
                stream.Read(memoryBytes, 0, streamLengt);
                fileStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write);
                fileStream.Write(memoryBytes, 0, streamLengt);
            }
            finally 
            {
                stream.Close();

                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }
    }
}
