﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dictionary_examen_Bukov
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Load_dictionary_button_Click(object sender, EventArgs e)
        {
            LoadForm loadForm = new LoadForm();
            loadForm.Show();
        }
    }
}
