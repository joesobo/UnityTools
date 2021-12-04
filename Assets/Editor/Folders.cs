using static UnityEngine.Application;
using static System.IO.Directory;
using static System.IO.Path;

public static class Folders {

    public static void CreateDirectories(string root, params string[] dir) {
        foreach (string newDir in dir) {
            CreateDirectory(Combine(dataPath, root, newDir));
        }
    }
}
