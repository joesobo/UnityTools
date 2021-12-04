using UnityEditor;
using static UnityEditor.AssetDatabase;

public static class ToolsMenu {

    [MenuItem("Tools/Setup/Create Default Folders")]
    static void CreateDefaultFolders() {
        Folders.CreateDirectories("", "Scripts", "Scenes", "Prefabs", "Materials", "Shaders", "Editor", "Plugins");
        Refresh();
    }

    [MenuItem("Tools/Setup/Load New Manifest")]
    static async void LoadNewManifest() => await Packages.ReplacePackagesFromGist("bb50095572f02a180a3a2653a07c5db0");

    [MenuItem("Tools/Setup/Packages/New Input System")]
    static void AddNewInputSystem() => Packages.InstallUnityPackage("inputsystem");

    [MenuItem("Tools/Setup/Packages/CineMachine")]
    static void AddCineMachine() => Packages.InstallUnityPackage("cinemachine");
}
