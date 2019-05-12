/* This defines data storage for the plugin.  By instantiating it in the _plugin it is universally accessible.
 */

using System;
using System.Windows.Forms;
using Jacobi.Vst.Framework;

namespace NixMidiTransposer
{
    /// <summary>
    /// The supporting model.
    /// </summary>
    internal class ViewModel
    {
        public ViewModel(Plugin plugin)
        {
            _plugin = plugin;
            Semitones = 0;
            FromValue = 6;
            InitializeParameters();
        }

        private int _semitones;
        /// <summary>
        /// The offset, in semitones
        /// </summary>
        public int Semitones
        {
            get { return _semitones; }
            set
            {
                if (value == _semitones)
                    return; // break potential loop...
                _semitones = value;
                // Try complete the automation circle.
                SemitonesManager.ActiveParameter.Value = ((float)Semitones) ;
                // The host automation parameter editing cycle starts with getting a disposable edit session, in which the parameter can synchronize.
                // The using block disposes it.
            //!    if (SemitonesManager.HostAutomation != null)
            //        using (SemitonesManager.HostAutomation.BeginEditParameter(SemitonesManager.ActiveParameter))
            //        {
            //            SemitonesManager.HostAutomation.NotifyParameterValueChanged(SemitonesManager.ActiveParameter);
            //        }
            }
        }

        public int FromValue { get; set; }

        private Plugin _plugin;

        internal VstParameterManager SemitonesManager { get; set; }

        /// <summary>
        /// Sets up a parameter that can be learned or mapped to.
        /// </summary>
        private void InitializeParameters()
        {
            _plugin.PluginPrograms.ParameterCategories = new VstParameterCategoryCollection();
            _plugin.PluginPrograms.ParameterCategories.Add(new VstParameterCategory() { Name = "Transposer" });
            // Create parameter information:
            VstParameterInfo p = new VstParameterInfo()
            {
                Name = "Trans",
                CanBeAutomated = false, // false for now.  I don't know how to make the automatin respond to these changes. 
                CanRamp = true,
                DefaultValue = 0.5f,
                IsSwitch = false,
                Category = _plugin.PluginPrograms.ParameterCategories[0],
                Label = "Transpose",
                LargeStepFloat = 1.0f,
                LargeStepInteger = 1,
                MaxInteger = 12,
                MinInteger = -12,
                ShortLabel = "semitone", // max 8 characters!
                StepFloat = 1.0f,
                StepInteger = 1,
                SmallStepFloat = 1
            };
            // ...

            // Create Parameter Managers:

            VstParameterNormalizationInfo.AttachTo(p);
            SemitonesManager = new VstParameterManager(p);

            // ...



            // Add ParameterInfos to the global collection in the plugin.
            _plugin.PluginPrograms.ParameterInfos = new VstParameterInfoCollection();
            _plugin.PluginPrograms.ParameterInfos.Add(p);
            // ...
        }

        internal void ConnectHost()
        {   // This cannot be connected when initializing parameters, as the host does not yet exist.

            // Get the automation host:
            var hostAutomation = _plugin.Host.GetInstance<IVstHostAutomation>();
            // Connect to all Parmeter Managers:
            //!  SemitonesManager.HostAutomation = hostAutomation;
            // ...
        }



    }
}
