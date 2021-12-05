using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public static class Packages {

    public static async Task ReplacePackages(string user = "joesobo") {
        var url = GetGistUrl("bb50095572f02a180a3a2653a07c5db0", user);
        var contents = await GetContents(url);
        ReplaceFile(contents, "../Packages/manifest.json");
    }

    public static async Task ReplaceGitIgnore(string user = "joesobo") {
        var url = GetGistUrl("0d06e1d576df73a96a57f24b775afd0c", user);
        var contents = await GetContents(url);
        ReplaceFile(contents, "../.gitignore");
    }

    public static async Task ReplaceOmnisharp(string user = "joesobo") {
        var url = GetGistUrl("149d7f062f32938a38b6e81c18d185ca", user);
        var contents = await GetContents(url);
        ReplaceFile(contents, "../omnisharp.json");
    }

    static string GetGistUrl(string id, string user = "joesobo") => $"https://gist.github.com/{user}/{id}/raw";

    static async Task<string> GetContents(string url) {
        using HttpClient client = new HttpClient();
        var response = await client.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

    static void ReplaceFile(string content, string path) {
        var existing = Path.Combine(Application.dataPath, path);
        File.WriteAllText(existing, content);
        UnityEditor.PackageManager.Client.Resolve();
    }

    public static void InstallUnityPackage(string packageName) => UnityEditor.PackageManager.Client.Add($"com.unity.{packageName}");
}