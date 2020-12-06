﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;


namespace MyGame
{
    [InitializeOnLoad]
    public class SceneCreator
    {
        static SceneCreator()
        {
            EditorSceneManager.newSceneCreated += SceneCreated;
        }

        public static void SceneCreated(Scene scene, NewSceneSetup setup, NewSceneMode mode)
        {
            GameObject SetupGO = new GameObject("[SETUP]");
            GameObject WorldGO = new GameObject("[WORLD]");
            GameObject UI_GO = new GameObject("[UI]");

            GameObject CamsGO = new GameObject("Cameras");
            GameObject LightsGO = new GameObject("Lights");
            GameObject StarterGO = new GameObject("World");
            GameObject StorageGO = new GameObject("Storage");

            GameObject StaticWorldGO = new GameObject("Static");
            GameObject DynamicWorldGO = new GameObject("Dynamic");

            GameObject InterfaceGO = new GameObject("Interface");

            GameObject Camera = GameObject.Find("Main Camera");
            GameObject Light = GameObject.Find("Directional Light");

            CamsGO.transform.SetParent(SetupGO.transform);
            LightsGO.transform.SetParent(SetupGO.transform);
            StarterGO.transform.SetParent(SetupGO.transform);
            StorageGO.transform.SetParent(SetupGO.transform);

            StaticWorldGO.transform.SetParent(WorldGO.transform);
            DynamicWorldGO.transform.SetParent(WorldGO.transform);

            InterfaceGO.transform.SetParent(UI_GO.transform);

            Camera.transform.SetParent(CamsGO.transform);
            Light.transform.SetParent(LightsGO.transform);
        }
    }
}