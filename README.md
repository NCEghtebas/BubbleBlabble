MidiJack - MIDI Input Plug-in for Unity
=======================================

**MidiJack** is a native code plug-in for Unity. It allows Unity to communicate
with external MIDI controllers.

Demo
----

You can find two demo projects in the [test branch]
(https://github.com/keijiro/MidiJack/tree/test).

#### Note

The first demo "Note" shows how to get key presses and releases from MidiJack.
The size of the cubes are relative to velocity of a key press.

![Screenshot1](http://keijiro.github.io/MidiJack/screenshot1.png)

#### CC

The second demo "CC" shows how to get CC (control change) data from MidiJack.

![Screenshot2](http://keijiro.github.io/MidiJack/screenshot2.png)

System Requirement
------------------

- Currently supports only Mac OS X.
- Requires Unity Pro to enable native plug-in feature.

Setting Up
----------

1. Import **MidiJackPlugin.bundle** into '**Plugins**' folder in your project.
2. Import **MidiJack.cs**.
3. Open *Script Execution Order Settings* (Edit -> Project Settings -> Script
   Execution Order) and set the **MidiJack** script to the highest priority.
4. (Optional) Import **MidiJackEditor.cs** into '**Editor**' folder in your
   project.

You can view the history of incoming MIDI messages by importing
MidiJackEditor.cs into your project. If you don't need the history view,
step-4 isn't necessary.

Component Reference
-------------------

The exposed interface of AudioJack is designed to look like [Input class]
(http://docs.unity3d.com/Documentation/ScriptReference/Input.html) in Unity.
You can access to the state of keys (notes) and knobs (CC values) via public
class functions.

Note: *You can omit channel arguments from these functions. In this case it
returns the union of the all channels.*


#### GetKey (channel, noteNumber)

Returns the state of the key. If the key is "on", it returns the velocity value
(more than zero, up to 1.0f). If the key is "off", it returns zero.

#### GetKeyDown (channel, noteNumber)

Returns true only if the key was pressed down in the current frame.

#### GetKeyUp (channel, noteNumber)

Returns true only if the key was released in the current frame.

#### GetKnob (channel, knobNumber)

Returns the current knob (CC) value which will be between 0.0f and 1.0f.

#### GetKnobNumbers (channel)

Provides the list of knob (CC) numbers that has sent any CC messages.

See Also
--------

The source code for the native module is stored in another repository.

[MidiJackPlugin for OS X]
(https://github.com/keijiro/MidiJackPlugin)

License
-------

Copyright (C) 2013 Keijiro Takahashi

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
