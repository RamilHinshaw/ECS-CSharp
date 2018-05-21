using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace RamilH.ECS
{
	/// <summary>
	/// Lightweight WIP Entity Component System
	/// </summary>
	public class Entity
	{
		/// <summary>
		/// TO DO: ADD CACHING!
		/// </summary>


		private bool enabled; //If Entity is in an active state

		public string Id { get; set; }	//Unique Name
		private List<Component> components;


		public Entity(string Id)
		{
			this.Id = Id;
			components = new List<Component>();
			enabled = true;
		}

		//Generic with contraints to IComponent
		public Component GetComponent<T>() where T : Component
		{
			var component = components.OfType<T>().FirstOrDefault();

			if (component == null) 
				throw new Exception("This Component does not on this Entity!");

			return component;
		}


		public void AddComponent<T>() where T : Component, new()
		{
			if (HasComponent<T>() == false)
				throw new Exception("This Component already Exists on this Entity!");
			
			components.Add(new T() );
		}

		public void RemoveComponent<T>() where T : Component
		{
			if (HasComponent<T>() == false)
				throw new Exception("This Component does not on this Entity!");

			Component component = GetComponent<T>();
			components.Remove(component);		
		}

		public bool HasComponent<T>()  where T : Component
		{ 
			//If there exist a component that with type T then return true
			var component = components.Any(c => c.GetType() == typeof(T));
			return (component) ? true : false;
		}

		//public void RemoveAllComponents()
		//{
		//	var T = Component.GetType();
		//	for (int i = components.Count - 1; i >= 0; i--)
		//		RemoveComponent<components[i].GetType()>();
		//}


		public void SetActive(bool enabled) { this.enabled = enabled;}
		public void ToggleActive() { enabled = !enabled;}
		public bool IsActive() { return enabled; }


	}
}
