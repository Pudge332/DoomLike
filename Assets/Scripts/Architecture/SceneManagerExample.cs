using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SceneManagerExample : SceneManagerBase
{
    public override void InitializeSceneDict()
    {
        sceneConfigDict[SceneConfigExample.SCENE_NAME] = new SceneConfigExample();
    }
}
