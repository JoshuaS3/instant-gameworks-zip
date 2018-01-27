using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantGameworksZip
{
    class ResourceManager
    {
        //Data types
        //UInt16 - 16 bits - 2 bytes
        //UInt32 - 32 bits - 4 bytes

        struct ResourceFile
        {
            public static ResourceMetadata Metadata { get; }
            public static byte[] ResourceData { get; }

            ResourceFile()
            {

            }
        }
        

        struct ResourceMetadata
        {
            public static int FileSizeInBytes { get; set; } //int + ushort + uint + Dictionary

            public static ushort ResourceCount { get; set; }
            public static uint FileSize { get; set; }

            public static Dictionary<string, int> FileIndex { get; set; }
            
            public static int UpdateSizeInBytes()
            {
                FileSizeInBytes = 4 + 2 + 4 + System.Runtime.InteropServices.Marshal.SizeOf(FileIndex);
                return FileSizeInBytes;
            }
            public static void AddFile(string fileNameWithExtension, int locationInData, uint fileSize)
            {
                ResourceCount += 1;
                FileSize += fileSize;
                FileIndex.Add(fileNameWithExtension, locationInData);
            }
        }
    }
}
