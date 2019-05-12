/* This provides the User Interface.  A WPF version (MVVM) would be nice!
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using Jacobi.Vst.Framework;

namespace NixMidiTransposer
{
    partial class MidiNoteMapperUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        internal void SemitonesParameterChanged(object sender, PropertyChangedEventArgs e)
        {
            var s = sender as VstParameterManager;
            float f = s.CurrentValue;
            int x = (int)Math.Round(f);
            _transpose.Semitones = x;
            if (this.Visible)
                Invoke(new Action(setBigText));
        }

        private void setBigText()
        {
            eBig.Text = eSemitones.Text = _transpose.Semitones.ToString();
        }
        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.eSemitones = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cUpDown = new System.Windows.Forms.Button();
            this.cDropOctave = new System.Windows.Forms.Button();
            this.cAddOctave = new System.Windows.Forms.Button();
            this.eFrom = new System.Windows.Forms.TrackBar();
            this.eTo = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.eBig = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.eSemitones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eTo)).BeginInit();
            this.SuspendLayout();
            // 
            // eSemitones
            // 
            this.eSemitones.Location = new System.Drawing.Point(163, 604);
            this.eSemitones.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.eSemitones.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.eSemitones.Minimum = new decimal(new int[] {
            24,
            0,
            0,
            -2147483648});
            this.eSemitones.Name = "eSemitones";
            this.eSemitones.Size = new System.Drawing.Size(81, 29);
            this.eSemitones.TabIndex = 4;
            this.toolTip1.SetToolTip(this.eSemitones, "Semitones to transpose (up or down)");
            this.eSemitones.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(42, 607);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Transpose:";
            // 
            // cUpDown
            // 
            this.cUpDown.BackColor = System.Drawing.Color.AliceBlue;
            this.cUpDown.ForeColor = System.Drawing.Color.Navy;
            this.cUpDown.Location = new System.Drawing.Point(321, 598);
            this.cUpDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cUpDown.Name = "cUpDown";
            this.cUpDown.Size = new System.Drawing.Size(150, 42);
            this.cUpDown.TabIndex = 9;
            this.cUpDown.Text = "up/down";
            this.toolTip1.SetToolTip(this.cUpDown, "Adjust the direction");
            this.cUpDown.UseVisualStyleBackColor = false;
            this.cUpDown.Click += new System.EventHandler(this.cUpDown_Click);
            // 
            // cDropOctave
            // 
            this.cDropOctave.BackColor = System.Drawing.Color.AliceBlue;
            this.cDropOctave.ForeColor = System.Drawing.Color.Navy;
            this.cDropOctave.Location = new System.Drawing.Point(321, 642);
            this.cDropOctave.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cDropOctave.Name = "cDropOctave";
            this.cDropOctave.Size = new System.Drawing.Size(75, 42);
            this.cDropOctave.TabIndex = 11;
            this.cDropOctave.Text = "- 8va";
            this.toolTip1.SetToolTip(this.cDropOctave, "Lower an octave");
            this.cDropOctave.UseVisualStyleBackColor = false;
            this.cDropOctave.Click += new System.EventHandler(this.cDropOctave_Click);
            // 
            // cAddOctave
            // 
            this.cAddOctave.BackColor = System.Drawing.Color.AliceBlue;
            this.cAddOctave.ForeColor = System.Drawing.Color.Navy;
            this.cAddOctave.Location = new System.Drawing.Point(396, 642);
            this.cAddOctave.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cAddOctave.Name = "cAddOctave";
            this.cAddOctave.Size = new System.Drawing.Size(75, 42);
            this.cAddOctave.TabIndex = 11;
            this.cAddOctave.Text = "+8va";
            this.toolTip1.SetToolTip(this.cAddOctave, "Raise an octave");
            this.cAddOctave.UseVisualStyleBackColor = false;
            this.cAddOctave.Click += new System.EventHandler(this.cAddOctave_Click);
            // 
            // eFrom
            // 
            this.eFrom.AutoSize = false;
            this.eFrom.LargeChange = 2;
            this.eFrom.Location = new System.Drawing.Point(28, 223);
            this.eFrom.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.eFrom.Maximum = 12;
            this.eFrom.Name = "eFrom";
            this.eFrom.Size = new System.Drawing.Size(431, 55);
            this.eFrom.TabIndex = 6;
            this.eFrom.Value = 6;
            this.eFrom.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // eTo
            // 
            this.eTo.AutoSize = false;
            this.eTo.LargeChange = 2;
            this.eTo.Location = new System.Drawing.Point(28, 495);
            this.eTo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.eTo.Maximum = 12;
            this.eTo.Name = "eTo";
            this.eTo.Size = new System.Drawing.Size(431, 59);
            this.eTo.TabIndex = 7;
            this.eTo.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.eTo.Value = 6;
            this.eTo.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(194, 199);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "FROM";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(213, 559);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "TO";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cornsilk;
            this.panel1.Location = new System.Drawing.Point(28, 281);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(51, 203);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Cornsilk;
            this.panel2.Location = new System.Drawing.Point(83, 281);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(51, 203);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Cornsilk;
            this.panel3.Location = new System.Drawing.Point(138, 281);
            this.panel3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(51, 203);
            this.panel3.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Cornsilk;
            this.panel4.Location = new System.Drawing.Point(193, 281);
            this.panel4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(51, 203);
            this.panel4.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Cornsilk;
            this.panel5.Location = new System.Drawing.Point(248, 281);
            this.panel5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(57, 203);
            this.panel5.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Cornsilk;
            this.panel6.Location = new System.Drawing.Point(308, 281);
            this.panel6.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(53, 203);
            this.panel6.TabIndex = 8;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Cornsilk;
            this.panel7.Location = new System.Drawing.Point(365, 281);
            this.panel7.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(51, 203);
            this.panel7.TabIndex = 8;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Cornsilk;
            this.panel8.Location = new System.Drawing.Point(420, 281);
            this.panel8.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(51, 203);
            this.panel8.TabIndex = 8;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel9.Location = new System.Drawing.Point(66, 281);
            this.panel9.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(29, 135);
            this.panel9.TabIndex = 8;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel10.Location = new System.Drawing.Point(127, 281);
            this.panel10.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(29, 135);
            this.panel10.TabIndex = 8;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel11.Location = new System.Drawing.Point(231, 281);
            this.panel11.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(29, 135);
            this.panel11.TabIndex = 8;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel12.Location = new System.Drawing.Point(290, 281);
            this.panel12.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(29, 135);
            this.panel12.TabIndex = 8;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel13.Location = new System.Drawing.Point(352, 281);
            this.panel13.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(29, 135);
            this.panel13.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Yellow;
            this.label9.Location = new System.Drawing.Point(433, 698);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 25);
            this.label9.TabIndex = 10;
            this.label9.Text = "v 3.0";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eBig
            // 
            this.eBig.BackColor = System.Drawing.Color.Black;
            this.eBig.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eBig.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.eBig.Location = new System.Drawing.Point(7, 6);
            this.eBig.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.eBig.Name = "eBig";
            this.eBig.Size = new System.Drawing.Size(482, 186);
            this.eBig.TabIndex = 12;
            this.eBig.Text = "0";
            this.eBig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MidiNoteMapperUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.Controls.Add(this.eBig);
            this.Controls.Add(this.cAddOctave);
            this.Controls.Add(this.cDropOctave);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cUpDown);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.eTo);
            this.Controls.Add(this.eFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eSemitones);
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MidiNoteMapperUI";
            this.Size = new System.Drawing.Size(495, 742);
            this.Load += new System.EventHandler(this.MidiNoteMapperUI_Load);
            this.VisibleChanged += new System.EventHandler(this.MidiNoteMapperUI_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.eSemitones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown eSemitones;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar eFrom;
        private System.Windows.Forms.TrackBar eTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button cUpDown;
        private System.Windows.Forms.Button cDropOctave;
        private System.Windows.Forms.Button cAddOctave;
        private System.Windows.Forms.Label label9;
        private Label eBig;
    }
}
