/* This is the main plugin, instantiated by the PluginCommandStub
 * 
 * A reference to this is passed to the all it creates, and it manages possible multiple instances of the plugin.
 */


using Jacobi.Vst.Core;
using Jacobi.Vst.Framework;
using Jacobi.Vst.Framework.Plugin;

namespace NixMidiTransposer
{
    /// <summary>
    /// The Plugin root class that implements the interface manager and the plugin midi source.
    /// </summary>
    class Plugin : VstPluginWithInterfaceManagerBase, IVstPluginMidiSource
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Plugin()
            : base("Nix Midi Transpose", new VstProductInfo("Based on VST.NET", "nm & Jacobi Software(c)2011..2016", 1000),
                VstPluginCategory.Effect, VstPluginCapabilities.NoSoundInStop, 0, 0x30313233)
        {
            //NoteMap = new MapNoteItemList();
            Transpose = new ViewModel(this);
        }

        /// <summary>
        /// Gets the current audio processor object.
        /// </summary>
        public AudioProcessor AudioProcessor
        {
            get { return GetInstance<AudioProcessor>(); }
        }

        /// <summary>
        /// Gets the current midi processor object.
        /// </summary>
        public MidiProcessor MidiProcessor
        {
            get { return GetInstance<MidiProcessor>(); }
        }

        /// <summary>
        /// Gets the current plugin editor object.
        /// </summary>
        public PluginEditor PluginEditor
        {
            get { return GetInstance<PluginEditor>(); }
        }

        /// <summary>
        /// Gets the plugin programs object.
        /// </summary>
        public PluginPrograms PluginPrograms
        {
            get { return GetInstance<PluginPrograms>(); }
        }
        // <summary>
        // Creates a default instance and reuses that for all threads.
        // </summary>
        // <param name="instance">A reference to the default instance or null.</param>
        // <returns>Returns the default instance.</returns>
        protected override IVstPluginAudioProcessor CreateAudioProcessor(IVstPluginAudioProcessor instance)
        {
            if (instance == null) return new AudioProcessor(this);

            return instance;
        }

        /// <summary>
        /// Creates a default instance and reuses that for all threads.
        /// </summary>
        /// <param name="instance">A reference to the default instance or null.</param>
        /// <returns>Returns the default instance.</returns>
        protected override IVstPluginEditor CreateEditor(IVstPluginEditor instance)
        {
            if (instance == null) return new PluginEditor(this);

            return instance;
        }

        /// <summary>
        /// Creates a default instance and reuses that for all threads.
        /// </summary>
        /// <param name="instance">A reference to the default instance or null.</param>
        /// <returns>Returns the default instance.</returns>
        protected override IVstMidiProcessor CreateMidiProcessor(IVstMidiProcessor instance)
        {
            if (instance == null) return new MidiProcessor(this);

            return instance;
        }

        /// <summary>
        /// Creates a default instance and reuses that for all threads.
        /// </summary>
        /// <param name="instance">A reference to the default instance or null.</param>
        /// <returns>Returns the default instance.</returns>
        protected override IVstPluginPersistence CreatePersistence(IVstPluginPersistence instance)
        {
            if (instance == null) return new PluginPersistence(this);

            return instance;
        }

        /// <summary>
        /// Always returns <b>this</b>.
        /// </summary>
        /// <param name="instance">A reference to the default instance or null.</param>
        /// <returns>Returns the default instance <b>this</b>.</returns>
        protected override IVstPluginMidiSource CreateMidiSource(IVstPluginMidiSource instance)
        {
            return this;
        }

        #region IVstPluginMidiSource Members

        /// <summary>
        /// Returns the channel count as reported by the host
        /// </summary>
        public int ChannelCount
        {
            get
            {
                IVstMidiProcessor midiProcessor = null;
                
                if(Host != null)
                {
                    midiProcessor = Host.GetInstance<IVstMidiProcessor>();
                }

                if (midiProcessor != null)
                {
                    return midiProcessor.ChannelCount;
                }

                return 0;
            }
        }

        #endregion

        /// <summary>
        /// Implement this when you implement plugin programs or presets.
        /// </summary>
        /// <param name="instance">A previous instance returned by this method. 
        /// When non-null, return a thread-safe version (or wrapper) for the object.</param>
        /// <returns>Returns null when not supported by the plugin.</returns>
        protected override IVstPluginPrograms CreatePrograms(IVstPluginPrograms instance)
        {
            //! This is availiable here but has not been linked to the parameters defined elsewhere.
            //! This should be integrated at some stage.
            if (instance == null)
            {
                return new PluginPrograms(this);
            }
            return base.CreatePrograms(instance);
        }

        // Nick added for transposing:
        public ViewModel Transpose { get; set; }
    }
}
