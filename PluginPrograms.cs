using Jacobi.Vst.Framework;
using Jacobi.Vst.Framework.Plugin;

namespace NixMidiTransposer
{
    /// <summary>
    /// This object manages the Plugin programs and its parameters.
    /// </summary>
    internal sealed class PluginPrograms : VstPluginProgramsBase
    {
        private Plugin _plugin;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="plugin">A reference to the plugin root object.</param>
        public PluginPrograms(Plugin plugin)
        {
            _plugin = plugin;
            ParameterCategories = new VstParameterCategoryCollection();
            ParameterInfos = new VstParameterInfoCollection();
        }
        
        /// <summary>
        /// Gets a collection of parameter categories.
        /// </summary>
        /// <remarks>
        /// This is the central list that contains all parameter categories.
        /// </remarks>
        public VstParameterCategoryCollection ParameterCategories { get; set; }

        /// <summary>
        /// Gets a collection of parameter definitions.
        /// </summary>
        /// <remarks>
        /// This is the central list that contains all parameter definitions for the plugin.
        /// </remarks>
        public VstParameterInfoCollection ParameterInfos { get; set; }

        /// <summary>
        /// Called to initialize the collection of programs for the plugin.
        /// </summary>
        /// <returns>Never returns null or an empty collection.</returns>
        protected override VstProgramCollection CreateProgramCollection()
        {
            VstProgramCollection programs = new VstProgramCollection();
            //!  You can add multiple programs here.
            VstProgram program = CreateProgram(ParameterInfos);
            program.Name = "Default";
            programs.Add(program);
            return programs;
        }

        // create a program with all parameters.
        private VstProgram CreateProgram(VstParameterInfoCollection parameterInfos)
        {
            VstProgram program = new VstProgram(ParameterCategories);
            CreateParameters(program.Parameters, parameterInfos);
            return program;
        }

        // create all parameters
        private void CreateParameters(VstParameterCollection destination, VstParameterInfoCollection parameterInfos)
        {
            foreach (VstParameterInfo paramInfo in parameterInfos)
                destination.Add(CreateParameter(paramInfo));
        }

        // create one parameter
        private VstParameter CreateParameter(VstParameterInfo parameterInfo)
        {
            VstParameter parameter = new VstParameter(parameterInfo);
            return parameter;
        }
    }
}

