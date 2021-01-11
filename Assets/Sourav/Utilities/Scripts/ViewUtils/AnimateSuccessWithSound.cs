﻿using DG.Tweening;
using Sourav.Engine.Core.GameElementRelated;
using Sourav.Engine.Editable.DataRelated;
using Sourav.Engine.Editable.NotificationRelated;
using Sourav.Engine.Engine.Core.ApplicationRelated;
using UnityEngine;

namespace Sourav.Utilities.Scripts.ViewUtils
{
    public class AnimateSuccessWithSound : GameElement, IAnimate
    {
        [SerializeField] private GameObject soundPrefab;
        
        public void Animate(Transform transform)
        {
            float originalScale = transform.localScale.x;
            float scale = 0.5f * transform.localScale.x;
            transform.localScale = new Vector3(scale, scale, scale);
            transform.DOScale(new Vector3(originalScale, originalScale, originalScale), 0.1f).SetEase(Ease.OutBack);
            if (App.GetData<LevelCommonData>().IsSfxOn)
            {
                GameObject gObjSound = Instantiate(soundPrefab, transform);
                Destroy(gObjSound, 2f);
            }
            App.Notify(Notification.HapticFailure);
        }
    }
}
