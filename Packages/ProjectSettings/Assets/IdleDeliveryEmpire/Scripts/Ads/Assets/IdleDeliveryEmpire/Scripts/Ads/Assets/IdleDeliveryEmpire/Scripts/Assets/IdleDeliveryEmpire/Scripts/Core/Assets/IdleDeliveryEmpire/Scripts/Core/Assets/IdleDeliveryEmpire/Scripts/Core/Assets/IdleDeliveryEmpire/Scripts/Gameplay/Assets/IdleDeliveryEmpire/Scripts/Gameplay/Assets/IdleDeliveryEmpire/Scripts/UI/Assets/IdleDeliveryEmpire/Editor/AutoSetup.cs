#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using IdleDeliveryEmpire.Core;
using IdleDeliveryEmpire.Gameplay;
using IdleDeliveryEmpire.UI;
using IdleDeliveryEmpire.Ads;

[InitializeOnLoad]
public static class AutoSetup
{
    static AutoSetup()
    {
        if (EditorApplication.isUpdating || Application.isBatchMode == false) return;
        Ensure();
    }

    static void Ensure()
    {
        var scenesPath = "Assets/IdleDeliveryEmpire/Scenes";
        var dataPath = "Assets/IdleDeliveryEmpire/Data";
        System.IO.Directory.CreateDirectory(scenesPath);
        System.IO.Directory.CreateDirectory(dataPath);

        var currency = AssetDatabase.LoadAssetAtPath<Currency>($"{dataPath}/Currency.asset");
        if (!currency)
        {
            currency = ScriptableObject.CreateInstance<Currency>();
            AssetDatabase.CreateAsset(currency, $"{dataPath}/Currency.asset");
        }

        var bootPath = $"{scenesPath}/Boot.unity";
        if (!System.IO.File.Exists(bootPath))
        {
            var s = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
            new GameObject("AdManager").AddComponent<AdManager>();
            new GameObject("AppOpenAdManager").AddComponent<AppOpenAdManager>();
            new GameObject("BootLoader").AddComponent<BootLoader>();
            EditorSceneManager.SaveScene(s, bootPath);
        }

        var gamePath = $"{scenesPath}/Game.unity";
        if (!System.IO.File.Exists(gamePath))
        {
            var s = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);

            var gm = new GameObject("GameManager").AddComponent<GameManager>();
            gm.cash = AssetDatabase.LoadAssetAtPath<Currency>($"{dataPath}/Currency.asset");

            var depot = new GameObject("Depot").AddComponent<Depot>();
            var veh = new GameObject("Vehicle").AddComponent<DeliveryVehicle>();
            depot.vehicle = veh;
            depot.cash = gm.cash;

            var canvas = new GameObject("HUD", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

            var cashText = new GameObject("CashText", typeof(RectTransform), typeof(Text)).GetComponent<Text>();
            cashText.transform.SetParent(canvas.transform);
            cashText.alignment = TextAnchor.UpperLeft;
            cashText.fontSize = 36;
            cashText.text = "Cash: 0";
            var rt = cashText.GetComponent<RectTransform>();
            rt.anchorMin = new Vector2(0, 1);
            rt.anchorMax = new Vector2(0, 1);
            rt.anchoredPosition = new Vector2(120, -60);
            rt.sizeDelta = new Vector2(400, 80);

            var btn = new GameObject("WatchAdButton", typeof(RectTransform), typeof(Image), typeof(Button)).GetComponent<Button>();
            btn.transform.SetParent(canvas.transform);
            var brt = btn.GetComponent<RectTransform>();
            brt.sizeDelta = new Vector2(380, 100);
            brt.anchorMin = new Vector2(1, 0);
            brt.anchorMax = new Vector2(1, 0);
            brt.anchoredPosition = new Vector2(-220, 140);

            var txt = new GameObject("Text", typeof(RectTransform), typeof(Text)).GetComponent<Text>();
            txt.transform.SetParent(btn.transform);
            txt.alignment = TextAnchor.MiddleCenter;
            txt.text = "Watch Ad x2 (10m)";
            var txtrt = txt.GetComponent<RectTransform>();
            txtrt.anchorMin = Vector2.zero;
            txtrt.anchorMax = Vector2.one;
            txtrt.offsetMin = Vector2.zero;
            txtrt.offsetMax = Vector2.zero;

            var hud
