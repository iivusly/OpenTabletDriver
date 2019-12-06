using System;
using TabletDriverLib.Component;
using TabletDriverLib.Tablet;

namespace TabletDriverLib.Vendors.Wacom
{
    public class WacomTabletReport : ITabletReport
    {
        public WacomTabletReport(byte[] report)
        {
            Raw = report;
            Lift = (uint) report[2] / report[1];
            var x = BitConverter.ToUInt16(report, 3);
            var y = BitConverter.ToUInt16(report, 5);
            Position = new Point(x, y);
            Pressure = BitConverter.ToUInt16(report, 7);
        }

        public byte[] Raw { private set; get; }
        public uint Lift { private set; get; }
        public Point Position { private set; get; }
        public uint Pressure { private set; get; }
    }
}