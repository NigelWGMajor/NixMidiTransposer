using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Jacobi.Vst.Framework;

namespace NixMidiTransposer
{
    /// <summary>
    /// The plugin custom editor UI.
    /// </summary>
    partial class MidiNoteMapperUI : UserControl
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public MidiNoteMapperUI()
        {
            InitializeComponent();
        }
        private ViewModel _transpose;
        /// <summary>
        /// Nick added: number of semitones to transpose.
        /// </summary>
        public ViewModel Transpose
        {
            get { return _transpose; }
            set
            {
                _transpose = value;
               // numericUpDown1.Value = _transpose.Semitones;
            }
        }
        /// <summary>
        /// Contains a queue with note-on note numbers currently playing.
        /// </summary>
        public Queue<byte> NoteOnEvents { get; set; }
        /// <summary>
        /// This is the idle-processing loop.
        /// </summary>
        public void ProcessIdle()
        {
            ;
        }
        private void MidiNoteMapperUI_Load(object sender, EventArgs e)
        {
            ;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            RefreshSliders();
        }
        /// <summary>
        /// Refreshes the slider positions based on the semitones setting
        /// </summary>
        private void RefreshSliders()
        {
            eBig.Text = eSemitones.Text;
            _transpose.Semitones = (int)eSemitones.Value;
            int _i = (int)(eSemitones.Value + eFrom.Value);
            while (_i < 0) _i = _i + 12;
            while (_i > 12) _i = _i - 12;
            eTo.Value = _i;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Transpose.FromValue = eFrom.Value;
            Recalculate();
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Recalculate();
        }
        /// <summary>
        /// Recalculate the offset base on the slider positions
        /// </summary>
        private void Recalculate()
        {
            eSemitones.Value = (decimal)(eTo.Value - eFrom.Value);
            ShowUpDown();
        }
        private void ShowUpDown()
        {
            if (eSemitones.Value == 12)
                cUpDown.Text = "Zero";
            else if (eSemitones.Value > 0)
                cUpDown.Text = "<-- Down";
            else if (eSemitones.Value < 0)
                cUpDown.Text = "Up -->";
            else if (eSemitones.Value == 0)
                cUpDown.Text = "<-- Down";
        }
        private void cUpDown_Click(object sender, EventArgs e)
        {
            if (eSemitones.Value == -12) eSemitones.Value = 12.0M; // wrap around... 
            else if (eSemitones.Value >= 0) eSemitones.Value -= 12;
            else eSemitones.Value += 12;
            ShowUpDown();
        }
        private void MidiNoteMapperUI_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true && Transpose != null)
            {
                eSemitones.Value = (Decimal)Transpose.Semitones;
                eFrom.Value = Transpose.FromValue;
                RefreshSliders();
            }
        }
        private void cDropOctave_Click(object sender, EventArgs e)
        {
            if (eSemitones.Value >= -12)
            {
                eSemitones.Value -= 12;
                RefreshSliders(); ;
            }
        }
        private void cAddOctave_Click(object sender, EventArgs e)
        {
            if (eSemitones.Value < 13)
            {
                eSemitones.Value += 12;
                RefreshSliders(); ;
            }
        }
    }
}
