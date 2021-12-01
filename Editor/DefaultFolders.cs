using UnityEditor;
using UnityEngine;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;

public static class DefaultFolders {
    
    [MenuItem("Tools/Setup/Create Default Folders")]
    public static void CreateDefaultFolders() {
        CreateDirectories("", "Scripts", "Scenes", "Prefabs", "Materials", "Shaders", "Editor", "Plugins");

        Refresh();
    }

    public static void CreateDirectories(string root, params string[] dir) {
        string fullPath = Combine(dataPath, root);

        foreach (string newDir in dir) {
            CreateDirectory(Combine(fullPath, newDir));
        }
    }
}
