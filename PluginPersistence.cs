/* This allows us to persist data between sessions.
 */
namespace NixMidiTransposer
{
    using System;
    using System.IO;
    using System.Text;

    using Jacobi.Vst.Core;
    using Jacobi.Vst.Framework;

    class PluginPersistence : IVstPluginPersistence
    {
        private Plugin _plugin;
        private Encoding _encoding = Encoding.ASCII;

        public PluginPersistence(Plugin plugin)
        {
            _plugin = plugin;
        }

        #region IVstPluginPersistence Members

        public bool CanLoadChunk(VstPatchChunkInfo chunkInfo)
        {
            return true;
        }

        public void ReadPrograms(Stream stream, VstProgramCollection programs)
        {
            BinaryReader reader = new BinaryReader(stream, _encoding);
            _plugin.Transpose.Semitones = reader.ReadInt32();
            _plugin.Transpose.FromValue = reader.ReadInt32();
        }

        public void WritePrograms(Stream stream, VstProgramCollection programs)
        {
            BinaryWriter writer = new BinaryWriter(stream, _encoding);
            writer.Write(_plugin.Transpose.Semitones);
            writer.Write(_plugin.Transpose.FromValue);
        }

        #endregion
    }
}
