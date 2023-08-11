using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Oxide.Core.Libraries.Covalence;

namespace Oxide.Plugins
{
    [Info("Whitelister", "iLakSkiL", "1.1.0")]
    [Description("Restricts server access to whitelisted players only")]

    class Whitelister : RustPlugin
    {
        private void Init()
        {
            permission.RegisterPermission("whitelister.whitelist", this);
        }

        void OnPlayerConnected(BasePlayer player)
        {
            Puts($"{player.displayName} has connected");
            if (player.IsAdmin)
            {
                Puts($"{player.displayName} is an admin.");
                return;
            }
            if (!permission.UserHasPermission(player.UserIDString, "whitelister.whitelist"))
            {
                Puts($"Kicking {player.displayName} from server");
                player.Kick("You are not Whitelisted for this server. Contact an Admin if you believe this is an error.");
                return;
            }
            Puts($"{player.displayName} is allowed");
            return;
        }

    }
}