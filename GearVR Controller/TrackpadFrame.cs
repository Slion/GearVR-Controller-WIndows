using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearVR_Controller
{
    class TrackpadFrame
    {
        public Point Position;
        public Vector Displacement;
        public Vector Velocity;
        public Vector Acceleration;
        public DateTimeOffset Timestamp;
        public double Time;

        public TrackpadFrame()
        {
            Reset();
        }

        public void Compute(in TrackpadFrame aFrame) 
        {
            // Compute time offset
            Time = (Timestamp - aFrame.Timestamp).TotalSeconds;

            // Compute delta
            Displacement = Position - aFrame.Position;

            // Compute speed                       
            Velocity = Displacement / Time;

            // Compute acceleration
            Acceleration = Velocity / Time;
        }

        public void Reset()
        {
            Position.X = 0;
            Position.Y = 0;
            Displacement.X = 0;
            Displacement.Y = 0;
            Velocity.X = 0;
            Velocity.Y = 0;
            Acceleration.X = 0;
            Acceleration.Y = 0;
            Timestamp = DateTimeOffset.Now;
        }

        public override String ToString()
        {
            //StringBuilder sb = new StringBuilder();
            //sb.AppendFormat("")

            return $"Δt {Time*1000:0#}ms - P({Position.X},{Position.Y}) - D({Displacement.X},{Displacement.Y}) - V({Velocity.X},{Velocity.Y}) - A({Acceleration.X},{Acceleration.Y})"; 
        }
    }
}
