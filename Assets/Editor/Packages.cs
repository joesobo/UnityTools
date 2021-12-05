using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public static class Packages {

    public static async Task ReplacePackagesFromGist(string id, string user = "joesobo") {
        var url = GetGistUrl(id, user);
        var contents = await GetContents(url);
        ReplacePackageFile(contents);
    }

    public static async Task ReplaceGitIgnoreFromGist(string id, string user = "joesobo") {
        var url = GetGistUrl(id, user);
        var contents = await GetContents(url);
        ReplaceGitIgnoreFile(contents);
    }

    static string GetGistUrl(string id, string user = "joesobo") => $"https://gist.github.com/{user}/{id}/raw";

    static async Task<string> GetContents(string url) {
        using HttpClient client = new HttpClient();
        var response = await client.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

    static void ReplacePackageFile(string content) {
        var existing = Path.Combine(Application.dataPath, "../Packages/manifest.json");
        File.WriteAllText(existing, content);
        UnityEditor.PackageManager.Client.Resolve();
    }

    static void ReplaceGitIgnoreFile(string content) {
        var existing = Path.Combine(Application.dataPath, "../.gitignore");
        File.WriteAllText(existing, content);
        UnityEditor.PackageManager.Client.Resolve();
    }

    public static void InstallUnityPackage(string packageName) => UnityEditor.PackageManager.Client.Add($"com.unity.{packageName}");
}