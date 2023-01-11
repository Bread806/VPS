using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour {
    
    public static DamagePopup Creat (Vector3 position, int damageAmount) {
        Transform damagePopupTransform = Instantiate (GameAssets.gameAssets.pfDamgePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        
        damagePopup.SetUp (damageAmount);
        return damagePopup;
    }

    private const float DISAPPER_TIMER_MAX = 0.5f;

    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;

    private void Awake() {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    private void Update() {
        float moveYSpeed = 1f;
        transform.position += new Vector3 (0, moveYSpeed) * Time.deltaTime;

        // 前半popup存活時間
        if (disappearTimer > DISAPPER_TIMER_MAX * 0.5f) {
            float increaseScaleAmount = 1f;
            this.transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        // 後半opup文字存活時間
        else {
            float decreaseScaleAmount = 1f;
            this.transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;
        // 文字開始消失
        if (disappearTimer < 0) {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0) {
                Destroy (this.gameObject);
            }
        }
    }

    public void SetUp (int damageAmount) {
        textMesh.SetText (damageAmount.ToString());
        disappearTimer = DISAPPER_TIMER_MAX;
        textColor = textMesh.color;
    }
}
