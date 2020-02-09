using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class ControlPanel : Form
    {
        public ControlPanel()
        {
            InitializeComponent();
        }

        Kernel kernel;

        public void init(Kernel useKernel, String commands, String config)
        {
            kernel = useKernel;
            kernel.setControlPanel(this);

            kernel.init(commands, config);
        }

        public void paintPage(Page page)
        {
            virtualPageLabel.Text = page.id.ToString();
            physicalPageLabel.Text = page.physical.ToString();
            rLabel.Text = page.R.ToString();
            mLabel.Text = page.M.ToString();
            inMemTimeLabel.Text = page.inMemTime.ToString();
            lastTouchTimeLabel.Text = page.lastTouchTime.ToString();
            lowLabel.Text = Convert.ToString(page.low, Kernel.addressradix);
            highLabel.Text = Convert.ToString(page.high, Kernel.addressradix);
        }

        public void setStatus(String status)
        {
            statusLabel.Text = status;
        }

        public void addPhysicalPage(int pageNum, int physicalPage)
        {
            if (physicalPage == 0)
            {
                l0.Text = ("page " + pageNum);
            }
            else if (physicalPage == 1)
            {
                l1.Text = ("page " + pageNum);
            }
            else if (physicalPage == 2)
            {
                l2.Text = ("page " + pageNum);
            }
            else if (physicalPage == 3)
            {
                l3.Text = ("page " + pageNum);
            }
            else if (physicalPage == 4)
            {
                l4.Text = ("page " + pageNum);
            }
            else if (physicalPage == 5)
            {
                l5.Text = ("page " + pageNum);
            }
            else if (physicalPage == 6)
            {
                l6.Text = ("page " + pageNum);
            }
            else if (physicalPage == 7)
            {
                l7.Text = ("page " + pageNum);
            }
            else if (physicalPage == 8)
            {
                l8.Text = ("page " + pageNum);
            }
            else if (physicalPage == 9)
            {
                l9.Text = ("page " + pageNum);
            }
            else if (physicalPage == 10)
            {
                l10.Text = ("page " + pageNum);
            }
            else if (physicalPage == 11)
            {
                l11.Text = ("page " + pageNum);
            }
            else if (physicalPage == 12)
            {
                l12.Text = ("page " + pageNum);
            }
            else if (physicalPage == 13)
            {
                l13.Text = ("page " + pageNum);
            }
            else if (physicalPage == 14)
            {
                l14.Text = ("page " + pageNum);
            }
            else if (physicalPage == 15)
            {
                l14.Text = ("page " + pageNum);
            }
            else if (physicalPage == 16)
            {
                l16.Text = ("page " + pageNum);
            }
            else if (physicalPage == 17)
            {
                l17.Text = ("page " + pageNum);
            }
            else if (physicalPage == 18)
            {
                l18.Text = ("page " + pageNum);
            }
            else if (physicalPage == 19)
            {
                l19.Text = ("page " + pageNum);
            }
            else if (physicalPage == 20)
            {
                l20.Text = ("page " + pageNum);
            }
            else if (physicalPage == 21)
            {
                l21.Text = ("page " + pageNum);
            }
            else if (physicalPage == 22)
            {
                l22.Text = ("page " + pageNum);
            }
            else if (physicalPage == 23)
            {
                l23.Text = ("page " + pageNum);
            }
            else if (physicalPage == 24)
            {
                l24.Text = ("page " + pageNum);
            }
            else if (physicalPage == 25)
            {
                l25.Text = ("page " + pageNum);
            }
            else if (physicalPage == 26)
            {
                l26.Text = ("page " + pageNum);
            }
            else if (physicalPage == 27)
            {
                l27.Text = ("page " + pageNum);
            }
            else if (physicalPage == 28)
            {
                l28.Text = ("page " + pageNum);
            }
            else if (physicalPage == 29)
            {
                l29.Text = ("page " + pageNum);
            }
            else if (physicalPage == 30)
            {
                l30.Text = ("page " + pageNum);
            }
            else if (physicalPage == 31)
            {
                l31.Text = ("page " + pageNum);
            }
            else if (physicalPage == 32)
            {
                l32.Text = ("page " + pageNum);
            }
            else if (physicalPage == 33)
            {
                l33.Text = ("page " + pageNum);
            }
            else if (physicalPage == 34)
            {
                l34.Text = ("page " + pageNum);
            }
            else if (physicalPage == 35)
            {
                l35.Text = ("page " + pageNum);
            }
            else if (physicalPage == 36)
            {
                l36.Text = ("page " + pageNum);
            }
            else if (physicalPage == 37)
            {
                l37.Text = ("page " + pageNum);
            }
            else if (physicalPage == 38)
            {
                l38.Text = ("page " + pageNum);
            }
            else if (physicalPage == 39)
            {
                l39.Text = ("page " + pageNum);
            }
            else if (physicalPage == 40)
            {
                l40.Text = ("page " + pageNum);
            }
            else if (physicalPage == 41)
            {
                l41.Text = ("page " + pageNum);
            }
            else if (physicalPage == 42)
            {
                l42.Text = ("page " + pageNum);
            }
            else if (physicalPage == 43)
            {
                l43.Text = ("page " + pageNum);
            }
            else if (physicalPage == 44)
            {
                l44.Text = ("page " + pageNum);
            }
            else if (physicalPage == 45)
            {
                l45.Text = ("page " + pageNum);
            }
            else if (physicalPage == 46)
            {
                l46.Text = ("page " + pageNum);
            }
            else if (physicalPage == 47)
            {
                l47.Text = ("page " + pageNum);
            }
            else if (physicalPage == 48)
            {
                l48.Text = ("page " + pageNum);
            }
            else if (physicalPage == 49)
            {
                l49.Text = ("page " + pageNum);
            }
            else if (physicalPage == 50)
            {
                l50.Text = ("page " + pageNum);
            }
            else if (physicalPage == 51)
            {
                l51.Text = ("page " + pageNum);
            }
            else if (physicalPage == 52)
            {
                l52.Text = ("page " + pageNum);
            }
            else if (physicalPage == 53)
            {
                l53.Text = ("page " + pageNum);
            }
            else if (physicalPage == 54)
            {
                l54.Text = ("page " + pageNum);
            }
            else if (physicalPage == 55)
            {
                l55.Text = ("page " + pageNum);
            }
            else if (physicalPage == 56)
            {
                l56.Text = ("page " + pageNum);
            }
            else if (physicalPage == 57)
            {
                l57.Text = ("page " + pageNum);
            }
            else if (physicalPage == 58)
            {
                l58.Text = ("page " + pageNum);
            }
            else if (physicalPage == 59)
            {
                l59.Text = ("page " + pageNum);
            }
            else if (physicalPage == 60)
            {
                l60.Text = ("page " + pageNum);
            }
            else if (physicalPage == 61)
            {
                l61.Text = ("page " + pageNum);
            }
            else if (physicalPage == 62)
            {
                l62.Text = ("page " + pageNum);
            }
            else if (physicalPage == 63)
            {
                l63.Text = ("page " + pageNum);
            }
            else
            {
                return;
            }
        }

        public void removePhysicalPage(int physicalPage)
        {
            if (physicalPage == 0)
            {
                l0.Text = (null);
            }
            else if (physicalPage == 1)
            {
                l1.Text = (null);
            }
            else if (physicalPage == 2)
            {
                l2.Text = (null);
            }
            else if (physicalPage == 3)
            {
                l3.Text = (null);
            }
            else if (physicalPage == 4)
            {
                l4.Text = (null);
            }
            else if (physicalPage == 5)
            {
                l5.Text = (null);
            }
            else if (physicalPage == 6)
            {
                l6.Text = (null);
            }
            else if (physicalPage == 7)
            {
                l7.Text = (null);
            }
            else if (physicalPage == 8)
            {
                l8.Text = (null);
            }
            else if (physicalPage == 9)
            {
                l9.Text = (null);
            }
            else if (physicalPage == 10)
            {
                l10.Text = (null);
            }
            else if (physicalPage == 11)
            {
                l11.Text = (null);
            }
            else if (physicalPage == 12)
            {
                l12.Text = (null);
            }
            else if (physicalPage == 13)
            {
                l13.Text = (null);
            }
            else if (physicalPage == 14)
            {
                l14.Text = (null);
            }
            else if (physicalPage == 15)
            {
                l14.Text = (null);
            }
            else if (physicalPage == 16)
            {
                l16.Text = (null);
            }
            else if (physicalPage == 17)
            {
                l17.Text = (null);
            }
            else if (physicalPage == 18)
            {
                l18.Text = (null);
            }
            else if (physicalPage == 19)
            {
                l19.Text = (null);
            }
            else if (physicalPage == 20)
            {
                l20.Text = (null);
            }
            else if (physicalPage == 21)
            {
                l21.Text = (null);
            }
            else if (physicalPage == 22)
            {
                l22.Text = (null);
            }
            else if (physicalPage == 23)
            {
                l23.Text = (null);
            }
            else if (physicalPage == 24)
            {
                l24.Text = (null);
            }
            else if (physicalPage == 25)
            {
                l25.Text = (null);
            }
            else if (physicalPage == 26)
            {
                l26.Text = (null);
            }
            else if (physicalPage == 27)
            {
                l27.Text = (null);
            }
            else if (physicalPage == 28)
            {
                l28.Text = (null);
            }
            else if (physicalPage == 29)
            {
                l29.Text = (null);
            }
            else if (physicalPage == 30)
            {
                l30.Text = (null);
            }
            else if (physicalPage == 31)
            {
                l31.Text = (null);
            }
            else if (physicalPage == 32)
            {
                l32.Text = (null);
            }
            else if (physicalPage == 33)
            {
                l33.Text = (null);
            }
            else if (physicalPage == 34)
            {
                l34.Text = (null);
            }
            else if (physicalPage == 35)
            {
                l35.Text = (null);
            }
            else if (physicalPage == 36)
            {
                l36.Text = (null);
            }
            else if (physicalPage == 37)
            {
                l37.Text = (null);
            }
            else if (physicalPage == 38)
            {
                l38.Text = (null);
            }
            else if (physicalPage == 39)
            {
                l39.Text = (null);
            }
            else if (physicalPage == 40)
            {
                l40.Text = (null);
            }
            else if (physicalPage == 41)
            {
                l41.Text = (null);
            }
            else if (physicalPage == 42)
            {
                l42.Text = (null);
            }
            else if (physicalPage == 43)
            {
                l43.Text = (null);
            }
            else if (physicalPage == 44)
            {
                l44.Text = (null);
            }
            else if (physicalPage == 45)
            {
                l45.Text = (null);
            }
            else if (physicalPage == 46)
            {
                l46.Text = (null);
            }
            else if (physicalPage == 47)
            {
                l47.Text = (null);
            }
            else if (physicalPage == 48)
            {
                l48.Text = (null);
            }
            else if (physicalPage == 49)
            {
                l49.Text = (null);
            }
            else if (physicalPage == 50)
            {
                l50.Text = (null);
            }
            else if (physicalPage == 51)
            {
                l51.Text = (null);
            }
            else if (physicalPage == 52)
            {
                l52.Text = (null);
            }
            else if (physicalPage == 53)
            {
                l53.Text = (null);
            }
            else if (physicalPage == 54)
            {
                l54.Text = (null);
            }
            else if (physicalPage == 55)
            {
                l55.Text = (null);
            }
            else if (physicalPage == 56)
            {
                l56.Text = (null);
            }
            else if (physicalPage == 57)
            {
                l57.Text = (null);
            }
            else if (physicalPage == 58)
            {
                l58.Text = (null);
            }
            else if (physicalPage == 59)
            {
                l59.Text = (null);
            }
            else if (physicalPage == 60)
            {
                l60.Text = (null);
            }
            else if (physicalPage == 61)
            {
                l61.Text = (null);
            }
            else if (physicalPage == 62)
            {
                l62.Text = (null);
            }
            else if (physicalPage == 63)
            {
                l63.Text = (null);
            }
            else
            {
                return;
            }
        }

        public async void action(object sender, EventArgs arg)
        {
            var e = sender as Button;

            if (e == null)
                return;

            if (e == runButton)
            {
                setStatus("RUN");
                runButton.Enabled = false;
                stepButton.Enabled = false;
                resetButton.Enabled = false;

                timer1.Interval = 1000;
                timer1.Enabled = true;
                timer1.Start();

                setStatus("STOP");
                resetButton.Enabled = true;
                return;
            }
            else if (e == stepButton)
            {
                setStatus("STEP");
                kernel.step();
                if (kernel.runcycles == kernel.runs)
                {
                    stepButton.Enabled = false;
                    runButton.Enabled = false;
                }
                setStatus("STOP");
                return;
            }
            else if (e == resetButton)
            {
                kernel.reset();
                runButton.Enabled = true;
                stepButton.Enabled = true;
                return;
            }
            else if (e == exitButton)
            {
                this.Close();
                return;
            }
            else if (e == b0)
            {
                kernel.getPage(0);
                return;
            }
            else if (e == b1)
            {
                kernel.getPage(1);
                return;
            }
            else if (e == b2)
            {
                kernel.getPage(2);
                return;
            }
            else if (e == b3)
            {
                kernel.getPage(3);
                return;
            }
            else if (e == b4)
            {
                kernel.getPage(4);
                return;
            }
            else if (e == b5)
            {
                kernel.getPage(5);
                return;
            }
            else if (e == b6)
            {
                kernel.getPage(6);
                return;
            }
            else if (e == b7)
            {
                kernel.getPage(7);
                return;
            }
            else if (e == b8)
            {
                kernel.getPage(8);
                return;
            }
            else if (e == b9)
            {
                kernel.getPage(9);
                return;
            }
            else if (e == b10)
            {
                kernel.getPage(10);
                return;
            }
            else if (e == b11)
            {
                kernel.getPage(11);
                return;
            }
            else if (e == b12)
            {
                kernel.getPage(12);
                return;
            }
            else if (e == b13)
            {
                kernel.getPage(13);
                return;
            }
            else if (e == b14)
            {
                kernel.getPage(14);
                return;
            }
            else if (e == b15)
            {
                kernel.getPage(15);
                return;
            }
            else if (e == b16)
            {
                kernel.getPage(16);
                return;
            }
            else if (e == b17)
            {
                kernel.getPage(17);
                return;
            }
            else if (e == b18)
            {
                kernel.getPage(18);
                return;
            }
            else if (e == b19)
            {
                kernel.getPage(19);
                return;
            }
            else if (e == b20)
            {
                kernel.getPage(20);
                return;
            }
            else if (e == b21)
            {
                kernel.getPage(21);
                return;
            }
            else if (e == b22)
            {
                kernel.getPage(22);
                return;
            }
            else if (e == b23)
            {
                kernel.getPage(23);
                return;
            }
            else if (e == b24)
            {
                kernel.getPage(24);
                return;
            }
            else if (e == b25)
            {
                kernel.getPage(25);
                return;
            }
            else if (e == b26)
            {
                kernel.getPage(26);
                return;
            }
            else if (e == b27)
            {
                kernel.getPage(27);
                return;
            }
            else if (e == b28)
            {
                kernel.getPage(28);
                return;
            }
            else if (e == b29)
            {
                kernel.getPage(29);
                return;
            }
            else if (e == b30)
            {
                kernel.getPage(30);
                return;
            }
            else if (e == b31)
            {
                kernel.getPage(31);
                return;
            }
            else if (e == b32)
            {
                kernel.getPage(32);
                return;
            }
            else if (e == b33)
            {
                kernel.getPage(33);
                return;
            }
            else if (e == b34)
            {
                kernel.getPage(34);
                return;
            }
            else if (e == b35)
            {
                kernel.getPage(35);
                return;
            }
            else if (e == b36)
            {
                kernel.getPage(36);
                return;
            }
            else if (e == b37)
            {
                kernel.getPage(37);
                return;
            }
            else if (e == b38)
            {
                kernel.getPage(38);
                return;
            }
            else if (e == b39)
            {
                kernel.getPage(39);
                return;
            }
            else if (e == b40)
            {
                kernel.getPage(40);
                return;
            }
            else if (e == b41)
            {
                kernel.getPage(41);
                return;
            }
            else if (e == b42)
            {
                kernel.getPage(42);
                return;
            }
            else if (e == b43)
            {
                kernel.getPage(43);
                return;
            }
            else if (e == b44)
            {
                kernel.getPage(44);
                return;
            }
            else if (e == b45)
            {
                kernel.getPage(45);
                return;
            }
            else if (e == b46)
            {
                kernel.getPage(46);
                return;
            }
            else if (e == b47)
            {
                kernel.getPage(47);
                return;
            }
            else if (e == b48)
            {
                kernel.getPage(48);
                return;
            }
            else if (e == b49)
            {
                kernel.getPage(49);
                return;
            }
            else if (e == b50)
            {
                kernel.getPage(50);
                return;
            }
            else if (e == b51)
            {
                kernel.getPage(51);
                return;
            }
            else if (e == b52)
            {
                kernel.getPage(52);
                return;
            }
            else if (e == b53)
            {
                kernel.getPage(53);
                return;
            }
            else if (e == b54)
            {
                kernel.getPage(54);
                return;
            }
            else if (e == b55)
            {
                kernel.getPage(55);
                return;
            }
            else if (e == b56)
            {
                kernel.getPage(56);
                return;
            }
            else if (e == b57)
            {
                kernel.getPage(57);
                return;
            }
            else if (e == b58)
            {
                kernel.getPage(58);
                return;
            }
            else if (e == b59)
            {
                kernel.getPage(59);
                return;
            }
            else if (e == b60)
            {
                kernel.getPage(60);
                return;
            }
            else if (e == b61)
            {
                kernel.getPage(61);
                return;
            }
            else if (e == b62)
            {
                kernel.getPage(62);
                return;
            }
            else if (e == b63)
            {
                kernel.getPage(63);
                return;
            }
            else
            {
                return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (kernel.runs < kernel.runcycles)
                kernel.step();
            else
                timer1.Enabled = false;
        }
    }
}
