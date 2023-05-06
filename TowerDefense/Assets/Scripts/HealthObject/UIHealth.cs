using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth
{
    private readonly Image healthImg;

    public UIHealth(Image _healthImg)
    {
        healthImg = _healthImg;
    }

    public virtual void Update(float value)
    {
        healthImg.fillAmount = value;
    }

}

public class UIRotatingHealth : UIHealth
{
    readonly RectTransform self;
    readonly Transform rotatingObj;
    readonly float initialRotation;

    public UIRotatingHealth(RectTransform _self, Transform _rotatingObj, Image _healthImg) : base(_healthImg)
    {
        self = _self;
        rotatingObj = _rotatingObj;
        initialRotation = self.localRotation.eulerAngles.y;
    }

    public override void Update(float value)
    {
        base.Update(value);
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        Vector3 currentRotation = self.localRotation.eulerAngles;
        float finalYRotation = initialRotation - rotatingObj.localRotation.eulerAngles.y;
        self.localRotation = Quaternion.Euler(new(currentRotation.x, finalYRotation, currentRotation.z));
    }
}
