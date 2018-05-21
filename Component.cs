using System;
using System.Collections.Generic;

namespace RamilH.ECS
{
	public class Component
	{
		private bool enabled; //If Component is in an active state


		public Component()
		{
			
		}

		public virtual void Start() { }

		public virtual void Update() { }

		public virtual void Dispose() { }


		public void SetActive(bool enabled) { this.enabled = enabled; }
		public void ToggleActive() { enabled = !enabled; }
		public bool IsActive() { return enabled; }

	}
}
