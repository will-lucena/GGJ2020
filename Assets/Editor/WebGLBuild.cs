using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

// Build WebGL em linha de comando, pra publicar o jogo em will-lucena.com.br/jogar/:
//   Unity.exe -batchmode -quit -projectPath . -buildTarget WebGL -executeMethod WebGLBuild.Build -logFile -
// Sai em Builds/WebGL (ignorado pelo git). Sem compressão: o Caddy comprime na entrega,
// e .br/.gz pré-comprimido exigiria header Content-Encoding por arquivo no servidor.
public static class WebGLBuild
{
    // Fontes do TMP feitas em 2019 (formato 1.x) só são convertidas quando o editor as
    // carrega; sem isso o build mostra blocos no lugar do texto.
    static void AtualizarFontes()
    {
        foreach (var guid in AssetDatabase.FindAssets("t:TMP_FontAsset"))
        {
            var fonte = AssetDatabase.LoadAssetAtPath<TMPro.TMP_FontAsset>(AssetDatabase.GUIDToAssetPath(guid));
            if (fonte == null) continue;
            fonte.ReadFontAssetDefinition();
            EditorUtility.SetDirty(fonte);
        }
        AssetDatabase.SaveAssets();
    }

    public static void Build()
    {
        AtualizarFontes();
        PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Disabled;
        PlayerSettings.WebGL.decompressionFallback = false;

        var cenas = EditorBuildSettings.scenes.Where(c => c.enabled).Select(c => c.path).ToArray();
        var relatorio = BuildPipeline.BuildPlayer(cenas, "Builds/WebGL", BuildTarget.WebGL, BuildOptions.None);

        Sair(relatorio);
    }

    // Build Windows pra conferir que o jogo roda, sem depender do módulo WebGL.
    public static void BuildWindows()
    {
        AtualizarFontes();
        var cenas = EditorBuildSettings.scenes.Where(c => c.enabled).Select(c => c.path).ToArray();
        var relatorio = BuildPipeline.BuildPlayer(cenas, "Builds/Windows/Jogo.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
        Sair(relatorio);
    }

    // Teste de fumaça: build Windows que abre direto na cena da variável JOGO_CENA
    // (ex.: Game), pra conferir que o gameplay carrega sem precisar passar pelo menu.
    public static void BuildWindowsCena()
    {
        AtualizarFontes();
        var nome = System.Environment.GetEnvironmentVariable("JOGO_CENA");
        var cenas = EditorBuildSettings.scenes.Where(c => c.enabled).Select(c => c.path)
            .OrderBy(p => System.IO.Path.GetFileNameWithoutExtension(p) == nome ? 0 : 1).ToArray();
        var relatorio = BuildPipeline.BuildPlayer(cenas, "Builds/WindowsCena/Jogo.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
        Sair(relatorio);
    }

    static void Sair(BuildReport relatorio)
    {
        Debug.Log($"[WebGLBuild] {relatorio.summary.platform} {relatorio.summary.result} · {relatorio.summary.totalSize / 1024 / 1024} MB · {relatorio.summary.totalErrors} erro(s)");
        EditorApplication.Exit(relatorio.summary.result == BuildResult.Succeeded ? 0 : 1);
    }
}
