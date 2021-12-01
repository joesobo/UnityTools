using UnityEditor;
using UnityEngine;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;

public static class DefaultPackagesSetup {

    [MenuItem("Tools/Setup/Load New Manifest")]
    static void LoadNewManifest() {
        string url = GetGistUrl("bb50095572f02a180a3a2653a07c5db0");
        string contents = await GetContents(url);
        ReplacePackageFile(contents);
    }

    static void GetGistUrl(string id, string user = "joesobo") => $"https://gist.github.com/{user}/{id}/raw";

    static async Task<string> GetContents(string url) {
        using HttpClient client = new HttpClient();
        var response = await client.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

    static void ReplacePackageFile(string contents) {
        var existing = Path.Combine(Application.dataPath, "../Packages/manifest.json");
        File.WriteAllText(existing, contents);
        UnityEditor.PackageManager.Client.Resolve();
    }
}
