using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// 挂在 ClickableLid 上！
public class JarAnimationController : MonoBehaviour, IPointerClickHandler
{
    [Tooltip("要切换图片的目标 Image（通常是 JarDisplay）")]
    public Image targetImage;

    [Tooltip("罐头打开的帧序列")]
    public Sprite[] frames;

    [Tooltip("淡入淡出切换的总时间（秒）")]
    public float fadeDuration = 0.3f;

    private int currentFrameIndex = 0;
    private CanvasGroup canvasGroup;

    void Start()
    {
        // 自动添加 CanvasGroup（用于控制透明度）
        if (targetImage == null)
        {
            Debug.LogError("请在 Inspector 中指定 Target Image！");
            return;
        }

        canvasGroup = targetImage.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = targetImage.gameObject.AddComponent<CanvasGroup>();

        // 显示第一帧
        if (frames.Length > 0)
            targetImage.sprite = frames[0];
        else
            Debug.LogWarning("没有设置帧图片！");
    }

    // 只有点击 ClickableLid 才会调用
    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentFrameIndex >= frames.Length - 1)
        {
            Debug.Log("罐头已完全打开！");
            return;
        }

        currentFrameIndex++;
        StartCoroutine(FadeToNextFrame());
    }

    IEnumerator FadeToNextFrame()
    {
        // 淡出当前帧
        float time = 0f;
        while (time < fadeDuration / 2)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, time / (fadeDuration / 2));
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0f;

        // 切换到下一帧
        targetImage.sprite = frames[currentFrameIndex];

        // 淡入新帧
        time = 0f;
        while (time < fadeDuration / 2)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, time / (fadeDuration / 2));
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f;
    }
}