﻿using System;
using System.Linq;
using System.Net;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Tools;

namespace NORSU.EncodeMe.Network
{
    static class Server
    {
        private static bool _started;
        
        public static void Start()
        {
            if (_started) return;
            _started = true;
            
            var serializer = DPSManager.GetDataSerializer<ProtobufSerializer>();
            
            NetworkComms.DefaultSendReceiveOptions = new SendReceiveOptions(serializer,
                NetworkComms.DefaultSendReceiveOptions.DataProcessors, NetworkComms.DefaultSendReceiveOptions.Options);
            
            PeerDiscovery.EnableDiscoverable(PeerDiscovery.DiscoveryMethod.UDPBroadcast);
            
            
            NetworkComms.AppendGlobalIncomingPacketHandler<AndroidInfo>(AndroidInfo.GetHeader(), AndroidHandler.HandShakeHandler);
            NetworkComms.AppendGlobalIncomingPacketHandler<StudentInfoRequest>(StudentInfoRequest.GetHeader(), AndroidHandler.StudentInfoRequested);
            NetworkComms.AppendGlobalIncomingPacketHandler<EndPointInfo>(EndPointInfo.GetHeader(), EncoderHandler.HandShakeHandler);
            NetworkComms.AppendGlobalIncomingPacketHandler<Login>(Login.GetHeader(), EncoderHandler.LoginHandler);
            
            Connection.StartListening(ConnectionType.UDP, new IPEndPoint(IPAddress.Any, 0), true);
            
        }
        
        public static void Stop()
        {
            Connection.StopListening();
            NetworkComms.Shutdown();
        }

      


    }
}
