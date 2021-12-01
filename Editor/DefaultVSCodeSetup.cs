using UnityEditor;
using UnityEngine;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;

public static class DefaultVSCodeSetup {

    [MenuItem("Tools/Setup/Create Default Folders")]
    static void CreateDefaultFolders() {
        CreateGitIgnore();
        CreateVSCodeSettings();
        CreateOmniSharpSettings();

        Refresh();
    }

    static void CreateGitIgnore() {
        
    }

    static void CreateVSCodeSettings() {
        
    }

    static void CreateOmniSharpSettings() {
        
    }
}
