using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;
using Vintagestory.API.Util;
using Vintagestory.GameContent;

namespace ReinforcementPrivacy;

public class ReinforcementPrivacyModSystem : ModSystem
{
    private Harmony? harmony;

    private static class SaveReinforcementsPatch
    {
        private static readonly FieldInfo ApiField = AccessTools.Field(typeof(ModSystemBlockReinforcement), "api");
        private static readonly FieldInfo ServerChannelField = AccessTools.Field(typeof(ModSystemBlockReinforcement), "serverChannel");

        public static bool Prefix(ModSystemBlockReinforcement __instance, Dictionary<int, BlockReinforcement> reif, BlockPos pos)
        {
            ICoreAPI api = (ICoreAPI)ApiField.GetValue(__instance)!;
            Dictionary<int, BlockReinforcement> sanitized = Sanitize(reif);

            int chunkX = pos.X / 32;
            int chunkY = pos.Y / 32;
            int chunkZ = pos.Z / 32;
            byte[] data = SerializerUtil.Serialize(sanitized);

            api.World.BlockAccessor.GetChunk(chunkX, chunkY, chunkZ)?.SetModdata("reinforcements", data);

            IServerNetworkChannel? serverChannel = (IServerNetworkChannel?)ServerChannelField.GetValue(__instance);
            serverChannel?.BroadcastPacket(new ChunkReinforcementData
            {
                chunkX = chunkX,
                chunkY = chunkY,
                chunkZ = chunkZ,
                Data = data
            }, System.Array.Empty<IServerPlayer>());

            return false;
        }

        private static Dictionary<int, BlockReinforcement> Sanitize(Dictionary<int, BlockReinforcement> reif)
        {
            Dictionary<int, BlockReinforcement> sanitized = new Dictionary<int, BlockReinforcement>(reif.Count);

            foreach (KeyValuePair<int, BlockReinforcement> entry in reif)
            {
                BlockReinforcement source = entry.Value;
                sanitized[entry.Key] = new BlockReinforcement
                {
                    Strength = source.Strength,
                    PlayerUID = source.PlayerUID,
                    LastPlayername = "Unknown",
                    Locked = source.Locked,
                    LockedByItemCode = source.LockedByItemCode,
                    GroupUid = source.GroupUid,
                    LastGroupname = "Unknown group"
                };
            }

            return sanitized;
        }
    }

    public override void Start(ICoreAPI api)
    {
        harmony = new Harmony(Mod.Info.ModID);
        MethodInfo original = AccessTools.Method(typeof(ModSystemBlockReinforcement), "SaveReinforcments");
        MethodInfo prefix = AccessTools.Method(typeof(SaveReinforcementsPatch), nameof(SaveReinforcementsPatch.Prefix));

        harmony.Patch(original, prefix: new HarmonyMethod(prefix));
    }

    public override void Dispose()
    {
        harmony?.UnpatchAll(Mod.Info.ModID);
        harmony = null;
    }
}
