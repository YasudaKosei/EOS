# About *Switch VR Kit* package

Use the **Switch VR Kit** package to implementing XR supporting in Nintendo Switch.



# Installation

## Dependencies

* XR Management
* XR Legacy Input helpers

## How to install manually

* Copy 'com.unity.xr.switchvrkit' folder to 'Packages' folder in local project folder.

## How to install with Package Manager

* Open 'Package Manager'

* Click '+' Button & Select 'Add package from disk...'

* Select 'com.unity.xr.switchvrkit/package.json'



# Using Switch VR Kit

* Add 'VR Kit Loader' in Project Settings > XR Plugin Management > Loaders
* Set 'Target Eye' in Main Camera to 'Both'
* Add 'Tracked Pose Driver' in Main Camera

## How to disable VR mode on startup

* Open Project Settings > XR Plugin Management

* Turn off 'Initialize on Startup'

## How to toggle VR mode on runtime

* Use below property value.

`bool UnityEngine.Switch.VRKit.deviceConnected { get; set; }`

## How to use custom rendering

* Can draw distorted images for target render target (Once per frame)

`UnityEngine.Switch.VRKit.AddGraphicsThreadDistortionBlit(commandBuffer, renderTexture);`

This command should be called after WaitForEndOfFrame().

See also XRSwitchCustomRenderSample.cs

## About TextureLayout

* Added to support TextureLayout.

`enum TextureLayout
{
    SingleTexture2D = 2, // Experimental, this layout is still unstable.
    SeparateTexture2Ds = 4 // Default layout.
}`

`UnityEngine.Switch.VRKit.TextureLayout UnityEngine.Switch.VRKit.textureLayout { get; set; }`

* The default setting can be found in XR settings page.
* This setting can be changed dynamically.
* SingleTexture2D is still unstable. It'll cause a performance regression & some glich.

### Limitation

* SingleTexture2D won't be supported with Post Processing.


# Technical details

## Requirements

This version of **Switch VR Kit** is compatible with the following versions of the Unity Editor:

* 2019.3 and later (recommended)

## Known limitations

* Single pass stereo rendering isn't supported.

* Script define 'UNITY_SWITCH_VRKIT' will be available yet if this package is removed. It should be removed manually.
