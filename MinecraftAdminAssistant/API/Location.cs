using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftAdminAssistant.Data {
    [Serializable]
    public class Location: ICloneable {
        public string Name { get; set; }
        public string World { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public override string ToString() {
            return Name;
        }

        public object Clone() {
            return MemberwiseClone();
        }

        public override bool Equals(object obj) {
            Location otherLoc = obj as Location;
            if (otherLoc == null) return base.Equals(obj);

            return World == otherLoc.World && X == otherLoc.X && Y == otherLoc.Y && Z == otherLoc.Z;
        }

        public override int GetHashCode() {
            return (World + X + Y + Z).GetHashCode();
        }

    }
}
