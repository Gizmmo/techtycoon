using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extensions {

	/// <summary>
	/// Returns a list of all Transforms that are children of this transform
	/// </summary>
	/// <param name="t">The transform to search</param>
	/// <returns>A list of all transforms that are children of this transform</returns>
	public static List<Transform> GetChildren(this Transform t) {
		return t.Cast<Transform>().ToList();
	}

	/// <summary>
	/// Returns a list of all gameobjects that are children of this Transform
	/// </summary>
	/// <param name="t">The transform to search</param>
	/// <returns>A List of all gameobjects that are children of this transform</returns>
	public static List<GameObject> GetChildrenAsGameObjects(this Transform t) {
		return t.Cast<Transform>().Select(n => n.gameObject).ToList();
	}

	/// <summary>
	/// Finds an immediate child of this transform by a given tag
	/// </summary>
	/// <param name="t">The transform to extend</param>
	/// <param name="tag">The tag to search by</param>
	/// <returns>The found gameobject</returns>
	public static Transform FindChildByTag(this Transform t, string tag) {
		return t.Cast<Transform>().First(c => c.CompareTag(tag));
	}

	/// <summary>
	/// Calls the delegate if it is not null
	/// </summary>
	/// <param name="action">The action to be called</param>
	/// <param name="go">The gameobject passed</param>
	public static void Run(this Action<GameObject> action, GameObject go) {
		if (action != null) {
			action(go);
		}
	}

	/// <summary>
	/// Calls the delegate if it is not null
	/// </summary>
	/// <param name="action">The action to be called</param>
	public static void Run(this Action action) {
		if(action != null) {
			action();
		}
	}

	/// <summary>
	/// Calls the delegate if it is not null
	/// </summary>
	/// <param name="func">The func to be called</param>
	public static bool Run(this Func<bool> func) {
		return func.GetInvocationList().Cast<Func<bool>>().All(checkscript => checkscript());
	}

	/// <summary>
	/// Calls the delegate if it is not null
	/// </summary>
	/// <param name="func">The func to be called</param>
	/// <param name="go">The gameobject passed</param>
	public static bool Run(this Func<GameObject, bool> func, GameObject go) {
		return func.GetInvocationList().Cast<Func<GameObject, bool>>().All(checkscript => checkscript(go));
	}

	/// <summary>
	/// Calls the delegate if it is not null
	/// </summary>
	/// <param name="func">The func to be called</param>
	/// <param name="go">The gameobject passed</param>
	public static bool RunOrIsNull(this Func<GameObject, bool> func, GameObject go) {
		return func == null || Run(func, go);
	}

	/// <summary>
	/// Calls the delegate if it is not null
	/// </summary>
	/// <param name="func">The func to be called</param>
	public static bool RunOrIsNull(this Func<bool> func) {
		return func == null || Run(func);
	}

	/// <summary>
	/// Destroys the passed gameobject as long as it exists
	/// </summary>
	/// <param name="g"></param>
	public static void SafeDestroy(this GameObject g) {
		if (g != null) {
			UnityEngine.Object.Destroy(g);
		}
	}

	/// <summary>
	/// Sets the parent of the given gameobject as the other gameobject passed
	/// </summary>
	/// <param name="g">The gameobject to set the parent of</param>
	/// <param name="parent">The parent gameobject</param>
	public static void SetParent(this Transform t, Transform parent) {
		t.parent = parent;
	}

	/// <summary>
	/// Sets the parent of the given gameobject as the other gameobject passed
	/// </summary>
	/// <param name="g">The gameobject to set the parent of</param>
	/// <param name="parent">The parent gameobject</param>
	public static void SetParent(this GameObject g, GameObject parent) {
		g.transform.parent = parent.transform;
	}

	/// <summary>
	/// Sets the x position of the transform to the float passed
	/// </summary>
	/// <param name="t">The transform to set</param>
	/// <param name="x">The new x value</param>
	public static void SetPositionX(this Transform t, float x) {
		t.position = new Vector3(x, t.position.y, t.position.z);
	}

	/// <summary>
	/// Sets the y position of the transform to the float passed
	/// </summary>
	/// <param name="t">The transform to set</param>
	/// <param name="y">The new y value</param>
	public static void SetPositionY(this Transform t, float y) {
		t.position = new Vector3(t.position.x, y, t.position.z);
	}

	/// <summary>
	/// Sets the z position of the transform to the float passed
	/// </summary>
	/// <param name="t">The transform to set</param>
	/// <param name="z">The new z value</param>
	public static void SetPositionZ(this Transform t, float z) {
		t.position = new Vector3(t.position.x, t.position.y, z);
	}

}
