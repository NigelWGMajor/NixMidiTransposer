# Nix Midi Transposer

## A simple MIDI transposer.

This is a vst plug-in I use inside (Reaper)[https://www.reaper.fm/] (I have not needed to test in other DAWs) to transpose midi notes, as I am not equally competent on the keyboard in all keys!  

This uses the superb C# wrapper library [Vst.net](https://github.com/obiwanjacobi/vst.net) which in turn uses the [Steinberg VST SDK](https://www.steinberg.net/en/company/developers.html).

The jacobi.vst.core.dll and jacobi.vst.framework.dll (dotnet 4.0 versions) are refereneced in the GAC. You should download those yourself from the Jacobi repo.  You will also need the jacobi.vst.interop.dll which you will rename as described below.

## To deploy:

Build in release mode (visual studio).

If the references are broken, you will need to get them from the Jacobi site and GAC them.

The MidiTransposer.dll wrapper in the output folder is the actual vst seen by the DAW ... this is a renamed copy of the jacobi.vst.interop.dll as described in his documentation: it wraps the managed component which must be named MidiTransposer.net.dll.

Deployment to the DAW involves copying these files to (a folder in) the DAW plugin folder: (except the GAC files...unless you have a portable Reaper installation)

- Jacobi.Vst.Core.dll
- Jacobi.Vst.Framework.dll
- MidiTransposer.dll
- MidiTransposer.net.dll

Reaper should then find the vst and make it available.

I typically assign a knob on my keybpoard to the transposer.  It should be visible during use.
