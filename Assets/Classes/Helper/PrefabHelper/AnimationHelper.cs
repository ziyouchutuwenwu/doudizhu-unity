using UnityEngine;
using System.Collections;

public class AnimationHelper : MonoBehaviour {

    public static void addFeiJiAnimation()
    {
        Transform prefab = Resources.Load<Transform>("prefab/animation/feiJi");
        Instantiate(prefab, new Vector3(0, 1, 0.01f), Quaternion.identity);
    }

    public static void addHuoJianAnimation()
    {
        Transform prefab = Resources.Load<Transform>("prefab/animation/huoJian");
        Instantiate(prefab, new Vector3(0, 1, 0.01f), Quaternion.identity);
    }

    public static void addZhaDanAnimation()
    {
        Transform prefab = Resources.Load<Transform>("prefab/animation/zhaDan");
        Instantiate(prefab, new Vector3(0, 1, 0.01f), Quaternion.identity);
    }

    public static void addShunZiAnimation()
    {
        Transform prefab = Resources.Load<Transform>("prefab/animation/shunZi");
        Instantiate(prefab, new Vector3(0, 1, 0.01f), Quaternion.identity);
    }
}