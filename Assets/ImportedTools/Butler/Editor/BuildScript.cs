using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Butler.Editor
{
    public class BuildScript
    {
        public static void RefreshAssets()
        {
            AssetDatabase.Refresh();
        }

        [MenuItem("Build/Itch.io Build 'n Push All", false, 0)]
        public static void BuildAll()
        {
            if (!BuildAll_Internal())
                throw new Exception("Problem Building - Please See Build Log Output");
        }

        private static bool BuildAll_Internal()
        {
            if (ButlerSettings.Instance.BuildAndroid && !AndroidBuild())
                return false;
            if (ButlerSettings.Instance.BuildPC && !WindowsBuild())
                return false;
            if (ButlerSettings.Instance.BuildWeb && !WebBuild())
                return false;
            return true;
        }

        [MenuItem("Build/Itch.io Build Web", false, 10)]
        public static bool WebBuild()
        {
            var result = BuildPipeline.BuildPlayer(new BuildPlayerOptions
            {
                scenes = GetScenes(),
                locationPathName = "Builds/Web",
                target = BuildTarget.WebGL,
                options = BuildOptions.None

            });
            if (result.summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded)
                return false;
            
            return true;
        }

        private static string[] GetScenes()
        {
            List<string> result = new List<string>();
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                result.Add(SceneUtility.GetScenePathByBuildIndex(i));
            }
            return result.ToArray();
        }

        [MenuItem("Build/Itch.io Push Web", false, 11)]
        public static void WebPush()
        {
            Process.Start(new ProcessStartInfo("butler", $@"push .\Builds\Web {ButlerSettings.Instance.UserName}/{ButlerSettings.Instance.GameName}:Web"));
        }

        [MenuItem("Build/Itch.io Build Windows", false, 12)]
        public static bool WindowsBuild()
        {
            var result = BuildPipeline.BuildPlayer(new BuildPlayerOptions
            {
                scenes = GetScenes(),
                locationPathName = $"Builds/PC/{ButlerSettings.Instance.GameName}.exe",
                target = BuildTarget.StandaloneWindows,
                options = BuildOptions.None
            });
            if (result.summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded)
                return false;
            
            return true;
        }

        [MenuItem("Build/Itch.io Push Windows", false, 13)]
        public static void WindowsPush()
        {
            Process.Start(new ProcessStartInfo("butler", $@"push .\Builds\PC {ButlerSettings.Instance.UserName}/{ButlerSettings.Instance.GameName}:PC"));
        }

        [MenuItem("Build/Itch.io Build Android", false, 14)]
        public static bool AndroidBuild()
        {
            PlayerSettings.Android.keystorePass = ButlerSettings.Instance.KeystorePassword;
            PlayerSettings.Android.keyaliasName = ButlerSettings.Instance.KeystoreAlias;
            PlayerSettings.Android.keyaliasPass = ButlerSettings.Instance.KeystoreAliasPassword;
            var result = BuildPipeline.BuildPlayer(new BuildPlayerOptions
            {
                scenes = GetScenes(),
                locationPathName = $"Builds/Android/{ButlerSettings.Instance.GameName}.apk",
                target = BuildTarget.Android,
                options = BuildOptions.None
            });
            if (result.summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded)
                return false;
            return true;
        }

        [MenuItem("Build/Itch.io Push Android", false, 15)]
        public static void AndroidPush()
        {
            Process.Start(new ProcessStartInfo("butler", $@"push .\Builds\Android\{ButlerSettings.Instance.GameName}.apk {ButlerSettings.Instance.UserName}/{ButlerSettings.Instance.GameName}:Android"));
        }
    }
}