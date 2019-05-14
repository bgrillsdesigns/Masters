using UnityEngine;
using System.Collections;


namespace TMPro.Examples
{
    
    public class ShaderPropAnimator : MonoBehaviour
    {

        private Renderer m_Renderer;
        private Material m_Material;

        public AnimationCurve GlowCurve;

        public float m_frame;

        void Awake()
        {
            // Cache a reference to object's renderer
            m_Renderer = GetComponent<Renderer>();

            // Cache a reference to object's material and create an instance by doing so.
            m_Material = m_Renderer.material;
        }

        void Start()
        {
            StartCoroutine(AnimateProperties());
        }

        IEnumerator AnimateProperties()
        {
//commented out code was ommited here 
            float glowPower;
            m_frame = Random.Range(0f, 1f);

            while (true)
            {
//commented out code was ommited here 
//commented out code was ommited here 

                glowPower = GlowCurve.Evaluate(m_frame);
                m_Material.SetFloat(ShaderUtilities.ID_GlowPower, glowPower);

                m_frame += Time.deltaTime * Random.Range(0.2f, 0.3f);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
