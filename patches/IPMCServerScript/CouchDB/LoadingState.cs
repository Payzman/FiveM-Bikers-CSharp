using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.CouchDB
{
    class LoadingState : State
    {
        private bool temp = true;

        public LoadingState(Connection connection) : base(connection)
        {
        }

        public override void HandleResponse(dynamic response, string reason, dynamic param)
        {
            if(reason == Strings.get_single_player_doc)
            {
                connection.Players.AddPlayerDocument(response);
            }
            if(connection.Players.users.Count == connection.Players.total_rows)
            {
                connection.ChangeState(new IdleState(connection));
            }
        }

        public override void Request()
        {
            if (temp)
            {
                connection.Players.GetPlayerInfo();
                temp = false;
            }
        }
    }
}
