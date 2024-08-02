# Changelog

## [1.1.8] - 2024-03-14
- Fix the memory alignment issue on Unity 6.

## [1.1.7] - 2023-11-27
- Fix the settings for VRKitBootstrap.cpp on Unity 2020.3. (Unable to boot VRKit Plugin)
- Fix to build errors for managed dlls Unity 2023.3.0a15 or later. (Only on importing plugin as .tgz)

## [1.1.6] - 2023-11-21
- Fix the build error on Unity 2023.3.0a15 or later.
- Fix the buffer count issue on Unity 2023.3.0a15 or later.

## [1.1.5] - 2023-06-20

- Fix XRInputSubsystem.GetTrackingOriginMode() from Unknown to Device.

## [1.1.4] - 2023-04-26

- Fix the build error on 2023.2.0a11 or later.

## [1.1.3] - 2023-03-31

* Fix plugin version selector.

## [1.1.2] - 2023-03-17

* Fix script define issue on XR management 4.3.3 or later.
* Reformat souce codes.

## [1.1.1] - 2022-12-12

* Fix compiler warning with deprecated API. (Use Camera.allCameras instead of Object.FindObjectsOfType<>())

## [1.1.0] - 2022-09-29

* Fix runtime error that 'globalgamemanagers.assets' is corrupted.

## [1.0.2] - 2022-09-26

* Add native plugin which is built with SDK 14.3.0.
* Fix rendering issue on distortion rendering. (Available black triangles.)

## [1.0.1] - 2022-06-08

* Fix compiler issue when incremental builds is enabled.

## [1.0.0] - 2021-11-18

* Remove preview & update version to 1.0.0

## [0.5.6] - 2021-11-15

* Package is now signed

## [0.5.5] - 2021-09-03

* TextureLayout.SingleTexture2D is marked as Experimental.
* 'UnityEngine.Switch.VRKit.MessageRequestToEndVrMode' has been defined as 'int' in Editor Mode.
* Add warning for 'UnityEngine.Switch.VRKit.MessageRequestToEndVrMode' on Editor Mode.

## [0.5.4] - 2021-07-14

* Fix the issue on PC build

## [0.5.3] - 2021-07-06

* Fix the right eye rendering issue with legacy point lights
* Support TextureLayout.SingleTexture2D
* Added UnityEngine.Switch.VRKit.textureLayout

## [0.5.2] - 2021-04-19

* Fix missing reference with fix the issue on console build

## [0.5.1] - 2021-04-07

* Fix the issue on console build

## [0.5.0] - 2021-03-29

* Fix the issue on importing from Package directory

## [0.4.9] - 2021-03-16

* Support sRGB

## [0.4.8] - 2021-03-01

* Fix warnings on InputSystem
* Remove legacy workarounds

## [0.4.7] - 2020-12-09

* Add supporting InputSystem

## [0.4.6] - 2020-11-05

* Support UnityEngine.Switch.VRKit.AddGraphicsThreadDistortionBlit() for custom rendering

## [0.4.5] - 2020-10-26

* Improve upward compatibility

## [0.4.4] - 2020-10-12

* Support graphics debugging with ReprojectionMethod.Disabled

## [0.4.3] - 2020-10-07

* Support UnityEngine.Switch.VRKit.defaultIpd
* Support UnityEngine.Switch.VRKit.frustumShiftRate

## [0.4.2] - 2020-10-05

* Support UnityEngine.Switch.VRKit.ipd
* Update denepdencies to XR management 3.2.15

## [0.4.1] - 2020-09-30

* Set manufacturer name for XRInput

## [0.4.0] - 2020-08-25

* Support new XR interface on 2020.1 or later (Still supporting legacy XR interface)

## [0.3.5] - 2020-07-06
* Update denepdencies to XR management 3.2.13

## [0.3.4] - 2020-06-26
* Support New APIs in XRDisplaySubsystem

## [0.3.3] - 2020-05-27
* Improve issues on Graphics.Blit() (Mirror rendering, ...)

## [0.3.2] - 2020-05-13
* Improve for HDR Rendering issue
* Change depending package to  XR management 3.2.10

## [0.3.1] - 2020-04-28
* Improve for supporting XR management 3.2.9

## [0.3.0] - 2020-03-16
* Prepare for supporting XR management 3.2.0 or later (Keeping to support older version.)

## [0.2.5] - 2020-03-04
* Bugfix on handling for script defines

## [0.2.4] - 2020-01-29
* Update SDK
* Improve to handle deprecated properties

## [0.2.3] - 2020-01-22
* Add comments on source codes

## [0.2.2] - 2020-01-20
* Remove warnings on package validation

## [0.2.1] - 2020-01-09
* Update dependencies to XR management 3.0.5
* Fix a loader listup issue on XR management in Player Settings

## [0.2.0] - 2019-12-17
* Support manually start with Six Axis Sensor APIs

## [0.1.9] - 2019-12-09
* Fix renderer issue on debug hud

## [0.1.8] - 2019-12-03
* Change package name to com.unity.xr.switchvrkit
* Add SDK version selector

## [0.1.7] - 2019-11-20
* Remove legacy codes
* Fix internal implementations

## [0.1.6] - 2019-11-19
* Add simply test

## [0.1.5] - 2019-11-13
* Minimal changes (Internal source organizing)

## [0.1.4] - 2019-11-12
* Fix a render issue on drawing logo

## [0.1.3] - 2019-11-12
* Support refresh rate property value

## [0.1.2] - 2019-11-08
* Prepare a license document

## [0.1.1] - 2019-11-06
* Prepare documents as Markdown
* Add Script Define *UNITY_SWITCH_VRKIT* when XR support is enabled on Switch

## [0.1.0] - 2019-10-30
* Fix compile error on non Switch platforms

## [0.0.9] - 2019-10-29
* Fix null reference in editor extension

## [0.0.8] - 2019-10-23
* Optimize deviceConnected

## [0.0.7] - 2019-10-23
* Add UnityEngine.Switch.VRKit.MessageRequestToEndVrMode

## [0.0.6] - 2019-10-21
* Fix issue on blend state (Fix no display in some case.)

## [0.0.5] - 2019-10-16
* Improve performance on rendering, skip to reset rendring state

## [0.0.4] - 2019-10-15
* Improve performance on mirror rendering (Disabling mirror rendering on Switch)

## [0.0.3] - 2019-10-15
* Fix projection matrix issue

## [0.0.2] - 2019-10-04
* Fix recenter issue

## [0.0.1] - 2019-10-02
* Support XR management 3.0.3 (Fix compile error)

* Override VR player settings if XR management is enabled.

> PlayerSettings.virtualRealitySupported = true;
> PlayerSettings.stereoRenderingPath = StereoRenderingPath.MultiPass;

## [0.0.0] - 2019-09-17

* This is the first release of *Switch VR Kit*.
