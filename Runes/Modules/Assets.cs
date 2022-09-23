using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace RunesPlugin.Modules
{
    internal static class Assets
    {
        internal static AssetBundle mainAssetBundle;
        private static string[] assetNames = new string[0];

        internal static void Initialize()
        {
            LoadAssetBundle();
            PopulateAssets();
        }

        internal static void PopulateAssets()
        {
            if (!mainAssetBundle)
            {
                return;
            }

        }

        internal static void LoadAssetBundle()
        {
            try
            {
                if (mainAssetBundle == null)
                {
                    using (var assetStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RunesPlugin.runesplugin"))
                    {
                        mainAssetBundle = AssetBundle.LoadFromStream(assetStream);
                    }
                }
            }
            catch (Exception e)
            {
                //Log.Error("Failed to load assetbundle. Make sure your assetbundle name is setup correctly\n" + e);
                return;
            }

            assetNames = mainAssetBundle.GetAllAssetNames();
        }
    }
}
