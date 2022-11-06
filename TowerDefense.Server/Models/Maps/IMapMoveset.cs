using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Server.Models.Maps
{
    public interface IMapMoveset
    {
        public List<MovePoint> GetMovePoints();
    }
}
