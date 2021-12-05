using UnityEditor;
using static UnityEditor.AssetDatabase;
using static Packages;

public static class ToolsMenu {

    [MenuItem("Tools/Setup/Create Default Folders")]
    static void CreateDefaultFolders() {
        Folders.CreateDirectories("", "Scripts", "Scenes", "Prefabs", "Materials", "Shaders", "Editor", "Plugins");
        Refresh();
    }

    [MenuItem("Tools/Setup/Load New Manifest")]
    static async void LoadNewManifest() => await ReplacePackagesFromGist("bb50095572f02a180a3a2653a07c5db0");

    [MenuItem("Tools/Setup/Load New GitIgnore")]
    static async void LoadNewGitIgnore() => await ReplaceGitIgnoreFromGist("0d06e1d576df73a96a57f24b775afd0c");

    [MenuItem("Tools/Setup/Packages/New Input System")]
    static void AddNewInputSystem() => InstallUnityPackage("inputsystem");

    [MenuItem("Tools/Setup/Packages/CineMachine")]
    static void AddCineMachine() => InstallUnityPackage("cinemachine");
}
