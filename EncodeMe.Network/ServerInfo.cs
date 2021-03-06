﻿using ProtoBuf;

namespace NORSU.EncodeMe.Network
{
    [ProtoContract]
    class ServerInfo : Message<ServerInfo>
    {
        private ServerInfo()
        {
        }

        public ServerInfo(string host):this()
        {
            Hostname = host;
        }
        
        [ProtoMember(1)]
        public string IP { get; set; }
        
        [ProtoMember(2)]
        public string Hostname { get; set; }
        
        [ProtoMember(3)]
        public string MAC { get; set; }
        
        [ProtoMember(4)]
        public int Port { get; set; }

        [ProtoMember(5)]
        public bool TakePicture { get; set; }
        
    }
}
