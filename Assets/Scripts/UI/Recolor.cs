using UnityEngine;


public class Recolor : MonoBehaviour
{
    [SerializeField] private MeshRenderer _recolorObject;
    [SerializeField] private float _sliderMaxValue;
    [SerializeField] private float _sliderMinValue;
    [SerializeField] private int _stepBetweenSliders;

    private Color _rgba;

    private void OnGUI()
    {
        _rgba = RGBASlider(new Rect(_stepBetweenSliders, 30, 200, 20), _rgba);
        _recolorObject.material.color = _rgba;
    }

    private float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText)
    {
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);
        GUI.Label(labelRect, labelText);
        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height);
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, sliderMinValue, sliderMaxValue);
        return sliderValue;
    }

    Color RGBASlider(Rect screenRect, Color rgba)
    {
        rgba.r = LabelSlider(screenRect, rgba.r, _sliderMinValue, _sliderMaxValue, "Red");

        screenRect.y += _stepBetweenSliders;
        rgba.g = LabelSlider(screenRect, rgba.g, _sliderMinValue, _sliderMaxValue, "Green");

        screenRect.y += _stepBetweenSliders;
        rgba.b = LabelSlider(screenRect, rgba.b, _sliderMinValue, _sliderMaxValue, "Blue");

        screenRect.y += _stepBetweenSliders;
        rgba.a = LabelSlider(screenRect, rgba.a, _sliderMinValue, _sliderMaxValue, "Alfa");

        return rgba;
    }
}
