namespace RtkIRLib
{
    public class DeviceID
    {
        public ushort Vid { get; set; }
        public ushort Pid { get; set; }

        public DeviceID()
        {
            // Empty constructor
        }

        public DeviceID(ushort vid, ushort pid)
        {
            this.Vid = vid;
            this.Pid = pid;
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to DeviceID return false.
            DeviceID id = obj as DeviceID;
            if (id == null)
            {
                return false;
            }

            return (this.Vid == id.Vid && this.Pid == id.Pid);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0:X4}:{1:X4}", this.Vid, this.Pid);
        }
    }
}
