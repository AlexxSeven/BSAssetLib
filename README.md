# BSAssetLib
BSAssetLib is a very simple utility mod aimed at shader makers, but designed for both shader and asset makers to get the most out of the player's active color scheme. This mod was heavily inspired by mods such as AudioLink and SaberFactory which create global variables for parts of the active color scheme, but don't expose the entire scheme to be used. The main goal was to split this functionality into its own mod that would be easy to keep up to date so assets which rely on it aren't left without their needed variables for long after a game update.

Shoutout to [Aeroluna](https://github.com/Aeroluna) for https://github.com/Aeroluna/BSAudioLink which served as a very very heavy reference for this since my understand of beatsaber modding is minimal at best.

## For asset makers:
- If the shader you're using has support for this mod, you will need to list it as a requirement for your asset if you use the features. If you want a shader to support it, you can send the link to this github to the creator who's shader you are using.
The list of global variables is as follows.
## For shader makers:
- This mod creates several global color variables which can be called inside of a shader to pull colors from the current color scheme the player has active.

The global variables are:
```
_ColSaberL \\Left Saber Color
_ColSaberR \\Right Saber Color
_ColLight0 \\Fist Light Color
_ColLight1 \\Second Light Color
_ColBoost0 \\First Boost Color (or) First Light Color if scheme unsupported
_ColBoost1 \\Second Boost Color (or) Second Light Color if scheme unsupported
_ColWall \\Obsticals Color
```
> [!IMPORTANT]
> don't expose these varibales inside of the shader property block as they're meant to be global and will be set by the mod.

To call a global variable inside the shader:
- First define the variable before your fragment program such as `float4 _ColSaberL;`.
- Then you can reference this later inside your fragment program when needed such as `finalCol = _ColSaberL`.

For shader makers using Amplify. the `AssetLib Example.shader` in this repo can be imported and opened to see the node soup on how you can utilize global variables via a node shader editor. 