using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    // private Transform aimGunEndPointTransform;
    // public event EventHandler<OnShootEventArgs> OnShoot;
    // public class OnShootEventArgs : EventArgs {
    //     public Vector3 gunEndPointPosition;
    //     public Vector3 shootPosition;
    // }
    private void Awake() {
        aimTransform = transform.Find("Aim");
        // aimGunEndPointTransform = aimTransform.Find("GunEndPointPosition");

    }
    public static Vector3 GetMouseWorldPosition() {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera) {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera) {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
    private void Update() {
        HandleAiming();
        // HandleShooting();
    }
    private void HandleAiming() {
        Vector3 mousePosition = GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        //Debug.Log(angle);
    }
    // private void HandleShooting() {
    //     if (Input.GetMouseButtonDown(1)) {
    //         OnShoot?.Invoke(this, new OnShootEventArgs {
    //             gunEndPointPosition = aimGunEndPointTransform.position,
    //             shootPosition = mousePosition
    //         });
    //     }
    // }
}
