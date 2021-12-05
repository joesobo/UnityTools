using UnityEditor;
using static UnityEditor.AssetDatabase;
using static Packages;

public static class ToolsMenu {

    [MenuItem("Tools/Setup/Load/Create Default Folders")]
    static void CreateDefaultFolders() {
        Folders.CreateDirectories("", "Scripts", "Scenes", "Prefabs", "Materials", "Shaders", "Editor", "Plugins");
        Refresh();
    }

    [MenuItem("Tools/Setup/Load/Load New Manifest")]
    static async void LoadNewManifest() => await ReplacePackages();

    [MenuItem("Tools/Setup/Load/Load New GitIgnore")]
    static async void LoadNewGitIgnore() => await ReplaceGitIgnore();

    [MenuItem("Tools/Setup/Load/Load Omnisharp")]
    static async void LoadNewOmnisharp() => await ReplaceOmnisharp();

    [MenuItem("Tools/Setup/Load/Load VSCode Settings")]
    static async void LoadNewVSCodeSettings() => await ReplaceVSCodeSettings();

    [MenuItem("Tools/Setup/Packages/New Input System")]
    static void AddNewInputSystem() => InstallUnityPackage("inputsystem");

    [MenuItem("Tools/Setup/Packages/CineMachine")]
    static void AddCineMachine() => InstallUnityPackage("cinemachine");
}
