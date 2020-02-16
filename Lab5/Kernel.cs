using Lab5;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab5
{
    public class Kernel
    {
        // The number of virtual pages must be fixed at 63 due to
        // dependencies in the GUI
        private static int virtPageNum = 63;

        private String output = null;
        private static readonly String lineSeparator = "\n";
        private String command_file;
        private String config_file;
        private ControlPanel controlPanel;
        private List<Page> memVector = new List<Page>();
        private List<Instruction> instructVector = new List<Instruction>();
        private String status;
        private bool doStdoutLog = false;
        private bool doFileLog = false;
        public int runs;
        public int runcycles;
        public long block = (int)Math.Pow(2, 12);
        public static byte addressradix = 10;

        public void init(String commands, String config)
        {
            FileStream f/* = new FileStream(commands, FileMode.OpenOrCreate)*/;
            command_file = commands;
            config_file = config;
            String line;
            String tmp = null;
            String command = "";
            byte R = 0;
            byte M = 0;
            int i = 0;
            int j = 0;
            int id = 0;
            int physical = 0;
            int physical_count = 0;
            int inMemTime = 0;
            int lastTouchTime = 0;
            int map_count = 0;
            double power = 14;
            long high = 0;
            long low = 0;
            long addr = 0;
            long address_limit = (block * virtPageNum + 1) - 1;

            if (config != null)
            {
                f = new FileStream(config, FileMode.OpenOrCreate);
                try
                {
                    StreamReader reader = new StreamReader(f);
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("numpages"))
                        {
                            var st = line.Split(' ');
                            for (int k = 0; k < st.Length; k++)
                            {
                                k++;
                                virtPageNum = Common.S2i(st[k]) - 1;
                                if (virtPageNum < 2 || virtPageNum > 63)
                                {
                                    Console.WriteLine("MemoryManagement: numpages out of bounds.");
                                    return;
                                }
                                address_limit = (block * virtPageNum + 1) - 1;
                            }
                        }
                    }
                    reader.Close();
                }
                catch (IOException e) { /* Handle exceptions */ }
                for (i = 0; i <= virtPageNum; i++)
                {
                    high = (block * (i + 1)) - 1;
                    low = block * i;
                    memVector.Add(new Page(i, -1, R, M, 0, 0, high, low));
                }
                try
                {
                    f = new FileStream(config, FileMode.OpenOrCreate);
                    StreamReader reader = new StreamReader(f);
                    while ((line = reader.ReadLine()) != null)

                    {
                        if (line.StartsWith("memset"))
                        {
                            var st = line.Split(' ');
                            for (int k = 1; k < st.Length; k++)
                            {
                                id = Common.S2i(st[k]);
                                tmp = st[++k];
                                if (tmp.StartsWith("x"))
                                {
                                    physical = -1;
                                }
                                else
                                {
                                    physical = Common.S2i(tmp);
                                }
                                if ((0 > id || id > virtPageNum) || (-1 > physical || physical > ((virtPageNum - 1) / 2)))
                                {
                                    Console.WriteLine("MemoryManagement: Invalid page value in " + config);
                                    return;
                                }
                                R = Common.S2b(st[++k]);
                                if (R < 0 || R > 1)
                                {
                                    Console.WriteLine("MemoryManagement: Invalid R value in " + config);
                                    return;
                                }
                                M = Common.S2b(st[++k]);
                                if (M < 0 || M > 1)
                                {
                                    Console.WriteLine("MemoryManagement: Invalid M value in " + config);
                                    return;
                                }
                                inMemTime = Common.S2i(st[++k]);
                                if (inMemTime < 0)
                                {
                                    Console.WriteLine("MemoryManagement: Invalid inMemTime in " + config);
                                    return;
                                }
                                lastTouchTime = Common.S2i(st[++k]);
                                if (lastTouchTime < 0)
                                {
                                    Console.WriteLine("MemoryManagement: Invalid lastTouchTime in " + config);
                                    return;
                                }
                                Page page = (Page)memVector[id];
                                page.physical = physical;
                                page.R = R;
                                page.M = M;
                                page.inMemTime = inMemTime;
                                page.lastTouchTime = lastTouchTime;
                            }
                        }
                        if (line.StartsWith("enable_logging"))
                        {
                            var st = line.Split(' ');
                            for (int k = 0; k < st.Length; k++)
                            {
                                if (st[k].StartsWith("true"))
                                {
                                    doStdoutLog = true;
                                }
                            }
                        }
                        if (line.StartsWith("log_file"))
                        {
                            var st = line.Split(' ');
                            for (int k = 0; k < st.Length; k++)
                            {
                                tmp = st[k];
                            }
                            if (tmp.StartsWith("log_file"))
                            {
                                doFileLog = false;
                                output = "tracefile";
                            }
                            else
                            {
                                doFileLog = true;
                                doStdoutLog = false;
                                output = tmp;
                            }
                        }
                        if (line.StartsWith("pagesize"))
                        {
                            var st = line.Split(' ');
                            for (int k = 0; k < st.Length; k++)
                            {
                                tmp = st[k];
                                tmp = st[++k];
                                if (tmp.StartsWith("power"))
                                {
                                    power = (double)int.Parse(st[++k]);
                                    block = (int)Math.Pow(2, power);
                                }
                                else
                                {
                                    block = long.Parse(tmp);
                                }
                                address_limit = (block * virtPageNum + 1) - 1;
                            }
                            if (block < 64 || block > Math.Pow(2, 26))
                            {
                                Console.WriteLine("MemoryManagement: pagesize is out of bounds");
                                return;
                            }
                            for (i = 0; i <= virtPageNum; i++)
                            {
                                Page page = (Page)memVector[i];
                                page.high = (block * (i + 1)) - 1;
                                page.low = block * i;
                            }
                        }
                        if (line.StartsWith("addressradix"))
                        {
                            var st = line.Split(' ');
                            for (int k = 0; k < st.Length; k++)
                            {
                                tmp = st[k];
                                tmp = st[++k];
                                addressradix = Byte.Parse(tmp);
                                if (addressradix < 0 || addressradix > 20)
                                {
                                    Console.WriteLine("MemoryManagement: addressradix out of bounds.");
                                    return;
                                }
                            }
                        }
                    }
                    reader.Close();
                }
                catch (IOException e) { /* Handle exceptions */ }
            }
            f = new FileStream(commands, FileMode.OpenOrCreate);
            try
            {
                StreamReader reader = new StreamReader(f);
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("READ") || line.StartsWith("WRITE"))
                    {
                        if (line.StartsWith("READ"))
                        {
                            command = "READ";
                        }
                        if (line.StartsWith("WRITE"))
                        {
                            command = "WRITE";
                        }
                        var st = line.Split(' ');
                        //tmp = st.nextToken();
                        tmp = st[1];
                        if (tmp.StartsWith("random"))
                        {
                            instructVector.Add(new Instruction(command, Common.RandomLong(address_limit)));
                        }
                        else
                        {
                            if (tmp.StartsWith("bin"))
                            {
                                addr = Convert.ToInt64(st[2], 2);
                            }
                            else if (tmp.StartsWith("oct"))
                            {
                                addr = Convert.ToInt64(st[2], 8);
                            }
                            else if (tmp.StartsWith("hex"))
                            {
                                addr = Convert.ToInt64(st[2], 16);
                            }
                            else
                            {
                                addr = long.Parse(tmp);
                            }
                            if (0 > addr || addr > address_limit)
                            {
                                Console.WriteLine("MemoryManagement: " + addr + ", Address out of range in " + commands);
                                return;
                            }
                            instructVector.Add(new Instruction(command, addr));
                        }
                    }
                }
                reader.Close();
            }
            catch (IOException e) { /* Handle exceptions */ }
            runcycles = instructVector.Count;
            if (runcycles < 1)
            {
                Console.WriteLine("MemoryManagement: no instructions present for execution.");
                return;
            }
            if (doFileLog)
            {
                //FileStream trace = new FileStream(output, FileMode.OpenOrCreate);
                File.Delete(output);
            }
            runs = 0;
            for (i = 0; i < virtPageNum; i++)
            {
                Page page = (Page)memVector[i];
                if (page.physical != -1)
                {
                    map_count++;
                }
                for (j = 0; j < virtPageNum; j++)
                {
                    Page tmp_page = (Page)memVector[j];
                    if (tmp_page.physical == page.physical && page.physical >= 0)
                    {
                        physical_count++;
                    }
                }
                if (physical_count > 1)
                {
                    Console.WriteLine("MemoryManagement: Duplicate physical page's in " + config);
                    return;
                }
                physical_count = 0;
            }
            if (map_count < (virtPageNum + 1) / 2)
            {
                for (i = 0; i < virtPageNum; i++)
                {
                    Page page = (Page)memVector[i];
                    if (page.physical == -1 && map_count < (virtPageNum + 1) / 2)
                    {
                        page.physical = i;
                        map_count++;
                    }
                }
            }
            for (i = 0; i <= virtPageNum; i++) // TODO: i < virtPageNum
            {
                Page page = (Page)memVector[i];
                if (page.physical == -1)
                {
                    controlPanel.removePhysicalPage(i);
                }
                else
                {
                    controlPanel.addPhysicalPage(i, page.physical);
                }
            }
            for (i = 0; i < instructVector.Count; i++)
            {
                high = block * virtPageNum;
                Instruction instruct = (Instruction)instructVector[i];
                if (instruct.addr < 0 || instruct.addr > high)
                {
                    Console.WriteLine("MemoryManagement: Instruction (" + instruct.inst + " " + instruct.addr + ") out of bounds.");
                    return;
                }
            }
        }

        public void setControlPanel(ControlPanel newControlPanel)
        {
            controlPanel = newControlPanel;
        }

        public void getPage(int pageNum)
        {
            Page page = (Page)memVector[pageNum];
            controlPanel.paintPage(page);
        }

        private void printLogFile(String message)
        {
            String line;
            String temp = "";

            //File trace = new File(output);
            if (File.Exists(output))
            {
                try
                {
                    StreamReader reader = new StreamReader(output);
                    while ((line = reader.ReadLine()) != null)
                    {
                        temp = temp + line + lineSeparator;
                    }
                    reader.Close();
                }
                catch (IOException e)
                {
                    /* Do nothing */
                }
            }
            try
            {
                StreamWriter writer = new StreamWriter(output);
                writer.Write(temp);
                writer.Write(message);
                writer.Close();
            }
            catch (IOException e)
            {
                /* Do nothing */
            }
        }

        public void run()
        {
            step();
            while (runs != runcycles)
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(10);
                }

                step();
            }
        }

        public void step()
        {
            int i = 0;
            Instruction instruct = (Instruction)instructVector[runs];
            controlPanel.instructionLabel.Text = (instruct.inst);
            controlPanel.addressLabel.Text = (Convert.ToString(instruct.addr, addressradix));
            getPage(Virtual2Physical.pageNum(instruct.addr, virtPageNum, block));
            if (controlPanel.pageFaultLabel.Text == "YES")
            {
                controlPanel.pageFaultLabel.Text = ("NO");
            }
            if (instruct.inst.StartsWith("READ"))
            {
                Page page = (Page)memVector[Virtual2Physical.pageNum(instruct.addr, virtPageNum, block)];
                if (page.physical == -1)
                {
                    if (doFileLog)
                    {
                        printLogFile("READ " + Convert.ToString(instruct.addr, addressradix) + " ... page fault");
                    }
                    if (doStdoutLog)
                    {
                        Console.WriteLine("READ " + Convert.ToString(instruct.addr, addressradix) + " ... page fault");
                    }
                    PageFault.replacePage(memVector, virtPageNum, Virtual2Physical.pageNum(instruct.addr, virtPageNum, block), controlPanel);
                    controlPanel.pageFaultLabel.Text = ("YES");
                }
                else
                {
                    page.R = 1;
                    page.lastTouchTime = 0;
                    if (doFileLog)
                    {
                        printLogFile("READ " + Convert.ToString(instruct.addr, addressradix) + " ... okay");
                    }
                    if (doStdoutLog)
                    {
                        Console.WriteLine("READ " + Convert.ToString(instruct.addr, addressradix) + " ... okay");
                    }
                }
            }
            if (instruct.inst.StartsWith("WRITE"))
            {
                Page page = (Page)memVector[Virtual2Physical.pageNum(instruct.addr, virtPageNum, block)];
                if (page.physical == -1)
                {
                    if (doFileLog)
                    {
                        printLogFile("WRITE " + Convert.ToString(instruct.addr, addressradix) + " ... page fault");
                    }
                    if (doStdoutLog)
                    {
                        Console.WriteLine("WRITE " + Convert.ToString(instruct.addr, addressradix) + " ... page fault");
                    }
                    PageFault.replacePage(memVector, virtPageNum, Virtual2Physical.pageNum(instruct.addr, virtPageNum, block), controlPanel); 
                    controlPanel.pageFaultLabel.Text = ("YES");
                }
                else
                {
                    page.M = 1;
                    page.lastTouchTime = 0;
                    if (doFileLog)
                    {
                        printLogFile("WRITE " + Convert.ToString(instruct.addr, addressradix) + " ... okay");
                    }
                    if (doStdoutLog)
                    {
                        Console.WriteLine("WRITE " + Convert.ToString(instruct.addr, addressradix) + " ... okay");
                    }
                }
            }
            for (i = 0; i < virtPageNum; i++)
            {
                Page page = (Page)memVector[i];
                if (page.R == 1 && page.lastTouchTime == 10)
                {
                    page.R = 0;
                }
                if (page.physical != -1)
                {
                    page.inMemTime = page.inMemTime + 10;
                    page.lastTouchTime = page.lastTouchTime + 10;
                }
            }
            runs++;
            controlPanel.timeLabel.Text = (Convert.ToString(runs * 10) + " (ns)");
        }

        public void reset()
        {
            memVector.Clear();
            instructVector.Clear();
            controlPanel.statusLabel.Text = ("STOP");
            controlPanel.timeLabel.Text = ("0");
            controlPanel.instructionLabel.Text = ("NONE");
            controlPanel.addressLabel.Text = ("NULL");
            controlPanel.pageFaultLabel.Text = ("NO");
            controlPanel.virtualPageLabel.Text = ("x");
            controlPanel.physicalPageLabel.Text = ("0");
            controlPanel.rLabel.Text = ("0");
            controlPanel.mLabel.Text = ("0");
            controlPanel.inMemTimeLabel.Text = ("0");
            controlPanel.lastTouchTimeLabel.Text = ("0");
            controlPanel.lowLabel.Text = ("0");
            controlPanel.highLabel.Text = ("0");
            init(command_file, config_file);
        }
    }
}
