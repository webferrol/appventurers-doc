using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI.Tweens;
using System;
using System.Collections;

namespace UnityEngine.UI
{
	[RequireComponent(typeof(RectTransform)), RequireComponent(typeof(LayoutElement))]
	public class UIAccordionElement : Toggle {

		[SerializeField] private float m_MinHeight = 18f;
		
		private UIAccordion m_Accordion;
		private RectTransform m_RectTransform;
		private LayoutElement m_LayoutElement;
		//private Image m_image;
		
		[NonSerialized]
		private readonly TweenRunner<FloatTween> m_FloatTweenRunner;
		
		protected UIAccordionElement()
		{
			if (this.m_FloatTweenRunner == null)
				this.m_FloatTweenRunner = new TweenRunner<FloatTween>();
			
			this.m_FloatTweenRunner.Init(this);
		}
		
		protected override void Awake()
		{
			base.Awake();
			base.transition = Transition.None;
			base.toggleTransition = ToggleTransition.None;
			this.m_Accordion = this.gameObject.GetComponentInParent<UIAccordion>();
			this.m_RectTransform = this.transform as RectTransform;
			this.m_LayoutElement = this.gameObject.GetComponent<LayoutElement>();
			this.onValueChanged.AddListener(OnValueChanged);



			//this.m_image = this.GetComponent<Image>();
			//if (this.m_image != null)
			//{
   //            Debug.Log("Image found");
   //         }

			
		}
		
		protected override void OnValidate()
		{
			base.OnValidate();

			
			if (this.group == null)
			{
				ToggleGroup tg = this.GetComponentInParent<ToggleGroup>();
				
				if (tg != null)
				{
					this.group = tg;
				}
			}
			
			LayoutElement le = this.gameObject.GetComponent<LayoutElement>();
			
			if (le != null)
			{
				if (this.isOn)
				{
					le.preferredHeight = -1f;
				}
				else
				{
					le.preferredHeight = this.m_MinHeight;
				}
			}
		}
		
		public void OnValueChanged(bool state)
		{
			
			//Debug.Log(this.isOn);

			//GetComponentInChildren<Image>().rectTransform.rotation = Quaternion.Euler(0, 0, this.isOn ? 180 : 0);

			//public class RotateImage : MonoBehaviour
		//{
            //    public void Rotate()
			//{
                    // Rotate the object 90 degrees around the y-axis
             //       transform.Rotate(0, 90, 0);
            //    }
            //}

			if (this.m_LayoutElement == null)
				return;
			
			UIAccordion.Transition transition = (this.m_Accordion != null) ? this.m_Accordion.transition : UIAccordion.Transition.Instant;
			
			if (transition == UIAccordion.Transition.Instant)
			{
				if (state)
				{
					this.m_LayoutElement.preferredHeight = -1f;
				}
				else
				{
					this.m_LayoutElement.preferredHeight = this.m_MinHeight;
				}
			}
			else if (transition == UIAccordion.Transition.Tween)
			{
				if (state)
				{
					this.StartTween(this.m_MinHeight, this.GetExpandedHeight());
				}
				else
				{
					this.StartTween(this.m_RectTransform.rect.height, this.m_MinHeight);
				}
			}
		}
		
		protected float GetExpandedHeight()
		{
			if (this.m_LayoutElement == null)
				return this.m_MinHeight;
			
			float originalPrefH = this.m_LayoutElement.preferredHeight;
			this.m_LayoutElement.preferredHeight = -1f;
			float h = LayoutUtility.GetPreferredHeight(this.m_RectTransform);
			this.m_LayoutElement.preferredHeight = originalPrefH;
			return h;
		}
		
		protected void StartTween(float startFloat, float targetFloat)
		{
			float duration = (this.m_Accordion != null) ? this.m_Accordion.transitionDuration : 0.3f;
			
			FloatTween info = new FloatTween
			{
				duration = duration,
				startFloat = startFloat,
				targetFloat = targetFloat
			};
			info.AddOnChangedCallback(SetHeight);
			info.ignoreTimeScale = true;
			this.m_FloatTweenRunner.StartTween(info);
		}
		
		protected void SetHeight(float height)
		{
			if (this.m_LayoutElement == null)
				return;
				
			this.m_LayoutElement.preferredHeight = height;
		}
	}
}