/*  Copyright (c) Joshua Stockin 2018
 *
 *  This file is part of Instant Gameworks.
 *
 *  Instant Gameworks is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  Instant Gameworks is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with Instant Gameworks.  If not, see <http://www.gnu.org/licenses/>.
 */


using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantGameworksZip
{

    // TODO:
    //
    // -Add methods to the ResourcePack struct for possible dynamic libraries. Stuff like .GetFile(string filename) to make it easier.
    //

    class ResourceManager
    {
        enum ResourceType
        {
            InstantGameworksObject = 0, //Optimized OBJ variant
            WaveAudio = 1, //Uncompressed + crisp
            FLIF = 2, //Free Lossless Image Format. really nicee
        }

        struct ResourcePack //Full file is saved as this. Contains pack metadata and the array of individual resources, of course.
        {
            private ResourcePackMetadata _metadata;
            private Resource[] _resourceData;

            public ResourcePackMetadata Metadata => _metadata;
            public Resource[] ResourceData => _resourceData;

            ResourcePack(ResourcePackMetadata newMetadata, Resource[] newResourceData)
            {
                _metadata = newMetadata;
                _resourceData = newResourceData;
            }
        }

        struct ResourcePackMetadata //Consists of the # of resources, total filesize, and the start position (in bytes) of each resource
        {
            private ushort _resourceCount;
            private uint _fileSize;
            private Dictionary<string, int> _fileIndex;

            public ushort ResourceCount => _resourceCount;
            public uint FileSize => _fileSize;
            public Dictionary<string, int> FileIndex => _fileIndex;
            ResourcePackMetadata(ushort resourceCount, uint fileSize, Dictionary<string, int> fileIndex)
            {
                _resourceCount = resourceCount;
                _fileSize = fileSize;
                _fileIndex = fileIndex;
            }
        }

        struct Resource //each individual resource. uses the enum defined earlier.
        {
            public ResourceType ResourceType { get; }
            public string ResourceName { get; }
            public byte[] ResourceData { get; }
            Resource(ResourceType type, string name, byte[] data)
            {
                ResourceType = type;
                ResourceName = name;
                ResourceData = data;
            }
        }

        public static void ImportFile(string filePath)
        {

        }
        public static void ExportFile(string outputPath, string[] resourceFiles)
        {
            ResourcePack outFile = new ResourcePack();

        }
    }
}
