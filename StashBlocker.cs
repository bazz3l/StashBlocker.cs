using UnityEngine;

namespace Oxide.Plugins
{
    [Info("Stash Blocker", "Bazz3l", "1.0.0")]
    [Description("Block stashes from being placed.")]
    class StashBlocker : RustPlugin
    {
        #region Oxide
        void OnEntityBuilt(Planner planner, GameObject go)
        {
            BasePlayer player = planner.GetOwnerPlayer();
            BaseEntity entity = go.ToBaseEntity();

            if (player == null || entity == null || !entity.PrefabName.Contains("stash"))
            {
                return;
            }

            NextFrame(() => {
                player.GiveItem(ItemManager.CreateByName("stash.small", 1));

                player.ChatMessage("You can't place stashes.");

                entity.Kill();
            });
        }
        #endregion
    }
}