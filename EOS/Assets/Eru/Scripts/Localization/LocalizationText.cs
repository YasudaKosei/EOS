using UnityEngine;
using UnityEngine.UI;

public class LocalizationText : MonoBehaviour
{
    [SerializeField, Header("ディスプレイ")]
    private Text screenMode;

    [SerializeField]
    private Text screenModeLabel, resolution, language, languageLabel, x_sensitivity, y_sensitivity;

    [SerializeField]
    private Dropdown screenDD;

    [SerializeField]
    private Dropdown languageDD;

    [SerializeField, Header("キーボード")]
    private Text k_up;

    [SerializeField]
    private Text k_down, k_right, k_left, k_jump, k_retry, k_pause;

    [SerializeField, Header("ゲームパッド")]
    private Text p_jump;

    [SerializeField]
    private Text p_retry, p_pause;


    void Update()
    {
        if (DisplayManager.JapaneseFlg) Japanese();
        else English();
    }

    private void Japanese()
    {
        //ディスプレイ設定
        screenMode.text = "スクリーンモード";
        resolution.text = "解像度";
        language.text = "言語";
        languageDD.options[0].text = "日本語";
        languageDD.options[1].text = "英語";
        if (languageDD.value == 0) languageLabel.text = "日本語";
        else languageLabel.text = "英語";
        x_sensitivity.text = "X軸(左右)感度";
        y_sensitivity.text = "Y軸(上下)感度";
        screenDD.options[0].text = "フルスクリーン";
        screenDD.options[1].text = "ウィンドウ";
        if (screenDD.value == 0) screenModeLabel.text = "フルスクリーン";
        else screenModeLabel.text = "ウィンドウ";

        //キーボード設定
        k_up.text = "上移動";
        k_down.text = "下移動";
        k_right.text = "右移動";
        k_left.text = "左移動";
        k_jump.text = "ジャンプ";
        k_retry.text = "リトライ";
        k_pause.text = "ポーズ";

        //ゲームパッド
        p_jump.text = "ジャンプ";
        p_retry.text = "リトライ";
        p_pause.text = "ポーズ";
    }

    private void English()
    {
        //ディスプレイ設定
        screenMode.text = "ScreenMode";
        resolution.text = "Resolution";
        language.text = "Language";
        languageDD.options[0].text = "Japanese";
        languageDD.options[1].text = "English";
        if (languageDD.value == 0) languageLabel.text = "Japanese";
        else languageLabel.text = "English";
        x_sensitivity.text = "SensitivityX";
        y_sensitivity.text = "SensitivityY";
        screenDD.options[0].text = "FullScreen";
        screenDD.options[1].text = "Window";
        if (screenDD.value == 0) screenModeLabel.text = "FullScreen";
        else screenModeLabel.text = "Window";

        //キーボード設定
        k_up.text = "Up";
        k_down.text = "Down";
        k_right.text = "Right";
        k_left.text = "Left";
        k_jump.text = "Jump";
        k_retry.text = "Retry";
        k_pause.text = "Pause";

        //ゲームパッド
        p_jump.text = "Jump";
        p_retry.text = "Retry";
        p_pause.text = "Pause";
    }
}
