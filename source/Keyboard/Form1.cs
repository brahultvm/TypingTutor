using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Keyboard
{
    public class Form1 : Form
    {
        private int index;

        private int start;

        private string nextChar = string.Empty;

        private int errorCount;

        private StringBuilder currentLesson = new StringBuilder();

        private Common common = new Common();

        private string initialData = string.Empty;

        private IContainer components;

        private RichTextBox rtb1;

        private Label lblKey;

        private PictureBox pictureBox1;

        private Timer timer1;

        private ToolTip toolTip1;

        private ListBox lstAction;

        private Label left1;

        private Label left2;

        private Label left3;

        private Label left4;

        private Label right4;

        private Label right3;

        private Label right2;

        private Label right1;

        private Label space;

        private Label lblWPM;
        private Label lblCPM;
        private Timer timer2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tamilToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
        private ToolStripMenuItem fontToolStripMenuItem;
        private CheckBox chkSound;

        public Form1()
        {
            InitializeComponent();
        }
        LogWriter logWriter = new LogWriter("test");
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                logWriter.LogWrite(keyData.ToString());
                switch (keyData)
                {
                    case Keys.G | Keys.Alt:
                        GotoLesson();
                        return true;
                    case Keys.C | Keys.Alt:
                        Close();
                        return true;
                    case Keys.Back:
                    case Keys.Left:
                    case Keys.Right:
                    case Keys.Delete:
                    case Keys.Shift | Keys.ShiftKey:
                    case Keys.Control | Keys.ControlKey:
                        return true;
                    default:
                        if (common.lstData.Count <= index)
                        {
                            index = 0;
                        }
                        switch (keyData)
                        {
                            case Keys.Up:
                                ChangeLesson(1);
                                return true;
                            case Keys.Down:
                                ChangeLesson(-1);
                                return true;
                            case Keys.Escape:
                                ChangeLesson(0);
                                return true;
                            default:
                                if (currentLesson.Length == 0)
                                {
                                    start = 0;
                                }
                                if (msg.Msg == 256)
                                {
                                    switch (keyData)
                                    {
                                        case Keys.OemSemicolon:
                                            currentLesson.Append(";");
                                            break;
                                        case Keys.Space:
                                            currentLesson.Append(" ");
                                            break;
                                        default:
                                            currentLesson.Append(keyData.ToString().Substring(0, 1));
                                            break;
                                    }
                                }
                                try
                                {
                                    if (rtb1.TextLength > start && currentLesson.Length > 0)
                                    {
                                        if (nextChar == "space")
                                        {
                                            nextChar = " ";
                                        }
                                        if (nextChar.ToUpper() == currentLesson.ToString().Substring(currentLesson.Length - 1))
                                        {
                                            rtb1.SelectionStart = start;
                                            rtb1.SelectionLength = 1;
                                            rtb1.SelectionColor = Color.Green;
                                            Common.Play();
                                        }
                                        else
                                        {
                                            rtb1.SelectionStart = start;
                                            rtb1.SelectionLength = 1;
                                            rtb1.SelectionColor = Color.Red;
                                            Common.Error();
                                            errorCount++;
                                        }
                                        start++;
                                        rtb1.SelectionStart = start;
                                        rtb1.SelectionLength = 1;
                                        rtb1.SelectionColor = Color.Blue;
                                        if (rtb1.TextLength > start)
                                        {
                                            nextChar = rtb1.Text.Substring(start, 1);
                                            Label label = left1;
                                            Label label2 = left2;
                                            Label label3 = left3;
                                            Label label4 = left4;
                                            Label label5 = right1;
                                            Label label6 = right2;
                                            Label label7 = right3;
                                            Label label8 = right4;
                                            bool flag2 = (space.Visible = false);
                                            bool flag4 = (label8.Visible = flag2);
                                            bool flag6 = (label7.Visible = flag4);
                                            bool flag8 = (label6.Visible = flag6);
                                            bool flag10 = (label5.Visible = flag8);
                                            bool flag12 = (label4.Visible = flag10);
                                            bool flag14 = (label3.Visible = flag12);
                                            bool visible = (label2.Visible = flag14);
                                            label.Visible = visible;
                                        }
                                        else if (currentLesson.Length <= start)
                                        {
                                            currentLesson.Clear();
                                            Common.Completed();
                                            timer1.Enabled = false;
                                            Label label9 = left1;
                                            Label label10 = left2;
                                            Label label11 = left3;
                                            Label label12 = left4;
                                            Label label13 = right1;
                                            Label label14 = right2;
                                            Label label15 = right3;
                                            Label label16 = right4;
                                            bool flag2 = (space.Visible = false);
                                            bool flag4 = (label16.Visible = flag2);
                                            bool flag6 = (label15.Visible = flag4);
                                            bool flag8 = (label14.Visible = flag6);
                                            bool flag10 = (label13.Visible = flag8);
                                            bool flag12 = (label12.Visible = flag10);
                                            bool flag14 = (label11.Visible = flag12);
                                            bool visible = (label10.Visible = flag14);
                                            label9.Visible = visible;
                                            DialogResult dialogResult = MessageBox.Show($"Successfully completed the Lesson :" +
                                                $"{index}\n\n\nTotal Errors on Chars :{errorCount}\n\n\nTotal Chars   :" +
                                                $"{start}", "Typing Tutor", MessageBoxButtons.YesNoCancel);
                                            timer1.Enabled = true;
                                            if (dialogResult == DialogResult.Yes)
                                            {
                                                ChangeLesson(1);
                                            }
                                            else
                                            {
                                                ChangeLesson(0);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ChangeLesson(1);
                                    }
                                    if (nextChar == " ")
                                    {
                                        nextChar = "space";
                                    }
                                    lblKey.Text = nextChar;
                                    if (nextChar == "space")
                                    {
                                        lblKey.BackColor = Common.GetColorForKey(' ');
                                    }
                                    else
                                    {
                                        lblKey.BackColor = Common.GetColorForKey(nextChar[0]);
                                    }
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                break;
                        }
                        break;
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            rtb1.ScrollToCaret();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ChangeLesson(int increment)
        {
            if ((index != 0 || increment != -1) && (index != common.lstData.Count || increment != 1))
            {
                if (index > 173)
                {
                    index = 0;
                }
                index += increment;
                rtb1.Text = common.lstData[index];
                if (rtb1.TextLength > 0)
                {
                    currentLesson.Clear();
                    start = 0;
                    errorCount = 0;
                    nextChar = rtb1.Text.Substring(start, 1);
                }
                lblKey.Text = nextChar;
                lblKey.BackColor = Common.GetColorForKey(nextChar[0]);
                rtb1.SelectAll();
                rtb1.SelectionColor = Color.Blue;
                rtb1.SelectionStart = start;
                rtb1.SelectionLength = 1;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //pictureBox1.Image = Keyboard.Resource1._3;
            setLang(true);
            base.Icon = Keyboard.Resource1.key;
            lblKey.Text = "put your fingers in the base positions: F J";
            common.LoadBasicRow();
            rtb1.Text = common.lstData[index];
            nextChar = rtb1.Text.Substring(start, 1);
            rtb1.SelectionStart = start;
            rtb1.SelectionLength = 1;
            lblKey.Text = nextChar;
            lblKey.BackColor = Common.GetColorForKey(nextChar[0]);
            Label label = left1;
            Label label2 = left2;
            Label label3 = left3;
            Label label4 = left4;
            Label label5 = right1;
            Label label6 = right2;
            Label label7 = right3;
            Label label8 = right4;
            bool flag2 = (space.Visible = false);
            bool flag4 = (label8.Visible = flag2);
            bool flag6 = (label7.Visible = flag4);
            bool flag8 = (label6.Visible = flag6);
            bool flag10 = (label5.Visible = flag8);
            bool flag12 = (label4.Visible = flag10);
            bool flag14 = (label3.Visible = flag12);
            bool visible = (label2.Visible = flag14);
            label.Visible = visible;
        }

        public void GetColorForKey(char key)
        {
            Label label = null;
            switch (key)
            {
                case ' ':
                    label = space;
                    break;
                case '1':
                case 'a':
                case 'A':
                case 'q':
                case 'Q':
                case 'z':
                case 'Z':
                    left1.BackColor = Color.Red;
                    left1.Text = nextChar;
                    lblKey.Text = $"left little finger ' {key} '";
                    label = left1;
                    break;
                case '2':
                case '@':
                case 's':
                case 'S':
                case 'w':
                case 'W':
                case 'x':
                case 'X':
                    left2.BackColor = Color.Orange;
                    left2.Text = key.ToString();
                    label = left2;
                    lblKey.Text = $"left ring finger {key}";
                    break;
                case '3':
                case '#':
                case 'c':
                case 'C':
                case 'd':
                case 'D':
                case 'e':
                case 'E':
                    left3.BackColor = Color.Green;
                    left3.Text = key.ToString();
                    lblKey.Text = $"left middle finger ' {key} '";
                    label = left3;
                    break;
                case '4':
                case '$':
                case '5':
                case '%':
                case 'b':
                case 'B':
                case 'f':
                case 'F':
                case 'g':
                case 'G':
                case 'r':
                case 'R':
                case 't':
                case 'T':
                case 'v':
                case 'V':
                    left4.BackColor = Color.SkyBlue;
                    left4.Text = key.ToString();
                    label = left4;
                    lblKey.Text = $"left index finger ' {key} '";
                    break;
                case '6':
                case '^':
                case '7':
                case '&':
                case 'h':
                case 'H':
                case 'j':
                case 'J':
                case 'm':
                case 'M':
                case 'n':
                case 'N':
                case 'u':
                case 'U':
                case 'y':
                case 'Y':
                    right4.BackColor = Color.LightSteelBlue;
                    right4.Text = key.ToString();
                    label = right4;
                    lblKey.Text = $"right index finger ' {key} '";
                    break;
                case '8':
                case '*':
                case '<':
                case 'i':
                case 'I':
                case 'k':
                case 'K':
                    right3.BackColor = Color.DeepSkyBlue;
                    right3.Text = key.ToString();
                    label = right3;
                    lblKey.Text = $"right middle finger ' {key} '";
                    break;
                case '.':
                case '>':
                case '9':
                case '(':
                case 'l':
                case ':':
                case 'o':
                case 'O':
                    right2.BackColor = Color.LightYellow;
                    right2.Text = key.ToString();
                    label = right2;
                    lblKey.Text = $"right ring finger ' {key} '";
                    break;
                case '-':
                case '/':
                case '0':
                case ';':
                case '=':
                case '[':
                case '\\':
                case ']':
                case 'p':
                case 'P':
                    right1.BackColor = Color.LightGreen;
                    right1.Text = key.ToString();
                    label = right1;
                    lblKey.Text = $"right little finger ' {key} '";
                    break;
            }
            if (label != null)
                label.Visible = !label.Visible;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (nextChar == "space")
            {
                lblKey.Text = "Left thumb";
                GetColorForKey(' ');
            }
            else
            {
                GetColorForKey(nextChar[0]);
            }

        }
        int sec = 1;
        void CalculateCPM()
        {

            sec++;

            int num = rtb1.SelectionStart;

            if (num > 0)
            {

                float result = (num / 5);

                lblCPM.Text = $"WPM :{Math.Round(result * 100) / 100} ";
            }

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Typing tutor developed by Balamurugan Sakthivel,\n\n Contact: sbalamuruganmca@yahoo.com ,(9789926650)");
        }

        private void GotoLesson()
        {
            string input = $"Enter the Lesson Number (1-{common.lstData.Count})";
            ShowInputDialog(ref input);
            try
            {
                int num = Convert.ToInt32(input) - 1;
                if (num < common.lstData.Count)
                {
                    index = num;
                    rtb1.Text = common.lstData[index];
                    nextChar = rtb1.Text.Substring(start, 1);
                }
            }
            catch
            {
                index = 1;
            }
        }

        private void LstAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAction.SelectedIndex == 0)
            {
                GotoLesson();
            }
            else
            {
                Close();
            }
        }

        private static DialogResult ShowInputDialog(ref string input)
        {
            Size clientSize = new Size(200, 70);
            DialogResult dialogResult = DialogResult.None;
            using Form form = new Form();
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.ClientSize = clientSize;
            form.Text = "Typing Tutor Lesson Goto ";
            TextBox textBox = new TextBox();
            textBox.Size = new Size(clientSize.Width - 10, 23);
            textBox.Location = new Point(5, 5);
            textBox.Text = input;
            form.Controls.Add(textBox);
            Button button = new Button();
            button.DialogResult = DialogResult.OK;
            button.Name = "okButton";
            button.Size = new Size(75, 23);
            button.Text = "&OK";
            button.Location = new Point(clientSize.Width - 80 - 80, 39);
            form.Controls.Add(button);
            Button button2 = new Button();
            button2.DialogResult = DialogResult.Cancel;
            button2.Name = "cancelButton";
            button2.Size = new Size(75, 23);
            button2.Text = "&Cancel";
            button2.Location = new Point(clientSize.Width - 80, 39);
            form.Controls.Add(button2);
            form.AcceptButton = button;
            form.CancelButton = button2;
            dialogResult = form.ShowDialog();
            input = textBox.Text;
            return dialogResult;
        }

        private void ChkSound_CheckedChanged(object sender, EventArgs e)
        {
            Common.sound = chkSound.Checked;
            if (chkSound.Checked)
            {
                chkSound.Image = Resource1.sound;
            }
            else
            {
                chkSound.Image = Resource1.soundStop;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblWPM = new System.Windows.Forms.Label();
            this.lstAction = new System.Windows.Forms.ListBox();
            this.left1 = new System.Windows.Forms.Label();
            this.left2 = new System.Windows.Forms.Label();
            this.left3 = new System.Windows.Forms.Label();
            this.left4 = new System.Windows.Forms.Label();
            this.right4 = new System.Windows.Forms.Label();
            this.right3 = new System.Windows.Forms.Label();
            this.right2 = new System.Windows.Forms.Label();
            this.right1 = new System.Windows.Forms.Label();
            this.space = new System.Windows.Forms.Label();
            this.chkSound = new System.Windows.Forms.CheckBox();
            this.lblCPM = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tamilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtb1
            // 
            this.rtb1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rtb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rtb1.DetectUrls = false;
            this.rtb1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb1.ForeColor = System.Drawing.Color.Blue;
            this.rtb1.HideSelection = false;
            this.rtb1.Location = new System.Drawing.Point(25, 24);
            this.rtb1.Margin = new System.Windows.Forms.Padding(4);
            this.rtb1.MaxLength = 1024;
            this.rtb1.Multiline = false;
            this.rtb1.Name = "rtb1";
            this.rtb1.ReadOnly = true;
            this.rtb1.RightMargin = 5;
            this.rtb1.ShowSelectionMargin = true;
            this.rtb1.Size = new System.Drawing.Size(1201, 73);
            this.rtb1.TabIndex = 0;
            this.rtb1.Text = "";
            // 
            // lblKey
            // 
            this.lblKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblKey.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey.ForeColor = System.Drawing.Color.Black;
            this.lblKey.Location = new System.Drawing.Point(194, 112);
            this.lblKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(716, 42);
            this.lblKey.TabIndex = 4;
            this.lblKey.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.lblKey, "Enter the key ");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 165);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1201, 481);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "keyboard");
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // lblWPM
            // 
            this.lblWPM.AutoSize = true;
            this.lblWPM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWPM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblWPM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWPM.Font = new System.Drawing.Font("Courier New", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWPM.ForeColor = System.Drawing.Color.Black;
            this.lblWPM.Location = new System.Drawing.Point(52, 101);
            this.lblWPM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWPM.Name = "lblWPM";
            this.lblWPM.Size = new System.Drawing.Size(2, 75);
            this.lblWPM.TabIndex = 16;
            this.toolTip1.SetToolTip(this.lblWPM, "Enter the key ");
            // 
            // lstAction
            // 
            this.lstAction.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lstAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAction.ForeColor = System.Drawing.Color.Yellow;
            this.lstAction.FormattingEnabled = true;
            this.lstAction.ItemHeight = 29;
            this.lstAction.Items.AddRange(new object[] {
            "GO",
            "CLOSE"});
            this.lstAction.Location = new System.Drawing.Point(1039, 97);
            this.lstAction.Name = "lstAction";
            this.lstAction.Size = new System.Drawing.Size(146, 60);
            this.lstAction.TabIndex = 6;
            this.lstAction.SelectedIndexChanged += new System.EventHandler(this.LstAction_SelectedIndexChanged);
            // 
            // left1
            // 
            this.left1.BackColor = System.Drawing.Color.Red;
            this.left1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.left1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.left1.Location = new System.Drawing.Point(267, 513);
            this.left1.Name = "left1";
            this.left1.Size = new System.Drawing.Size(46, 66);
            this.left1.TabIndex = 7;
            this.left1.Text = "a";
            this.left1.Visible = false;
            // 
            // left2
            // 
            this.left2.BackColor = System.Drawing.Color.Red;
            this.left2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.left2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.left2.Location = new System.Drawing.Point(340, 492);
            this.left2.Name = "left2";
            this.left2.Size = new System.Drawing.Size(46, 81);
            this.left2.TabIndex = 8;
            this.left2.Text = "a";
            this.left2.Visible = false;
            // 
            // left3
            // 
            this.left3.BackColor = System.Drawing.Color.Red;
            this.left3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.left3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.left3.Location = new System.Drawing.Point(402, 472);
            this.left3.Name = "left3";
            this.left3.Size = new System.Drawing.Size(46, 76);
            this.left3.TabIndex = 9;
            this.left3.Text = "a";
            this.left3.Visible = false;
            // 
            // left4
            // 
            this.left4.BackColor = System.Drawing.Color.Red;
            this.left4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.left4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.left4.Location = new System.Drawing.Point(454, 504);
            this.left4.Name = "left4";
            this.left4.Size = new System.Drawing.Size(46, 69);
            this.left4.TabIndex = 10;
            this.left4.Text = "a";
            this.left4.Visible = false;
            // 
            // right4
            // 
            this.right4.BackColor = System.Drawing.Color.Red;
            this.right4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.right4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.right4.Location = new System.Drawing.Point(762, 467);
            this.right4.Name = "right4";
            this.right4.Size = new System.Drawing.Size(46, 81);
            this.right4.TabIndex = 11;
            this.right4.Text = "a";
            this.right4.Visible = false;
            // 
            // right3
            // 
            this.right3.BackColor = System.Drawing.Color.Red;
            this.right3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.right3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.right3.Location = new System.Drawing.Point(823, 467);
            this.right3.Name = "right3";
            this.right3.Size = new System.Drawing.Size(46, 81);
            this.right3.TabIndex = 12;
            this.right3.Text = "a";
            this.right3.Visible = false;
            // 
            // right2
            // 
            this.right2.BackColor = System.Drawing.Color.Red;
            this.right2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.right2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.right2.Location = new System.Drawing.Point(887, 492);
            this.right2.Name = "right2";
            this.right2.Size = new System.Drawing.Size(46, 81);
            this.right2.TabIndex = 13;
            this.right2.Text = "a";
            this.right2.Visible = false;
            // 
            // right1
            // 
            this.right1.BackColor = System.Drawing.Color.Red;
            this.right1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.right1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.right1.Location = new System.Drawing.Point(958, 496);
            this.right1.Name = "right1";
            this.right1.Size = new System.Drawing.Size(46, 89);
            this.right1.TabIndex = 14;
            this.right1.Text = "a";
            this.right1.Visible = false;
            // 
            // space
            // 
            this.space.BackColor = System.Drawing.Color.LightSteelBlue;
            this.space.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.space.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.space.Location = new System.Drawing.Point(679, 541);
            this.space.Name = "space";
            this.space.Size = new System.Drawing.Size(49, 60);
            this.space.TabIndex = 15;
            this.space.Visible = false;
            // 
            // chkSound
            // 
            this.chkSound.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSound.AutoSize = true;
            this.chkSound.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkSound.Checked = true;
            this.chkSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSound.ForeColor = System.Drawing.Color.Maroon;
            this.chkSound.Image = ((System.Drawing.Image)(resources.GetObject("chkSound.Image")));
            this.chkSound.Location = new System.Drawing.Point(25, 101);
            this.chkSound.Name = "chkSound";
            this.chkSound.Size = new System.Drawing.Size(81, 49);
            this.chkSound.TabIndex = 17;
            this.chkSound.UseVisualStyleBackColor = true;
            this.chkSound.CheckedChanged += new System.EventHandler(this.ChkSound_CheckedChanged);
            // 
            // lblCPM
            // 
            this.lblCPM.AutoSize = true;
            this.lblCPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPM.Location = new System.Drawing.Point(36, 153);
            this.lblCPM.Name = "lblCPM";
            this.lblCPM.Size = new System.Drawing.Size(0, 25);
            this.lblCPM.TabIndex = 18;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tamilToolStripMenuItem,
            this.englishToolStripMenuItem,
            this.fontToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1242, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tamilToolStripMenuItem
            // 
            this.tamilToolStripMenuItem.Name = "tamilToolStripMenuItem";
            this.tamilToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.tamilToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.tamilToolStripMenuItem.Text = "&Tamil";
            this.tamilToolStripMenuItem.Click += new System.EventHandler(this.tamilToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.englishToolStripMenuItem.Text = "&English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fontToolStripMenuItem.Text = "&Font";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1242, 749);
            this.ControlBox = false;
            this.Controls.Add(this.lblCPM);
            this.Controls.Add(this.chkSound);
            this.Controls.Add(this.lblWPM);
            this.Controls.Add(this.space);
            this.Controls.Add(this.right1);
            this.Controls.Add(this.right2);
            this.Controls.Add(this.right3);
            this.Controls.Add(this.right4);
            this.Controls.Add(this.left4);
            this.Controls.Add(this.left3);
            this.Controls.Add(this.left2);
            this.Controls.Add(this.left1);
            this.Controls.Add(this.lstAction);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.rtb1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Typing Tutor ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            CalculateCPM();
        }

        private void tamilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLang(false);
        }
        void setLang(bool isEng)
        {



            if (isEng)
            {
                common.LoadBasicRow();
                rtb1.Font = new Font("Courier New", 24, FontStyle.Bold);

                left1.Location = new Point(247, 513);
                left2.Location = new Point(300, 492);
                left3.Location = new Point(362, 472);
                left4.Location = new Point(394, 504);
                right4.Location = new Point(762, 467);
                right3.Location = new Point(823, 467);
                right2.Location = new Point(887, 492);
                right1.Location = new Point(958, 496);
                space.Location = new Point(679, 541);
                pictureBox1.Image = Keyboard.Resource1._3;
            }
            else
            {
                common.LoadTamilBasicRow();
                rtb1.Font = new Font("Scribe Tamil10", 24);
                left1.Location = new Point(267, 513);
                left2.Location = new Point(340, 492);
                left3.Location = new Point(402, 472);
                left4.Location = new Point(454, 504);
                right4.Location = new Point(825, 504);
                right3.Location = new Point(889, 513);
                right2.Location = new Point(952, 545);
                right1.Location = new Point(1017, 545);
                space.Location = new Point(739, 574);
                pictureBox1.Image = Resources.Properties.Resources.Tamilkeyboard1;
            }
            if (index > common.lstData.Count)
                index = 1;
            rtb1.Text = common.lstData[index];
            nextChar = rtb1.Text.Substring(start, 1);
            rtb1.SelectionStart = start;
            rtb1.SelectionLength = 1;
            lblKey.Text = nextChar;
            lblKey.BackColor = Common.GetColorForKey(nextChar[0]);
        }
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLang(true);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = rtb1.Font;
            if(fontDialog.ShowDialog()==DialogResult.OK)
            {
                rtb1.Font = fontDialog.Font;
            }

        }
    }
}
