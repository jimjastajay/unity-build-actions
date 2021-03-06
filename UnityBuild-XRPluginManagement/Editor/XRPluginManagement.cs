using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.XR.Management;
using UnityEngine;
using UnityEngine.XR.Management;

namespace SuperSystems.UnityBuild
{
    public class XRPluginManagement : BuildAction, IPreBuildPerPlatformAction, IPostBuildPerPlatformAction
    {
        [Header("XR Settings")]
        [Tooltip("XR plugin loaders to use for this build")] public List<XRLoader> XRPlugins = new List<XRLoader>();
        [Tooltip("Whether or not to use automatic initialization of XR plugin loaders on startup")] public bool InitializeXROnStartup = true;

        public override void PerBuildExecute(BuildReleaseType releaseType, BuildPlatform platform, BuildArchitecture architecture, BuildDistribution distribution, DateTime buildTime, ref BuildOptions options, string configKey, string buildPath)
        {
            XRGeneralSettings generalSettings = XRGeneralSettingsPerBuildTarget.XRGeneralSettingsForBuildTarget(platform.targetGroup);
            XRManagerSettings settingsManager = generalSettings.Manager;

            generalSettings.InitManagerOnStart = InitializeXROnStartup;

            settingsManager.loaders = XRPlugins;
        }
    }
}
