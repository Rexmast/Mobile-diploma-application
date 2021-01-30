using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField]
    int LifeTimeAnimationSecond;
    void Start()
    {
        Destroy(gameObject, LifeTimeAnimationSecond);
    }
}
