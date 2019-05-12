/* This is the Midi processor, which is called to process MIDI once every cycle.

*/

using System.ComponentModel;
using Jacobi.Vst.Core;
using Jacobi.Vst.Framework;
using System.Collections;
using System.Collections.Generic;

namespace NixMidiTransposer
{

    /// <summary>
    /// Implements the incoming Midi event handling for the plugin.
    /// </summary>
    class MidiProcessor : IVstMidiProcessor
    {
        #region constants

        #endregion // constants

        private Plugin _plugin;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="plugin">Must not be null.</param>
        public MidiProcessor(Plugin plugin)
        {
            _plugin = plugin;
            Events = new VstEventCollection();
            NoteOnEvents = new Queue<byte>();
            //InitializeParameters();
        }

        /// <summary>
        /// Gets the midi events that should be processed in the current cycle.
        /// </summary>
        public VstEventCollection Events { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating wether non-handled midi events should be passed to the output.
        /// </summary>
        public bool MidiThru { get; set; }

        /// <summary>
        /// The raw note on note numbers.
        /// </summary>
        public Queue<byte> NoteOnEvents { get; private set; }

        #region IVstMidiProcessor Members

        public int ChannelCount
        {
            get { return _plugin.ChannelCount; }
        }

        public void Process(VstEventCollection events)
        {
            int _transposeSemitones = _plugin.Transpose.Semitones;
            foreach (VstEvent anyEvent in events)
            {
                if (anyEvent.EventType != VstEventTypes.MidiEvent) continue;

                VstMidiEvent midiEvent = (VstMidiEvent)anyEvent;
               

                if (((midiEvent.Data[0] & 0xF0) == 0x80 || (midiEvent.Data[0] & 0xF0) == 0x90))
                {   // these are all the note on and note off events.
                    if (_transposeSemitones != 0)
                    {
                        VstMidiEvent mappedEvent = null;
                        byte[] midiData = new byte[4];
                        midiData[0] = midiEvent.Data[0];
                        int _note = midiEvent.Data[1] + _transposeSemitones;
                        if (_note < 0 || _note > 127) continue; // skip out of range notes.
                        midiData[1] = (byte)_note;
                        midiData[2] = midiEvent.Data[2];
                        mappedEvent = new VstMidiEvent(midiEvent.DeltaFrames,
                            midiEvent.NoteLength,
                            midiEvent.NoteOffset,
                            midiData,
                            midiEvent.Detune,
                            midiEvent.NoteOffVelocity);
                        Events.Add(mappedEvent);
                        // add raw note-on note numbers to the queue
                        if ((midiEvent.Data[0] & 0xF0) == 0x90)
                        {
                            lock (((ICollection)NoteOnEvents).SyncRoot)
                            {
                                NoteOnEvents.Enqueue(midiEvent.Data[1]);
                            }
                        }
                    }
                    else
                    {   // we're not transposing, so just pass it through.
                        Events.Add(anyEvent);
                    }
                }
                else
                {   // not a midi on-off event, so pass it through.
                    Events.Add(anyEvent);
                }
            }
        }
        #endregion
    }
}