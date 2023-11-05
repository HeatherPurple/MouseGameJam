namespace GameJam.Features.UI
{
    using System;
    using System.Collections;
    using UnityEngine;
    /// <summary>
    /// Контроллер управления темнотой
    /// </summary>
    public class DarkController : MonoBehaviour
    {
        public float TimeShowDark = default;
        public float LightingFrequencyTime = default;

        private Coroutine _coroutineShowDark = default;
        private Coroutine _coroutineShowLightning = default;
        
        private DarkUiController _darkUiController = default;

        private IEnumerator DarkActive(float time)
        {
            _darkUiController.SetAlpha(1);
            _coroutineShowLightning = StartCoroutine(LightningActive(LightingFrequencyTime));
            yield return new WaitForSecondsRealtime(time);
            StopCoroutine(_coroutineShowLightning);
            _darkUiController.SetAlpha(0);
        }
        
        private IEnumerator LightningActive(float time)
        {
            while (true)
            {
                _darkUiController.ShowLightning();
                yield return new WaitForSeconds(time);
            }
            
        }

        private void Awake()
        {
            _darkUiController = FindObjectOfType<DarkUiController>();
        }
        /// <summary>
        /// Активировать тьму
        /// </summary>
        public void ShowDark()
        {
            if (_coroutineShowDark != null)
            {
                StopCoroutine(_coroutineShowDark);
                _coroutineShowDark = null;
            }
            
            _coroutineShowDark = StartCoroutine(DarkActive(TimeShowDark));
        }

        private void Start()
        {
            ShowDark();
        }
    }

}
