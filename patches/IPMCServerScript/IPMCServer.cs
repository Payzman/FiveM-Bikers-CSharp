﻿using System;
using System.Threading.Tasks;
// Watch out because there is a CitizenFX Server and CitizenFX Client version!!
using CitizenFX.Core;
using System.Net;
using System.IO;

namespace IPMCServerScript
{
    public class IPMCServer : BaseScript
    {
        IPMCDatabase database;

        public IPMCServer()
        {
            EventHandlers["test"] += new Action<dynamic>(doSomething);
            EventHandlers["IPMC:InitPlayer"] += new Action(initPlayer);
            EventHandlers["IPMC:HttpResponse"] += new Action<IPMCCouchDbRoot>(IPMCDatabase.HandleResponse);
        }
        
        void doSomething(dynamic p)
        {
            PlayerList list = new PlayerList();
            foreach (Player player in list)
            {
                player.TriggerEvent("testClient");
            }
        }

        void initPlayer()
        {
            if(database == null)
            {
                database = new IPMCDatabase();
            }
        }
    }
}
