using System.IO;
using UnityEngine;
using UnityEditor;

/*
 Creates an Asset Bundle out of the selected assets.
Limitations: Assets for different skins have to be in different folders
since the creation is renaming the assests so they could be searched easily.
 */
public class AssetBundleWindow : EditorWindow
{
    private Sprite XMark;
    private Sprite OMark;
    private Sprite background;
    private string assetBundleName;

    [MenuItem("Window/Create Asset Bundle")]
    public static void ShowWindow() => GetWindow<AssetBundleWindow>("Create Asset Bundle");
    

    private void OnGUI()
    {
        XMark = EditorGUILayout.ObjectField("X Mark Sprite", XMark, typeof(Sprite), false) as Sprite;
        OMark = EditorGUILayout.ObjectField("O Mark Sprite", OMark, typeof(Sprite), false) as Sprite;
        background = EditorGUILayout.ObjectField("Background", background, typeof(Sprite), false) as Sprite;
        assetBundleName = EditorGUILayout.TextField("Asset Bundle Name", assetBundleName);


        if (GUILayout.Button("Create"))
            CreateAssetBundle();
    }

    private void CreateAssetBundle()
    {
        AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(XMark), "XMarkSprite");
        AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(OMark), "OMarkSprite");
        AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(background), "BackgroundSprite");

        AssetBundleBuild[] buildMap = new AssetBundleBuild[1];

        buildMap[0].assetBundleName = assetBundleName;
        string[] assets = new string[3];
        
        assets[0] = AssetDatabase.GetAssetPath(XMark);
        assets[1] = AssetDatabase.GetAssetPath(OMark);
        assets[2] = AssetDatabase.GetAssetPath(background);
        
        buildMap[0].assetNames = assets;
        if(!Directory.Exists(Application.streamingAssetsPath))
            Directory.CreateDirectory(Application.streamingAssetsPath);
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, buildMap, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
