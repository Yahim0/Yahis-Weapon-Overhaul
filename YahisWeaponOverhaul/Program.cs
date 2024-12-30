using System.Collections.Generic;
using Mutagen.Bethesda;
using Mutagen.Bethesda.FormKeys.SkyrimSE;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using functions;

namespace YahisWeaponOverhaul
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetTypicalOpen(GameRelease.SkyrimSE, "YahisWeaponOverhaul.esp")
                .Run(args);
        }
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            state.PatchMod.Weapons.Set(state.LoadOrder.PriorityOrder.Weapon().WinningOverrides()
                    .Where(w => w.HasKeyword(Skyrim.Keyword.WeapTypeGreatsword) && w.Data != null && (w.Data.Speed == 0.75f || w.Data.Speed == 0.7f))
                    .Select(w => w.DeepCopy())
                    .Do(w =>
                    {
                        w.Data.Speed = 0.8f;
                    }));
            state.PatchMod.Weapons.Set(state.LoadOrder.PriorityOrder.Weapon().WinningOverrides()
                    .Where(w => w.HasKeyword(Skyrim.Keyword.WeapTypeBattleaxe) && w.BasicStats != null)
                    .Select(w => w.DeepCopy())
                    .Do(w =>
                    {
                        w.BasicStats.Damage = (ushort)Math.Round((w.BasicStats.Damage - 1) * 9f / 7f);
                    }));
            state.PatchMod.Weapons.Set(state.LoadOrder.PriorityOrder.Weapon().WinningOverrides()
                    .Where(w => w.HasKeyword(Skyrim.Keyword.WeapTypeWarhammer) && w.BasicStats != null)
                    .Select(w => w.DeepCopy())
                    .Do(w =>
                    {
                        w.BasicStats.Damage = (ushort)Math.Round((w.BasicStats.Damage - 3) * 5f / 3f);
                    }));

            state.PatchMod.Weapons.Set(state.LoadOrder.PriorityOrder.Weapon().WinningOverrides()
                    .Where(w => w.HasKeyword(Skyrim.Keyword.WeapTypeWarAxe) && w.BasicStats != null)
                    .Select(w => w.DeepCopy())
                    .Do(w =>
                    {
                        w.BasicStats.Damage = (ushort)Math.Round((w.BasicStats.Damage - 1) * 11f / 9f);
                    }));
            state.PatchMod.Weapons.Set(state.LoadOrder.PriorityOrder.Weapon().WinningOverrides()
                    .Where(w => w.HasKeyword(Skyrim.Keyword.WeapTypeMace) && w.BasicStats != null)
                    .Select(w => w.DeepCopy())
                    .Do(w =>
                    {
                        w.BasicStats.Damage = (ushort)Math.Round((w.BasicStats.Damage - 2) * 6f / 4f);
                    }));
            state.PatchMod.Weapons.Set(state.LoadOrder.PriorityOrder.Weapon().WinningOverrides()
                    .Where(w => w.HasKeyword(Skyrim.Keyword.WeapTypeBow) && w.BasicStats != null)
                    .Select(w => w.DeepCopy())
                    .Do(w =>
                    {
                        w.BasicStats.Damage = (ushort)(w.BasicStats.Damage + 5);
                    }));
            state.PatchMod.Weapons.Set(state.LoadOrder.PriorityOrder.Weapon().WinningOverrides()
                    .Where(w => w.HasKeyword(Skyrim.Keyword.WeapTypeDagger) && w.BasicStats != null)
                    .Select(w => w.DeepCopy())
                    .Do(w =>
                    {
                        w.BasicStats.Damage = (ushort)Math.Round((w.BasicStats.Damage + 3) * 7f / 13f);
                    }));
        }
    }

#pragma warning restore CS8602 // Dereference of a possibly null reference.
}
