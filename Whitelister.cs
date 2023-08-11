using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Oxide.Core.Libraries.Covalence;

namespace Oxide.Plugins
{
    [Info("Whitelister", "iLakSkiL", "1.0.0")]
    [Description("Restricts server access to whitelisted players only")]

    class Whitelister : RustPlugin
    {
        void OnPlayerConnected(BasePlayer player)
        {
            Puts($"{player.displayName} has connected");
            if (player.IsAdmin)
            {
                Puts($"{player.displayName} is an admin.");
                return;
            }
            if (!permission.UserHasGroup(player.UserIDString, "reserved"))
            {
                Puts($"Kicking {player.displayName} from server");
                player.Kick("Only BCR Reserved Members are allowed on this server.");
                return;
            }
            Puts($"{player.displayName} is allowed");
            return;
        }

    }
}