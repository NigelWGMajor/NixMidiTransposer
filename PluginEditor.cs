/* This is the basic view.  It instantiates the visible control(s) and 
 * 
 */

using System.Collections.Generic;

namespace NixMidiTransposer
{
    using System;
    using Jacobi.Vst.Core;
    using Jacobi.Vst.Framework;
    using Jacobi.Vst.Framework.Common;

    /// <summary>
    /// Implements the custom UI editor for the plugin.
    /// </summary>
    class PluginEditor : IVstPluginEditor
    {
        private Plugin _plugin;
        private WinFormsControlWrapper<MidiNoteMapperUI> _view; 

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="plugin">Must not be null.</param>
        public PluginEditor(Plugin plugin)
        {
            _plugin = plugin;
            _view = new WinFormsControlWrapper<MidiNoteMapperUI>();
        }

        #region IVstPluginEditor Members

        public System.Drawing.Rectangle Bounds
        {
            get { return _view.Bounds; }
        }

        public void Close()
        {
            _view.Close();
        }

        public bool KeyDown(byte ascii, VstVirtualKey virtualKey, VstModifierKeys modifers)
        {
            return false;
        }

        public bool KeyUp(byte ascii, VstVirtualKey virtualKey, VstModifierKeys modifers)
        {
            return false;
        }

        public VstKnobMode KnobMode { get; set; }

        public void Open(IntPtr hWnd)
        {
           // passed transpose object to view.... this is older code before parameters.
            _view.SafeInstance.Transpose = _plugin.Transpose;
            _view.Open(hWnd);
            _plugin.Transpose.SemitonesManager.PropertyChanged += _view.SafeInstance.SemitonesParameterChanged;
            if (_plugin.Host != null)
                _plugin.Transpose.ConnectHost();
        }

        public void ProcessIdle()
        {
            _view.SafeInstance.ProcessIdle();
        }

        void IVstPluginEditor.KeyDown(byte ascii, VstVirtualKey virtualKey, VstModifierKeys modifers)
        {
            return;
        }

        void IVstPluginEditor.KeyUp(byte ascii, VstVirtualKey virtualKey, VstModifierKeys modifers)
        {
            return;
        }

        #endregion
    }
}
