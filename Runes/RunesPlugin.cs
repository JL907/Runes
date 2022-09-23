using BepInEx;
using R2API;
using R2API.ScriptableObjects;
using R2API.Utils;
using RoR2;
using RoR2.Skills;
using RunesPlugin.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace RunesPlugin
{
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    [BepInPlugin(MODUID, MODNAME, MODVERSION)]
    [R2APISubmoduleDependency(new string[]
    {
        "PrefabAPI",
        "LanguageAPI",
        "SoundAPI",
        "NetworkingAPi",
        "SkinAPI",
        "LoadoutAPI",
        "DamageAPI"
    })]
    public class RunesPlugin : BaseUnityPlugin
    {
        public const string MODNAME = "RunesPlugin";
        public const string MODUID = "com.Lemonlust.Runes";
        public const string MODVERSION = "0.0.1";

        public static RunesPlugin instance;
        public static DamageAPI.ModdedDamageType runeDamage;

        public void Awake()
        {
            instance = this;
            Modules.Assets.Initialize();
            Modules.Tokens.AddTokens();

            new Modules.ContentPacks().Initialize();

            Hook();
        }

        private void Hook()
        {
            On.RoR2.SurvivorCatalog.Init += SurvivorCatalog_Init;
            On.RoR2.HealthComponent.TakeDamage += HealthComponent_TakeDamage;
        }

        private void SurvivorCatalog_Init(On.RoR2.SurvivorCatalog.orig_Init orig)
        {
            orig();
            SkillDef conquerorSkillDef = Modules.Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "CONQUEROR_NAME",
                skillNameToken = "CONQUEROR_NAME",
                skillDescriptionToken = "CONQUEROR_DESC",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Conqueror_rune"),
            });

            SkillDef lethalSkillDef = Modules.Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "LETHAL_NAME",
                skillNameToken = "LETHAL_NAME",
                skillDescriptionToken = "LETHAL_DESC",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Lethal_Tempo_rune"),
            });

            SkillDef phaseSkillDef = Modules.Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "PHASE_RUSH_NAME",
                skillNameToken = "PHASE_RUSH_NAME",
                skillDescriptionToken = "PHASE_RUSH_DESC",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Phase_Rush_rune"),
            });

            SkillDef electrocuteSkillDef = Modules.Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "ELECTROCUTE_NAME",
                skillNameToken = "ELECTROCUTE_NAME",
                skillDescriptionToken = "ELECTROCUTE_DESC",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Electrocute_rune"),
            });
            foreach (var item in SurvivorCatalog.allSurvivorDefs)
            {
                if (item.bodyPrefab.GetComponent<RuneHandler>()) return;
                RuneHandler runeHandler = item.bodyPrefab.AddComponent<RuneHandler>();
                runeHandler.keyStone = Skills.CreateGenericSkillWithSkillFamily(item.bodyPrefab, "KeyStone");
                Modules.Skills.AddKeyStone(item.bodyPrefab, electrocuteSkillDef);
                Modules.Skills.AddKeyStone(item.bodyPrefab, phaseSkillDef);
                Modules.Skills.AddKeyStone(item.bodyPrefab, lethalSkillDef);
                Modules.Skills.AddKeyStone(item.bodyPrefab, conquerorSkillDef);
                Debug.LogWarning("Added RuneHandler to " + item.bodyPrefab.name.ToString());
            }
        }

        private void HealthComponent_TakeDamage(On.RoR2.HealthComponent.orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
        {
            CharacterBody attackerBody = damageInfo.attacker.GetComponent<CharacterBody>();
            if (damageInfo is null) return;
            if (attackerBody is null) return;
            if (self is null) return;
            if (attackerBody.GetComponent<RuneHandler>())
            {
                DamageAPI.AddModdedDamageType(damageInfo, RunesPlugin.runeDamage);
                Debug.LogWarning(attackerBody.name.ToString() + " attacked " + self.body.name.ToString());
            }
            orig(self, damageInfo);
        }
    }
}
