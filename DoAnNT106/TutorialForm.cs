﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
    public partial class TutorialForm : Form
    {
        public TutorialForm()
        {
            InitializeComponent();
        }

        private void MainMenuBack_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
