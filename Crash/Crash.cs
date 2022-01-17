using AdvancedBot.client;
using AdvancedBot.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crash
{
    public class Crash : IPlugin
    {

        RipCommand cmdRIP;

        public void onClientConnect(MinecraftClient client)
        {
            if (client.CmdManager.GetCommand("rip") == null)
            {
                cmdRIP = new RipCommand(client);
                client.CmdManager.Commands.Add(cmdRIP);
            }

        }

        public void onReceiveChat(string chat, byte pos, MinecraftClient client)
        { }

        public void OnReceivePacket(ReadBuffer pkt, MinecraftClient client)
        {}

        public void onSendChat(string chat, MinecraftClient client)
        { }

        public void OnSendPacket(IPacket packet, MinecraftClient client)
        { }

        public void Tick()
        { }

        public void Unload()
        { }
    }
}
