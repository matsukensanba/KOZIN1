using UnityEngine;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    [Header("スピード設定")]
    public float forwardSpeed = 50.0f;
    public float maxSpeed = 100.0f;
    public float minSpeed = 10.0f;
    public float acceleration = 20.0f;

    [Header("回転設定")]
    public float rollSpeed = 150.0f;
    public float pitchSpeed = 60.0f;

    [Header("UI設定")]
    public Slider speedSlider;
    public Image gaugeImage; // ゲージの色を変えるための画像（Fill）
    public Color lowSpeedColor = Color.blue; // 低速時の色
    public Color highSpeedColor = Color.red; // 高速時の色

    void Start()
    {
        if (speedSlider != null)
        {
            speedSlider.minValue = minSpeed;
            speedSlider.maxValue = maxSpeed;
        }
    }

    void Update()
    {
        // 加減速・移動・回転の処理（前回と同じなので省略可）
        HandleMovement();

        // ゲージの表示と色の更新
        if (speedSlider != null)
        {
            speedSlider.value = forwardSpeed;

            // スピードの割合（0.0 ～ 1.0）を計算
            float speedPercent = (forwardSpeed - minSpeed) / (maxSpeed - minSpeed);

            // 割合に応じて色を混ぜる（青から赤へ）
            if (gaugeImage != null)
            {
                gaugeImage.color = Color.Lerp(lowSpeedColor, highSpeedColor, speedPercent);
            }
        }
    }

    // 移動処理をまとめたメソッド
    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift)) forwardSpeed += acceleration * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftControl)) forwardSpeed -= acceleration * Time.deltaTime;
        forwardSpeed = Mathf.Clamp(forwardSpeed, minSpeed, maxSpeed);

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward * -horizontal * rollSpeed * Time.deltaTime);
        float vertical = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right * vertical * pitchSpeed * Time.deltaTime);
    }
}