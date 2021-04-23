using System;
using UnityEditor;
using UnityEngine;

namespace Butler.Editor
{

    [CreateAssetMenu(fileName = "ButlerSettings", menuName = "Butler/Create ButlerSettings", order = 1)]
    public class ButlerSettings : ScriptableObject
    {
        private static ButlerSettings butlerAsset;
        public static ButlerSettings Instance
        {
            get
            {
                if (butlerAsset == null)
                    butlerAsset = AssetDatabase.LoadAssetAtPath<ButlerSettings>("Assets/Butler/ButlerSettings.asset");
                if (butlerAsset == null)
                    throw new Exception("Unable to find ButlerSettings asset file");
                return butlerAsset;
            }
        }

        public string GameName = "game-name";
        public string UserName = "username";
        public bool BuildAndroid = false;
        public bool BuildWeb = false;
        public bool BuildPC = false;

        public string KeystorePassword = "";
        public string KeystoreAlias = "";
        public string KeystoreAliasPassword = "";
    }
}